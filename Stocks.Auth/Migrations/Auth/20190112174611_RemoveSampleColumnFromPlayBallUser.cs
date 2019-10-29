using Microsoft.EntityFrameworkCore.Migrations;

namespace Stocks.Auth.Data.Migrations.Auth
{
    public partial class RemoveSampleColumnFromStocksUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Sample",
                schema: "public",
                table: "AspNetUsers");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Sample",
                schema: "public",
                table: "AspNetUsers",
                nullable: true);
        }
    }
}
