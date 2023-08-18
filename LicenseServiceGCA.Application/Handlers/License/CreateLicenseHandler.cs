using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LicenseServiceGCA.Application.Abstractions;
using LicenseServiceGCA.Application.Domain.Requests.License;
using LicenseServiceGCA.Application.Domain.Responses.License;

using MediatR;

namespace LicenseServiceGCA.Application.Handlers.License
{
	public class CreateLicenseHandler : IRequestHandler<CreateLicenseRequest, CreateLicenseResponse>
	{
		private readonly IRepository<Domain.Entities.License> _repository;

		public CreateLicenseHandler(IRepository<Domain.Entities.License> repository)
		{
			this._repository = repository;
		}

		public async Task<CreateLicenseResponse> Handle( CreateLicenseRequest request, CancellationToken cancellationToken )
		{
			var entity = request.License;
			var res = _repository.Create( entity );

			var response = new CreateLicenseResponse();

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
