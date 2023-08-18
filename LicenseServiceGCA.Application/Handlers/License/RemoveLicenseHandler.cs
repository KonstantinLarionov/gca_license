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
	public class RemoveLicenseHandler : IRequestHandler<RemoveLicenseRequest, RemoveLicenseResponse>
	{
		private readonly IRepository<Domain.Entities.License> _repository;

		public RemoveLicenseHandler( IRepository<Domain.Entities.License> repository )
		{
			this._repository = repository;
		}

		public async Task<RemoveLicenseResponse> Handle( RemoveLicenseRequest request, CancellationToken cancellationToken )
		{
			var res = _repository
				.Get(x=>x.Id == request.Id)
				.FirstOrDefault();

			var response = new RemoveLicenseResponse();

			if ( res == null )
			{
				response.Success = false;
				response.Message = "Failed to get a record in the database";
				return response;
			}

			var deleteRes = _repository.Remove( res );

			if ( deleteRes == 0 )
			{
				response.Success = false;
				response.Message = "Failed to remove a record in the database";
				return response;
			}

			response.Success = true;

			return response;
		}
	}
}
