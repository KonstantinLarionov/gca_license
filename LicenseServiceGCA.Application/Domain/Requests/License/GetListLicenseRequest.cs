using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LicenseServiceGCA.Application.Domain.Responses.License;
using MediatR;

namespace LicenseServiceGCA.Application.Domain.Requests.License
{
	public class GetListLicenseRequest : IRequest<GetListLicenseResponse>
	{

	}
}
