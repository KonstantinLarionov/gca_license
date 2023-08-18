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
	public class UpdateLicenseHandler : IRequestHandler<UpdateLicenseRequest, UpdateLicenseResponse>
	{
		private readonly IRepository<Domain.Entities.License> _repository;

		public UpdateLicenseHandler( IRepository<Domain.Entities.License> repository )
		{
			this._repository = repository;
		}

		public async Task<UpdateLicenseResponse> Handle( UpdateLicenseRequest request, CancellationToken cancellationToken )
		{
			var res = _repository.Update( request.License );

			var response = new UpdateLicenseResponse();

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
