﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExchangeRateChange.Infrastructure.Migrations
{
    public partial class updateremove : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExchangeSellRatePrice",
                schema: "dbo",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "NewExchangePrice",
                schema: "dbo",
                table: "Product");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "ExchangeSellRatePrice",
                schema: "dbo",
                table: "Product",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "NewExchangePrice",
                schema: "dbo",
                table: "Product",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
