using Microsoft.EntityFrameworkCore.Migrations;

namespace G3L.Examples.NTier.DAL.Migrations
{
    public partial class ExtraField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.AddColumn<int>(
                name: "ShoeSize",
                table: "Visitors",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ShoeSize",
                table: "Visitors");
        }
    }
}
