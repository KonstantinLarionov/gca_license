using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

using MediatR;

using Microsoft.Extensions.DependencyInjection;

namespace LicenseServiceGCA.Application
{
	public static class ServiceCollection
	{
		/// <summary>
		/// AddApplication
		/// </summary>
		/// <param name="services"></param>
		public static void AddApplication( this IServiceCollection services )
		{
			var assembly = typeof( ServiceCollection ).GetTypeInfo().Assembly;
			services.AddMediatR(  Assembly.GetExecutingAssembly() );
		}
	}
}
