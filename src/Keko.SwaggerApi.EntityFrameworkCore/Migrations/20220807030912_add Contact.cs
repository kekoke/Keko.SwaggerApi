using Microsoft.EntityFrameworkCore.Migrations;

namespace Keko.SwaggerApi.Migrations
{
    public partial class addContact : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
               name: "Contact",
               columns: table => new
               {
                   Id = table.Column<int>(type: "int", nullable: false),
                   Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                   Phone = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
               },
               constraints: table =>
               {
                   table.PrimaryKey("PK_Contact", x => x.Id);
               });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
