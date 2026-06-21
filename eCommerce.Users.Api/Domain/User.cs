using eCommerce.Users.Api.Domain.Enumerators;

namespace eCommerce.Users.Api.Domain;

public class User
{
	#region Properties

	public readonly record struct UserId(Guid Value)
	{
		public static UserId Empty { get; } = new(Guid.Empty);
		public static UserId New() => new(Guid.NewGuid());
	}

	public UserId PublicId { get; private set; } = UserId.Empty;

	// Personal Information

	public string FirstName { get; private set; } = string.Empty;

	public string? MiddleName { get; private set; }

	public string LastName { get; private set; } = string.Empty;

	public Gender Gender { get; private set; }

	// Credentials

	public string Email { get; private set; } = string.Empty;

	public string Password { get; private set; } = string.Empty;

	// Status

	public bool IsActive { get; private set; }

	// Audit

	public DateTime CreatedOn { get; set; }

	public DateTime UpdatedOn { get; set; }

	#endregion Properties

	#region Constructors

	private User()
	{ }

	private User(string firstName, string lastName, Gender gender, string email, string password, bool isActive, string? middleName) : this()
	{
		FirstName = firstName;
		MiddleName = middleName;
		LastName = lastName;
		Gender = gender;

		Email = email;
		Password = password;

		IsActive = isActive;
	}

	#endregion Constructors

	#region Methods

	public static User Create(string firstName, string lastName, Gender gender, string email, string password, bool isActive, string? middleName)
	{
		if (string.IsNullOrWhiteSpace(firstName))
			throw new ArgumentException("First name cannot be empty");

		if (string.IsNullOrWhiteSpace(lastName))
			throw new ArgumentException("Last name cannot be empty");

		if (!Enum.IsDefined(gender))
			throw new ArgumentException("Gender is not defined");

		if (string.IsNullOrWhiteSpace(email))
			throw new ArgumentException("Email cannot be empty");

		if (string.IsNullOrWhiteSpace(password))
			throw new ArgumentException("Password cannot be empty");

		return new(firstName, lastName, gender, email, password, isActive, middleName);
	}

	public void Update(string? firstName, string? middleName, string? lastName, Gender? gender, string? email, bool? isActive)
	{
		if (!string.IsNullOrWhiteSpace(firstName))
			FirstName = firstName;

		if (!string.IsNullOrWhiteSpace(middleName))
			MiddleName = middleName;

		if (!string.IsNullOrWhiteSpace(lastName))
			LastName = lastName;

		if (gender != null && Enum.IsDefined((Gender)gender))
			Gender = (Gender)gender;

		if (!string.IsNullOrWhiteSpace(email))
			Email = email;

		if (isActive.HasValue)
			IsActive = isActive.Value;
	}

	#endregion Methods
}