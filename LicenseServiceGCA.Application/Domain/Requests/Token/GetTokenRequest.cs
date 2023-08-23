using LicenseServiceGCA.Application.Domain.Responses.Token;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LicenseServiceGCA.Application.Domain.Requests.Token
{
	public class GetTokenRequest : IRequest<GetTokenResponse>
	{
		public string Login { get; set; }
        public string Password { get; set; }
    }
}