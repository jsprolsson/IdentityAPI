using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Identity_API.DAL.Migrations.EldenRingWeapons
{
    public partial class addedWeaponOwnerIdToWeaponEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "WeaponOwnerId",
                table: "EldenRingWeapons",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WeaponOwnerId",
                table: "EldenRingWeapons");
        }
    }
}
