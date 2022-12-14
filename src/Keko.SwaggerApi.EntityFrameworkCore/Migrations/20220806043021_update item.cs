using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Keko.SwaggerApi.Migrations
{
    public partial class updateitem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
 
            migrationBuilder.AddColumn<DateTime>(
                name: "CreationTime",
                table: "TodoItem",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Seq",
                table: "TodoItem",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreationTime",
                table: "TodoItem");

            migrationBuilder.DropColumn(
                name: "Seq",
                table: "TodoItem");

        
        }
    }
}
