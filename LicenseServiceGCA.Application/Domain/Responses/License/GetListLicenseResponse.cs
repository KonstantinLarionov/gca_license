using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LicenseServiceGCA.Application.Domain.Responses.License
{
    public class GetListLicenseResponse : BaseResponse
    {
		public List<Entities.License> Licenses { get; set; }
    }
}
