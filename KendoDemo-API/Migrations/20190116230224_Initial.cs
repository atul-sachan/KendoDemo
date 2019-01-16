using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace KendoDemo.API.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Kendos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    About = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    Age = table.Column<int>(nullable: false),
                    Balance = table.Column<string>(nullable: true),
                    Company = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    EyeColor = table.Column<string>(nullable: true),
                    FavoriteFurit = table.Column<string>(nullable: true),
                    FullName = table.Column<string>(nullable: true),
                    Greeting = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    Phone = table.Column<string>(nullable: true),
                    Picture = table.Column<string>(nullable: true),
                    Registered = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kendos", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Kendos");
        }
    }
}
