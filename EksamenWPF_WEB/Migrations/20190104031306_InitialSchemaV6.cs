using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EksamenWPF_WEB.Migrations
{
    public partial class InitialSchemaV6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "JobReports",
                columns: table => new
                {
                    JobReportId = table.Column<int>(nullable: false),
                    Job = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    Text = table.Column<string>(nullable: true),
                    Cost = table.Column<int>(nullable: false),
                    ModelId = table.Column<int>(nullable: false),
                    Id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobReports", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JobReports_Models_Id",
                        column: x => x.Id,
                        principalTable: "Models",
                        principalColumn: "ModelId",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "JobReports");
        }
    }
}
