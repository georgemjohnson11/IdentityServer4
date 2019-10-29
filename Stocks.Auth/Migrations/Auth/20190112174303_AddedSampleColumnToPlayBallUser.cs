using Microsoft.EntityFrameworkCore.Migrations;

namespace Stocks.Auth.Data.Migrations.Auth
{
    public partial class AddedSampleColumnToStocksUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Sample",
                schema: "public",
                table: "AspNetUsers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Sample",
                schema: "public",
                table: "AspNetUsers");
        }
    }
}
