using LicenseServiceGCA.Application.Abstractions;
using LicenseServiceGCA.Application.Domain.Entities;

namespace LicenseServiceGCA.Infrastructure.Database
{
	public class TestDataUserRepository : TestData<User>
	{
		/// <summary>
		/// Test USer DATASet
		/// </summary>
		/// <param name="context"></param>
		private List<User> _users = new List<User>();
		/// <summary>
		/// create dataset pass=login
		/// </summary>
		/// <param name="context"></param>
		public TestDataUserRepository()
		{			
			_users.Add(new User() { Id = Guid.NewGuid(), Email = "Test@mail.ru", Login = "admin", Password = "cVvgCxUplcKQZEt14Ngh31Tg9BoherLJWX03HWbMXAY=", Salt = "?{2\u0018e\u0016\u0002h" });
			_users.Add(new User() { Id = Guid.NewGuid(), Email = "Test1@mail.ru", Login = "user", Password = "2bJlm+9F1SvR8fcYpUWd/RphR2wIFJk5GqED1Gobplw=", Salt = "?{2\u0018e\u0016\u0002h" });
			_users.Add(new User() { Id = Guid.NewGuid(), Email = "Test2@mail.ru", Login = "user1", Password = "l0HT5H+7rPy2zfrHv6Ct32rgZq+YQrR9anNP8heeaBA=", Salt = "?{2\u0018e\u0016\u0002h" });
		}
		public IEnumerable<User> Get(Func<User, bool> predicate)
		{
			return _users.Where(predicate);
		}
	}
}