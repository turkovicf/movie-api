using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Movie.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class MergeFirstNameAndLastNameIntoName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Directors");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Actors");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "Directors",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "Actors",
                newName: "Name");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Directors",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Actors",
                newName: "LastName");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Directors",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Actors",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");
        }
    }
}
