using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExchangeRateChange.Infrastructure.Migrations
{
    public partial class updateProductTb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ExchangeName",
                schema: "dbo",
                table: "Product",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExchangeName",
                schema: "dbo",
                table: "Product");
        }
    }
}
