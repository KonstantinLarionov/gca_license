using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace LicenseServiceGCA.Application.AuthorizeOptions
{
	public class HashPassword
	{
		//TODO также подумать о оптимальном размера соли
		//TODO тут должна лежать постоянная составляющая соли а еще лучше подрубить ее из config			
		private readonly byte[] _staticSalt = new byte[64 / 8] { 130, 105, 75, 103, 70, 158, 128, 199 };

		public byte[] CreateSalt()
		{
			var _salt = new byte[64 / 8];
			using (var rng = RandomNumberGenerator.Create())
			{
				rng.GetBytes(_salt);
			}
			return _salt;
		}

		private byte[] GetSalt(byte[] salt)
		{
			var fullSalt = salt.Concat(_staticSalt).ToArray();			
			return fullSalt;
		}

		public string EncryptingPass(string password,byte [] salt)
		{
			byte[] fullSalt = GetSalt(salt); 
            var hash = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password,
                salt: fullSalt,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 10000,
                numBytesRequested: 256 / 8
                ));
            return hash;            
        }
	}
}
