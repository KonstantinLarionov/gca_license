using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LicenseServiceGCA.Application.Abstractions
{
    public interface TestData<TEntity>
    {
		IEnumerable<TEntity> Get(Func<TEntity, bool> predicate);
	}
}
