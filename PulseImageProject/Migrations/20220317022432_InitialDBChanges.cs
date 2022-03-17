using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PulseImageProject.Migrations
{
    public partial class InitialDBChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    ImageText = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    ImageName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateConverted = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Images");
        }
    }
}
