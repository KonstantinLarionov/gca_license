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
	public class GetListUserHandler : IRequestHandler<GetListUserRequest, GetListUserResponse>
	{
		private readonly IRepository<Domain.Entities.User> _repository;

		public GetListUserHandler( IRepository<Domain.Entities.User> repository )
		{
			this._repository = repository;
		}

		public async Task<GetListUserResponse> Handle( GetListUserRequest request, CancellationToken cancellationToken )
		{
			var res = _repository
				.Get()
				.ToList();

			var response = new GetListUserResponse();

			if ( res == null )
			{
				response.Success = false;
				response.Message = "Failed to get list a record in the database";
				return response;
			}

			response.Success = true;
			response.Users = res;

			return response;
		}
	}
}
