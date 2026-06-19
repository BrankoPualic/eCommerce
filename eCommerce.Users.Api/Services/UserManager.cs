using eCommerce.Users.Api.Interfaces;

namespace eCommerce.Users.Api.Services;

public class UserManager : IUserManager
{
	public string HashPassword(string password) => BCrypt.Net.BCrypt.HashPassword(password);

	public bool VerifyPassword(string input, string password) => BCrypt.Net.BCrypt.Verify(input, password);
}