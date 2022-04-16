using Microsoft.EntityFrameworkCore.Migrations;

namespace AdopPix.DataAccess.Migrations
{
    public partial class UpdateUserProfile : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "rank",
                table: "UserProfiles",
                newName: "Rank");

            migrationBuilder.RenameColumn(
                name: "point",
                table: "UserProfiles",
                newName: "Point");

            migrationBuilder.RenameColumn(
                name: "money",
                table: "UserProfiles",
                newName: "Money");

            migrationBuilder.RenameColumn(
                name: "lname",
                table: "UserProfiles",
                newName: "Lname");

            migrationBuilder.RenameColumn(
                name: "fname",
                table: "UserProfiles",
                newName: "Fname");

            migrationBuilder.RenameColumn(
                name: "created",
                table: "UserProfiles",
                newName: "Created");

            migrationBuilder.RenameColumn(
                name: "coverName",
                table: "UserProfiles",
                newName: "CoverName");

            migrationBuilder.RenameColumn(
                name: "birthDate",
                table: "UserProfiles",
                newName: "BirthDate");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Rank",
                table: "UserProfiles",
                newName: "rank");

            migrationBuilder.RenameColumn(
                name: "Point",
                table: "UserProfiles",
                newName: "point");

            migrationBuilder.RenameColumn(
                name: "Money",
                table: "UserProfiles",
                newName: "money");

            migrationBuilder.RenameColumn(
                name: "Lname",
                table: "UserProfiles",
                newName: "lname");

            migrationBuilder.RenameColumn(
                name: "Fname",
                table: "UserProfiles",
                newName: "fname");

            migrationBuilder.RenameColumn(
                name: "Created",
                table: "UserProfiles",
                newName: "created");

            migrationBuilder.RenameColumn(
                name: "CoverName",
                table: "UserProfiles",
                newName: "coverName");

            migrationBuilder.RenameColumn(
                name: "BirthDate",
                table: "UserProfiles",
                newName: "birthDate");
        }
    }
}
