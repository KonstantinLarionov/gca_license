using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LicenseServiceGCA.Application.Domain.Responses.User;
using MediatR;

namespace LicenseServiceGCA.Application.Domain.Requests.User
{
	public class RemoveUserRequest : IRequest<RemoveUserResponse>
	{
		public Guid Id { get; set; }
		public string Email { get; set; } 
	}
}
