using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjektTemperatur.Migrations
{
    public partial class New1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Datavardes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    datum = table.Column<DateTime>(type: "datetime2", nullable: false),
                    plats = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    temp = table.Column<float>(type: "real", nullable: false),
                    luftfuktighet = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Datavardes", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Datavardes");
        }
    }
}
