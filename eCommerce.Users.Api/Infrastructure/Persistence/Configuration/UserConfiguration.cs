using eCommerce.Users.Api.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace eCommerce.Users.Api.Infrastructure.Persistence.Configuration;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
	public void Configure(EntityTypeBuilder<User> builder)
	{
		builder.Property<int>("Id").ValueGeneratedOnAdd();
		builder.HasKey("Id");

		builder.Property(_ => _.PublicId).HasConversion(new UserIdConverter());
		builder.HasAlternateKey(_ => _.PublicId);

		builder.Property(_ => _.FirstName)
			.IsRequired()
			.HasMaxLength(20);

		builder.Property(_ => _.LastName)
			.IsRequired()
			.HasMaxLength(30);

		builder.Property(_ => _.MiddleName)
			.HasMaxLength(20);

		builder.Property(_ => _.Gender)
			.IsRequired();

		builder.Property(_ => _.Email)
			.IsRequired()
			.HasMaxLength(255);

		builder.HasIndex(_ => _.Email).IsUnique();
	}

	public class UserIdConverter() : ValueConverter<User.UserId, Guid>(id => id.Value, value => new(value));
}
