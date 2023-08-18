using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LicenseServiceGCA.Application.Domain.Entities
{
	public class User
	{
		public Guid Id { get; set; }
		public string Email { get; set; }
		public License License { get; set; }
	}
}