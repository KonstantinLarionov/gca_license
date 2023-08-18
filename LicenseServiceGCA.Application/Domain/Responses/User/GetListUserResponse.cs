using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LicenseServiceGCA.Application.Domain.Responses.User
{
    public class GetListUserResponse : BaseResponse
    {
		public List<Entities.User> Users { get; set; }
    }
}
