using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Keko.SwaggerApi.Migrations
{
    public partial class addTargetTimeintoTodoItem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "TargetTime",
                table: "TodoItem",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TargetTime",
                table: "TodoItem");
        }
    }
}
