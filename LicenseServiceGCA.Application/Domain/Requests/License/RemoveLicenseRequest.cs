using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LicenseServiceGCA.Application.Domain.Responses.License;
using MediatR;

namespace LicenseServiceGCA.Application.Domain.Requests.License
{
	public class RemoveLicenseRequest : IRequest<RemoveLicenseResponse>
	{
		public Guid Id { get; set; }
		public string Hash { get; set; } 
		public DateTime LicenseEnd { get; set; } 
		public bool IsLicensed { get; set; } 
	}
}
