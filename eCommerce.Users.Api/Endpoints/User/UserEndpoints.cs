using eCommerce.Users.Api.Domain;
using eCommerce.Users.Api.Infrastructure.Persistence;
using eCommerce.Users.Api.Infrastructure.Queries;
using eCommerce.Users.Api.Interfaces;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

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

	private static async Task<UserResponse[]> GetUsers(IUserQueries queries, CancellationToken ct = default) => await queries.GetUsersAsync(ct);

	private static async Task<IResult> GetUser(Guid id, IUserQueries queries, CancellationToken ct = default)
	{
		return await queries.GetUserAsync(id, ct) is UserResponse response
			? Results.Ok(response)
			: Results.NotFound();
	}

	private static async Task<IResult> CreateUser(CreateUserRequest request, IValidator<CreateUserRequest> validator, DatabaseContext context, IUserManager userManager, CancellationToken ct = default)
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

		context.Users.Add(user);
		await context.SaveChangesAsync(ct);

		return Results.Created($"/users/{user.PublicId}", user.PublicId.Value);
	}

	private static async Task<IResult> UpdateUser(Guid id, UpdateUserRequest request, DatabaseContext context, CancellationToken ct = default)
	{
		var userId = new User.UserId(id);
		var user = await context.Users.FirstOrDefaultAsync(_ => _.PublicId == userId, ct);

		if (user == null)
			return Results.NotFound();

		user.Update(
			request.FirstName,
			request.MiddleName,
			request.LastName,
			request.Gender,
			request.Email,
			request.IsActive
		);

		await context.SaveChangesAsync(ct);

		return Results.NoContent();
	}

	private static async Task<IResult> DeleteUser(Guid id, CancellationToken ct = default)
	{
		return Results.NoContent();
	}
}