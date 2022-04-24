using Microsoft.EntityFrameworkCore.Migrations;

namespace AdopPix.DataAccess.Migrations
{
    public partial class UpdateSocialMediaAtSocialId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.DropColumn(
                name: "SocialMediaTypeSocialId",
                table: "SocialMedias");

            migrationBuilder.CreateIndex(
                name: "IX_SocialMedias_SocialId",
                table: "SocialMedias",
                column: "SocialId");

            migrationBuilder.AddForeignKey(
                name: "FK_SocialMedias_SocialMediaTypes_SocialId",
                table: "SocialMedias",
                column: "SocialId",
                principalTable: "SocialMediaTypes",
                principalColumn: "SocialId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SocialMedias_SocialMediaTypes_SocialId",
                table: "SocialMedias");

            migrationBuilder.DropIndex(
                name: "IX_SocialMedias_SocialId",
                table: "SocialMedias");

            migrationBuilder.AddColumn<int>(
                name: "SocialMediaTypeSocialId",
                table: "SocialMedias",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SocialMedias_SocialMediaTypeSocialId",
                table: "SocialMedias",
                column: "SocialMediaTypeSocialId");

            migrationBuilder.AddForeignKey(
                name: "FK_SocialMedias_SocialMediaTypes_SocialMediaTypeSocialId",
                table: "SocialMedias",
                column: "SocialMediaTypeSocialId",
                principalTable: "SocialMediaTypes",
                principalColumn: "SocialId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
