using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace covid_19.Migrations
{
    public partial class CovidTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PeopleWithCovids",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Country = table.Column<string>(nullable: false),
                    TotalCases = table.Column<int>(nullable: false),
                    NewCases = table.Column<int>(nullable: false),
                    TotalDeaths = table.Column<int>(nullable: false),
                    TotalRecovered = table.Column<int>(nullable: false),
                    ActiveCases = table.Column<int>(nullable: false),
                    SeriousCritical = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PeopleWithCovids", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PeopleWithCovids");
        }
    }
}
