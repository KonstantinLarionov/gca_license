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
	internal class UserRepository : IRepository<User>
	{

		private readonly DbSet<User> _dbSet;
		private readonly LicenseServiceGCAContext _context;

		/// <summary>
		/// UserRepository
		/// </summary>
		/// <param name="context"></param>
		public UserRepository( LicenseServiceGCAContext context )
		{
			_context = context;
			_dbSet = context.Set<User>();
		}
		/// <summary>
		/// Create
		/// </summary>
		public int Create( User item )
		{
			_dbSet.Add( item );
			return _context.SaveChanges();
		}
		/// <summary>
		/// FindById
		/// </summary>
		public User FindById( Guid id )
		{
			return _dbSet.Find( id );
		}
		/// <summary>
		/// Get
		/// </summary>
		public IEnumerable<User> Get()
		{
			return _dbSet.AsNoTracking();
		}
		/// <summary>
		/// Get
		/// </summary>
		public IEnumerable<User> Get( Func<User, bool> predicate )
		{
			return _dbSet.AsNoTracking().Where( predicate );
		}
		/// <summary>
		/// Remove
		/// </summary>
		public int Remove( User item )
		{
			_dbSet.Remove( item );
			return _context.SaveChanges();
		}
		/// <summary>
		/// Update
		/// </summary>
		public int Update( User item )
		{
			_context.Entry( item ).State = EntityState.Modified;
			return _context.SaveChanges();
		}
		/// <summary>
		/// GetWithInclude
		/// </summary>
		public IEnumerable<User> GetWithInclude( Func<User, bool> predicate, params Expression<Func<User, object>>[] includeProperties )
		{
			var query = Include( includeProperties );
			return query.Where( predicate );
		}

		/// <summary>
		/// GetWithInclude
		/// </summary>
		public IEnumerable<User> GetWithInclude( object includeProperty, params Expression<Func<User, object>>[] includeProperties )
		{
			return Include( includeProperties );
		}
		/// <summary>
		/// Include
		/// </summary>
		private IQueryable<User> Include( params Expression<Func<User, object>>[] includeProperties )
		{
			IQueryable<User> query = _dbSet.AsNoTracking();
			return includeProperties
				.Aggregate( query, ( current, includeProperty ) => current.Include( includeProperty ) );
		}
	}
}
