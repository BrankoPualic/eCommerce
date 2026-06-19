using FluentValidation;

namespace eCommerce.Users.Api.Endpoints;

public class CreateUserRequestValidator : AbstractValidator<CreateUserRequest>
{
	public CreateUserRequestValidator()
	{
		RuleFor(_ => _.FirstName)
			.NotEmpty().WithMessage("First name cannot be empty")
			.MaximumLength(20).WithMessage("First name is too long");

		RuleFor(_ => _.LastName)
			.NotEmpty().WithMessage("Last name cannot be empty")
			.MaximumLength(30).WithMessage("Last name is too long");

		RuleFor(_ => _.MiddleName)
			.MaximumLength(20).WithMessage("Middle name is too long").When(_ => !string.IsNullOrWhiteSpace(_.MiddleName));

		RuleFor(_ => _.Gender)
			.IsInEnum().WithMessage("Gender is not defined");

		RuleFor(_ => _.Email)
			.NotEmpty().WithMessage("Email cannot be empty")
			.EmailAddress().WithMessage("Email is not valid")
			.MaximumLength(255).WithMessage("Email is too long");

		RuleFor(_ => _.Password)
			.NotEmpty().WithMessage("Password cannot be empty")
			.MinimumLength(8).WithMessage("Password is too short")
			.MaximumLength(30).WithMessage("Password is too long");

		RuleFor(_ => _.ConfirmPassword)
			.Equal(_ => _.Password).WithMessage("Passwords do not match");
	}
}