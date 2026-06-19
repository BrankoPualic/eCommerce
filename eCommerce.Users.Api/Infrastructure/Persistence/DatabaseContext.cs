using eCommerce.Users.Api.Domain;
using eCommerce.Users.Api.Infrastructure.Persistence.Configuration;
using Microsoft.EntityFrameworkCore;

namespace eCommerce.Users.Api.Infrastructure.Persistence;

public class DatabaseContext : DbContext
{
	public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
	{ }

	public DbSet<User> Users => Set<User>();

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.ApplyConfiguration(new UserConfiguration());
	}
}