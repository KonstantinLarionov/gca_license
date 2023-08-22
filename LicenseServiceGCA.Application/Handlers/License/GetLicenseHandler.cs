using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

using LicenseServiceGCA.Application.Abstractions;
using LicenseServiceGCA.Application.Domain.Requests.License;
using LicenseServiceGCA.Application.Domain.Responses.License;
using MediatR;

namespace LicenseServiceGCA.Application.Handlers.License
{
	public class GetLicenseHandler : IRequestHandler<GetLicenseRequest, GetLicenseResponse>
	{
		private readonly IRepository<Domain.Entities.License> _repository;

		public GetLicenseHandler( IRepository<Domain.Entities.License> repository )
		{
			this._repository = repository;
		}

		public async Task<GetLicenseResponse> Handle( GetLicenseRequest request, CancellationToken cancellationToken )
		{
			var res = _repository
				.Get( x=>x.OpenToken == request.OpenToken )
				.FirstOrDefault();

			var response = new GetLicenseResponse();

			if ( res == null || res.LicenseEnd < DateTime.Now )
			{
				response.Success = false;
				response.Message = "Failed to get a record in the database";
				response.IsLicensed = false;
				return response;
			}
			
			using SHA384 hash = SHA384.Create();
			var text = res.IsLicensed.ToString() + res.LicenseEnd.ToString() + "SALTYGCa" + res.Id;
			response.Hash = Convert.ToHexString(hash.ComputeHash(Encoding.ASCII.GetBytes(text)));
			response.Id = res.Id;
			response.IsLicensed = res.IsLicensed;
			response.LicenseEnd = res.LicenseEnd;
			response.Success = true;
			
			return response;
		}
	}
}
