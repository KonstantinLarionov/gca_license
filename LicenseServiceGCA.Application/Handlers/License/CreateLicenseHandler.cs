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

		public async Task<CreateLicenseResponse> Handle(CreateLicenseRequest request, CancellationToken cancellationToken)
		{
            var license = _repository.Get(x=>x.Idtx == request.License.Idtx).FirstOrDefault();
            if ( license != null )
            {
                return new CreateLicenseResponse() { Message = "Ошибка обратитесь в поддержку.", Success = false };
            }

			var entity = request.License;
			var res = _repository.Create(entity);

			var response = new CreateLicenseResponse();

			if (res == 0)
			{
				response.Success = false;
				response.Message = "Failed to create a record in the database";
				return response;
			}
			var getHandler = new GetLicenseHandler(_repository);
			var getResponse = await getHandler.Handle(new GetLicenseRequest() { OpenToken = request.License.OpenToken }, cancellationToken);

            response.OpenToken = entity.OpenToken;
            response.Id = entity.Id;
			response.Hash = getResponse.Hash;
			response.LicenseEnd = entity.LicenseEnd;
			response.IsLicensed = entity.IsLicensed;
			response.Success = true;
			response.Email = entity.Email;
			response.Idtx = entity.Idtx;

			return response;
		}
	}
}