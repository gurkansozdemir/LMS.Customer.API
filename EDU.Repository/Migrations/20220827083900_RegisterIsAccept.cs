using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EDU.Repository.Migrations
{
    public partial class RegisterIsAccept : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsAccept",
                table: "Registers",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsAccept",
                table: "Registers");
        }
    }
}
