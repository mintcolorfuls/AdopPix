using Microsoft.EntityFrameworkCore.Migrations;

namespace AdopPix.DataAccess.Migrations
{
    public partial class UpdateTableNotificationAddFieldFromAndTo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.RenameColumn(
                name: "To",
                table: "Notifications",
                newName: "ToId");

            migrationBuilder.RenameColumn(
                name: "From",
                table: "Notifications",
                newName: "FromId");

            migrationBuilder.RenameIndex(
                name: "IX_Notifications_To",
                table: "Notifications",
                newName: "IX_Notifications_ToId");

            migrationBuilder.AddForeignKey(
                name: "FK_Notifications_Users_ToId",
                table: "Notifications",
                column: "ToId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notifications_Users_ToId",
                table: "Notifications");

            migrationBuilder.RenameColumn(
                name: "ToId",
                table: "Notifications",
                newName: "To");

            migrationBuilder.RenameColumn(
                name: "FromId",
                table: "Notifications",
                newName: "From");

            migrationBuilder.RenameIndex(
                name: "IX_Notifications_ToId",
                table: "Notifications",
                newName: "IX_Notifications_To");

            migrationBuilder.AddForeignKey(
                name: "FK_Notifications_Users_To",
                table: "Notifications",
                column: "To",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
