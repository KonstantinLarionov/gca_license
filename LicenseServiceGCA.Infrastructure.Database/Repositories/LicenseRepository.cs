using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using LicenseServiceGCA.Application.Abstractions;
using LicenseServiceGCA.Application.Domain.Entities;
using LicenseServiceGCA.Infrastructure.Database.Contexts;

using Microsoft.EntityFrameworkCore;

namespace LicenseServiceGCA.Infrastructure.Database.Repositories
{
	internal class LicenseRepository : IRepository<License>
	{

		private readonly DbSet<License> _dbSet;
		private readonly LicenseServiceGCAContext _context;

		/// <summary>
		/// LicenseRepository
		/// </summary>
		/// <param name="context"></param>
		public LicenseRepository( LicenseServiceGCAContext context )
		{
			_context = context;
			_dbSet = context.Set<License>();
		}
		/// <summary>
		/// Create
		/// </summary>
		public int Create( License item )
		{
			_dbSet.Add( item );
			return _context.SaveChanges();
		}
		/// <summary>
		/// FindById
		/// </summary>
		public License FindById( Guid id )
		{
			return _dbSet.Find( id );
		}
		/// <summary>
		/// Get
		/// </summary>
		public IEnumerable<License> Get()
		{
			return _dbSet.AsNoTracking();
		}
		/// <summary>
		/// Get
		/// </summary>
		public IEnumerable<License> Get( Func<License, bool> predicate )
		{
			return _dbSet.AsNoTracking().Where( predicate );
		}
		/// <summary>
		/// Remove
		/// </summary>
		public int Remove( License item )
		{
			_dbSet.Remove( item );
			return _context.SaveChanges();
		}
		/// <summary>
		/// Update
		/// </summary>
		public int Update( License item )
		{
			_context.Entry( item ).State = EntityState.Modified;
			return _context.SaveChanges();
		}
		/// <summary>
		/// GetWithInclude
		/// </summary>
		public IEnumerable<License> GetWithInclude( Func<License, bool> predicate, params Expression<Func<License, object>>[] includeProperties )
		{
			var query = Include( includeProperties );
			return query.Where( predicate );
		}

		/// <summary>
		/// GetWithInclude
		/// </summary>
		public IEnumerable<License> GetWithInclude( object includeProperty, params Expression<Func<License, object>>[] includeProperties )
		{
			return Include( includeProperties );
		}
		/// <summary>
		/// Include
		/// </summary>
		private IQueryable<License> Include( params Expression<Func<License, object>>[] includeProperties )
		{
			IQueryable<License> query = _dbSet.AsNoTracking();
			return includeProperties
				.Aggregate( query, ( current, includeProperty ) => current.Include( includeProperty ) );
		}
	}
}
