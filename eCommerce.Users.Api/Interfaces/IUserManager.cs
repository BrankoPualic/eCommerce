namespace eCommerce.Users.Api.Interfaces;

public interface IUserManager
{
	string HashPassword(string password);

	bool VerifyPassword(string input, string password);
}
