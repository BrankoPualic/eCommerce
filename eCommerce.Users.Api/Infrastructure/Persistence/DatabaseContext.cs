using Microsoft.EntityFrameworkCore;

namespace eCommerce.Users.Api.Infrastructure.Persistence;

public class DatabaseContext : DbContext
{
	public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
	{ }
}