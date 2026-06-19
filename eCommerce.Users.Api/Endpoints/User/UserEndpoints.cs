using eCommerce.Users.Api.Domain;
using eCommerce.Users.Api.Infrastructure.Persistence;
using eCommerce.Users.Api.Interfaces;
using FluentValidation;

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

	private static async Task<IResult> CreateUser(CreateUserRequest request, IValidator<CreateUserRequest> validator, DatabaseContext db, IUserManager userManager, CancellationToken ct = default)
	{
		var validation = validator.Validate(request);

		if (!validation.IsValid)
			return Results.BadRequest(validation.ToDictionary());

		var user = User.Create(
			request.FirstName,
			request.LastName,
			request.Gender,
			request.Email,
			userManager.HashPassword(request.Password),
			request.IsActive,
			request.MiddleName
		);

		db.Users.Add(user);
		await db.SaveChangesAsync(ct);

		return Results.Created($"/users/{user.PublicId}", user.PublicId.Value);
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