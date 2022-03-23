using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Identity_API.DAL.Migrations
{
    public partial class AddedOwnerOfWeaponId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OwnerOfWeaponId",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OwnerOfWeaponId",
                table: "AspNetUsers");
        }
    }
}
