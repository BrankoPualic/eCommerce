using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eCommerce.Users.Api.Infrastructure.Persistence.Migrations
{
	[DbContext(typeof(DatabaseContext))]
	[Migration("20260619203230_ADD_User")]
	/// <inheritdoc />
	public partial class ADD_User : Migration
	{
		/// <inheritdoc />
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.CreateTable(
				name: "Users",
				columns: table => new
				{
					Id = table.Column<int>(type: "INTEGER", nullable: false)
						.Annotation("Sqlite:Autoincrement", true),
					PublicId = table.Column<Guid>(type: "TEXT", nullable: false),
					FirstName = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
					MiddleName = table.Column<string>(type: "TEXT", maxLength: 20, nullable: true),
					LastName = table.Column<string>(type: "TEXT", maxLength: 30, nullable: false),
					Gender = table.Column<int>(type: "INTEGER", nullable: false),
					Email = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
					Password = table.Column<string>(type: "TEXT", nullable: false),
					IsActive = table.Column<bool>(type: "INTEGER", nullable: false),
					CreatedOn = table.Column<DateTime>(type: "TEXT", nullable: false),
					UpdatedOn = table.Column<DateTime>(type: "TEXT", nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Users", x => x.Id);
					table.UniqueConstraint("AK_Users_PublicId", x => x.PublicId);
				});

			migrationBuilder.CreateIndex(
				name: "IX_Users_Email",
				table: "Users",
				column: "Email",
				unique: true);
		}

		/// <inheritdoc />
		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropTable(
				name: "Users");
		}
	}
}
