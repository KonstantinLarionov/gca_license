﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LicenseServiceGCA.Application.Domain.Responses.Token
{
	public class GetTokenResponse : BaseResponse
	{
		public string Token { get; set; }
	}
}