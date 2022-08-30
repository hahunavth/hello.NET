using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CopyNotionApi3.Migrations
{
    public partial class JWTToken2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserName",
                table: "UserRefreshToken",
                newName: "Email");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Email",
                table: "UserRefreshToken",
                newName: "UserName");
        }
    }
}
