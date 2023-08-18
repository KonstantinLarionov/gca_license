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
	public class UpdateUserHandler : IRequestHandler<UpdateUserRequest, UpdateUserResponse>
	{
		private readonly IRepository<Domain.Entities.User> _repository;

		public UpdateUserHandler( IRepository<Domain.Entities.User> repository )
		{
			this._repository = repository;
		}

		public async Task<UpdateUserResponse> Handle( UpdateUserRequest request, CancellationToken cancellationToken )
		{
			var res = _repository.Update( request.User );

			var response = new UpdateUserResponse();

			if ( res == 0 )
			{
				response.Success = false;
				response.Message = "Failed to update a record in the database";
				return response;
			}

			response.Success = true;

			return response;
		}
	}
}
