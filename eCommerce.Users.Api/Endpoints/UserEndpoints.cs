namespace eCommerce.Users.Api.Endpoints;

public static class UserEndpoints
{
	public static void MapUserEndpoints(this IEndpointRouteBuilder app)
	{
		var group = app.MapGroup("/api/users");

		group.MapGet("/", GetUsers);
		group.MapGet("/{id}", GetUser);
		group.MapPost("/", CreateUser);
		group.MapPatch("/{id}", UpdateUser);
		group.MapDelete("/{id}", DeleteUser);
	}

	private static async Task<IResult> GetUsers(CancellationToken ct = default)
	{
		return Results.Ok();
	}

	private static async Task<IResult> GetUser(Guid id, CancellationToken ct = default)
	{
		return Results.Ok();
	}

	private static async Task<IResult> CreateUser(CancellationToken ct = default)
	{
		return Results.Created();
	}

	private static async Task<IResult> UpdateUser(Guid id, CancellationToken ct = default)
	{
		return Results.NoContent();
	}

	private static async Task<IResult> DeleteUser(Guid id, CancellationToken ct = default)
	{
		return Results.NoContent();
	}
}