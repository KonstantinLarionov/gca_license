using Microsoft.EntityFrameworkCore;
using LicenseServiceGCA.Application.Domain.Entities;

namespace LicenseServiceGCA.Infrastructure.Database.Contexts
{
	public class LicenseServiceGCAContext : DbContext
	{

		public virtual DbSet<User> Users { get; set; }
		public virtual DbSet<License> Licenses { get; set; }

		public LicenseServiceGCAContext() { Database.EnsureCreated(); }
		public LicenseServiceGCAContext( DbContextOptions<LicenseServiceGCAContext> options ) : base( options ) { Database.EnsureCreated(); }
		protected override void OnConfiguring( DbContextOptionsBuilder optionsBuilder )
		{
		}
		protected override void OnModelCreating( ModelBuilder modelBuilder )
		{
		}

	}
}
