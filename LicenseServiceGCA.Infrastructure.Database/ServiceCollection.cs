using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using LicenseServiceGCA.Application.Abstractions;
using LicenseServiceGCA.Application.Domain.Entities;
using LicenseServiceGCA.Infrastructure.Database.Contexts;
using LicenseServiceGCA.Infrastructure.Database.Repositories;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LicenseServiceGCA.Infrastructure.Database
{
	public static class ServiceCollection
	{ /// <summary>
	  /// DataBase
	  /// </summary>
	  /// <param name="services"></param>
	  /// <param name="configuration"></param>
		public static void AddInfrastructureDataBase( this IServiceCollection services, IConfiguration configuration )
		{
			services.AddDbContext<LicenseServiceGCAContext>( options =>
				options.UseMySql( configuration.GetConnectionString( "DBConnection" ),
				new MySqlServerVersion( new Version( 5, 6, 45 ) ) ) );


			services.AddTransient<IRepository<User>, UserRepository>();
			services.AddTransient<IRepository<License>, LicenseRepository>();
		}
	}
}
