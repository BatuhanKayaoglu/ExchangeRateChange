using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExchangeRateChange.Infrastructure.Migrations
{
    public partial class updateExchangeTypeToProductTbl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ExchangeName",
                schema: "dbo",
                table: "Product",
                newName: "ExchangeType");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ExchangeType",
                schema: "dbo",
                table: "Product",
                newName: "ExchangeName");
        }
    }
}
