using eCommerce.Users.Api.Domain.Enumerators;

namespace eCommerce.Users.Api.Endpoints;

public record CreateUserRequest(string FirstName, string LastName, Gender Gender, string Email, string Password, string ConfirmPassword, bool IsActive, string? MiddleName);