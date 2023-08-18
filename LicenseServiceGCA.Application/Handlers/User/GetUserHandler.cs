using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LicenseServiceGCA.Application.Abstractions;
using LicenseServiceGCA.Application.Domain.Requests.User;
using LicenseServiceGCA.Application.Domain.Responses.User;
using MediatR;

namespace LicenseServiceGCA.Application.Handlers.User
{
	public class GetUserHandler : IRequestHandler<GetUserRequest, GetUserResponse>
	{
		private readonly IRepository<Domain.Entities.User> _repository;

		public GetUserHandler( IRepository<Domain.Entities.User> repository )
		{
			this._repository = repository;
		}

		public async Task<GetUserResponse> Handle( GetUserRequest request, CancellationToken cancellationToken )
		{
			var res = _repository
				.Get( x=>x.Id == request.Id )
				.FirstOrDefault();

			var response = new GetUserResponse();

			if ( res == null )
			{
				response.Success = false;
				response.Message = "Failed to get a record in the database";
				return response;
			}

			response.Success = true;
			response.User = res;

			return response;
		}
	}
}
