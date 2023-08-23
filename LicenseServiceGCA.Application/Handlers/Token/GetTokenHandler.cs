using LicenseServiceGCA.Application.Domain.Requests.Token;
using LicenseServiceGCA.Application.Domain.Responses.Token;
using MediatR;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using LicenseServiceGCA.Application.AuthorizeOptions;
using LicenseServiceGCA.Application.Abstractions;
using LicenseServiceGCA.Application.Domain.Entities;
using System.Runtime.InteropServices;

namespace LicenseServiceGCA.Application.Handlers.Token
{
	public class GetTokenHandler : IRequestHandler<GetTokenRequest, GetTokenResponse>
	{
		private readonly TestData<Domain.Entities.User> _repository;

		public GetTokenHandler(TestData<Domain.Entities.User> repository)
		{
			this._repository = repository;
		}
		public async Task<GetTokenResponse> Handle(GetTokenRequest request, CancellationToken cancellationToken)
		{		
			Domain.Entities.User user = _repository.Get(u => request.Login == u.Login).SingleOrDefault();
			if (user == null)
			{
				var resp = new GetTokenResponse();
				resp.Success = false;
				resp.Message = "Пользователь не найден";
				return resp;
			}

			var hasher = new HashPassword();			
			string checkingPass = hasher.EncryptingPass(request.Password, Encoding.ASCII.GetBytes(user.Salt.ToCharArray(),0,8));
			
			user = _repository.Get(u => request.Login == u.Login && checkingPass == u.Password).SingleOrDefault();
			if (user == null)
			{
				var resp = new GetTokenResponse();
				resp.Success = false;
				resp.Message = "Пользователь не найден";
				return resp;
			}

			var tokenCreater = new TokenCreater();
			var response = new GetTokenResponse()
			{
				Token = tokenCreater.CreateToken(GetClaims(user.Login, user.Email, user.Id)),
				Success = true
			};			
			return response;
		}
		public List<Claim> GetClaims(string username,string email,Guid Id)
		{
			//TODO пока что такое клаймы. подумай чтоеще нужно
			var claims = new List<Claim> 
			{ 
				new Claim(ClaimTypes.Name, username),
				new Claim(ClaimTypes.Email, email),
				new Claim(ClaimTypes.SerialNumber, Id.ToString())
			};
			return claims;
		}
	}
}