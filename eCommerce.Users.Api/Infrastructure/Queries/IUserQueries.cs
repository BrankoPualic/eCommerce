namespace eCommerce.Users.Api.Infrastructure.Queries;

public interface IUserQueries
{
	Task<UserResponse[]> GetUsersAsync(CancellationToken ct = default);

	Task<UserResponse?> GetUserAsync(Guid id, CancellationToken ct = default);
}