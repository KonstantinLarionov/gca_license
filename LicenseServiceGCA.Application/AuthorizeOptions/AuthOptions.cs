using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;

namespace LicenseServiceGCA.Application.AuthorizeOptions
{
	public class AuthOptions
	{
		//TODO данные можно забирать через конфигуратион и убрать статику оставить рид онли поля
		public const string ISSUER = "MyAuthServer"; 
		public const string AUDIENCE = "MyAuthClient"; 
		const string KEY = "mysupersecret_secretkey!123";
		public const int Lifetime = 10080; //минут, что = 7 дням
		public static SymmetricSecurityKey GetSymmetricSecurityKey() =>
			new SymmetricSecurityKey(Encoding.UTF8.GetBytes(KEY));
	}
}