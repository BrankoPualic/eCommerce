using eCommerce.Users.Api.Domain;
using eCommerce.Users.Api.Domain.Enumerators;

namespace eCommerce.Users.Api.Infrastructure.Queries;

public record UserResponse
{
	public Guid Id { get; init; }

	public string FirstName { get; init; }

	public string? MiddleName { get; init; }

	public string LastName { get; init; }

	public Gender Gender { get; init; }

	public string Email { get; init; }

	public bool IsActive { get; init; }

	public DateTime CreatedOn { get; init; }

	public DateTime UpdatedOn { get; init; }


	public UserResponse(User user)
	{
		Id = user.PublicId.Value;
		FirstName = user.FirstName;
		MiddleName = user.MiddleName;
		LastName = user.LastName;
		Gender = user.Gender;
		Email = user.Email;
		IsActive = user.IsActive;
		CreatedOn = user.CreatedOn;
		UpdatedOn = user.UpdatedOn;
	}
}
