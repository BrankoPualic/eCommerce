using eCommerce.Users.Api.Domain;
using eCommerce.Users.Api.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace eCommerce.Users.Api.Infrastructure.Queries;

public class UserQueries(DatabaseContext context) : IUserQueries
{
	public async Task<UserResponse?> GetUserAsync(Guid id, CancellationToken ct = default)
	{
		var publicId = new User.UserId(id);

		return await context.Users
			.Where(user => user.PublicId == publicId)
			.Select(user => new UserResponse(user))
			.AsNoTracking()
			.FirstOrDefaultAsync(ct);
	}

	public async Task<UserResponse[]> GetUsersAsync(CancellationToken ct = default)
	{
		return await context.Users
			.Select(user => new UserResponse(user))
			.AsNoTracking()
			.ToArrayAsync(ct);
	}
}