using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LicenseServiceGCA.Application.Domain.Responses.User
{
    public class GetUserResponse : BaseResponse
    {
		public Entities.User User { get; set; }
	}
}
