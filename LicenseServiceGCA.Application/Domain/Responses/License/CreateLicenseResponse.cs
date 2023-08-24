using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LicenseServiceGCA.Application.Domain.Responses.License
{
    public class CreateLicenseResponse : BaseResponse
    {
		//Данный калс 
		public Guid Id { get; set; }
		public string Hash { get; set; } 
		public DateTime LicenseEnd { get; set; } 
		public bool IsLicensed { get; set; } 
		public string Email { get; set; }
		public string Idtx { get; set; }
	}
}
