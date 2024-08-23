using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExchangeRateChange.Infrastructure.Migrations
{
    public partial class requiredUpdateTbl5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "ExchangeSellRate",
                schema: "dbo",
                table: "Product",
                type: "decimal(18,2)",
                nullable: true,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "NewPrice",
                schema: "dbo",
                table: "Product",
                type: "decimal(18,2)",
                nullable: true,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExchangeSellRate",
                schema: "dbo",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "NewPrice",
                schema: "dbo",
                table: "Product");
        }
    }
}
