using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Qian.Shop.Core.Migrations
{
    public partial class UpdBooks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "AddTime",
                table: "Books",
                type: "datetime",
                nullable: false,
                defaultValueSql: "(getdate())");

            migrationBuilder.AddColumn<bool>(
                name: "BookState",
                table: "Books",
                type: "bit",
                nullable: false,
                defaultValueSql: "(1)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AddTime",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "BookState",
                table: "Books");
        }
    }
}
