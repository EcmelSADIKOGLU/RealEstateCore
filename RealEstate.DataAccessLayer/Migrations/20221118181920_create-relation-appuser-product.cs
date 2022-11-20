using Microsoft.EntityFrameworkCore.Migrations;

namespace RealEstate.DataAccessLayer.Migrations
{
    public partial class createrelationappuserproduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AppUserID",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Products_AppUserID",
                table: "Products",
                column: "AppUserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_AspNetUsers_AppUserID",
                table: "Products",
                column: "AppUserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_AspNetUsers_AppUserID",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_AppUserID",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "AppUserID",
                table: "Products");
        }
    }
}
