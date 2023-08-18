using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LicenseServiceGCA.Application.Domain.Responses.User
{
    public class CreateUserResponse : BaseResponse
    {
		public Guid Id { get; set; }
		public string Email { get; set; } 
    }
}
