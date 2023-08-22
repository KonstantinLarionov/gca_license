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
	public class CreateUserHandler : IRequestHandler<CreateUserRequest, CreateUserResponse>
	{
		private readonly IRepository<Domain.Entities.User> _repository;

		public CreateUserHandler(IRepository<Domain.Entities.User> repository)
		{
			this._repository = repository;
		}

		public async Task<CreateUserResponse> Handle( CreateUserRequest request, CancellationToken cancellationToken )
		{
			var entity = request.User;
			var res = _repository.Create( entity );

			var response = new CreateUserResponse();

			if ( res == 0 )
			{
				response.Success = false;
				response.Message = "Failed to create a record in the database";
				return response;
			}
			
			response.Success = true;
			return response;
		}
	}
}
