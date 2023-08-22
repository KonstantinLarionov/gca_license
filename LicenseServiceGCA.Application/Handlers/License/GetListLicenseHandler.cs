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
	public class GetListLicenseHandler : IRequestHandler<GetListLicenseRequest, GetListLicenseResponse>
	{
		private readonly IRepository<Domain.Entities.License> _repository;

		public GetListLicenseHandler( IRepository<Domain.Entities.License> repository )
		{
			this._repository = repository;
		}

		public async Task<GetListLicenseResponse> Handle( GetListLicenseRequest request, CancellationToken cancellationToken )
		{
			var res = _repository
				.Get()
				.ToList();

			var response = new GetListLicenseResponse();

			if ( res == null )
			{
				response.Success = false;
				response.Message = "Failed to get list a record in the database";
				return response;
			}

			response.Success = true;
			response.Licenses = res;

			return response;
		}
	}
}
