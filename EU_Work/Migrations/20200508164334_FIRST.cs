using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EU_Work.Migrations
{
    public partial class FIRST : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TaksForms",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(nullable: true),
                    sname = table.Column<string>(nullable: true),
                    bd = table.Column<string>(nullable: true),
                    phone = table.Column<string>(nullable: true),
                    email = table.Column<string>(nullable: true),
                    officilal_ukr_work_any_time = table.Column<bool>(nullable: false),
                    officilal_eu_work_any_time = table.Column<bool>(nullable: false),
                    officilal_ukr_work_now = table.Column<bool>(nullable: false),
                    officilal_eu_work_now = table.Column<bool>(nullable: false),
                    presonal_data_agree = table.Column<bool>(nullable: false),
                    dateTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaksForms", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "WorkForms",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(nullable: true),
                    sname = table.Column<string>(nullable: true),
                    bd = table.Column<string>(nullable: true),
                    addres_official = table.Column<string>(nullable: true),
                    phone = table.Column<string>(nullable: true),
                    email = table.Column<string>(nullable: true),
                    officilal_ukr_work_any_time = table.Column<bool>(nullable: false),
                    officilal_eu_work_any_time = table.Column<bool>(nullable: false),
                    officilal_ukr_work_now = table.Column<bool>(nullable: false),
                    officilal_eu_work_now = table.Column<bool>(nullable: false),
                    about = table.Column<string>(nullable: true),
                    presonal_data_agree = table.Column<bool>(nullable: false),
                    dateTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkForms", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "WorkInfo",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Country = table.Column<string>(nullable: true),
                    AvrSalery = table.Column<string>(nullable: true),
                    Start = table.Column<string>(nullable: true),
                    Stop = table.Column<string>(nullable: true),
                    OffenThinks = table.Column<bool>(nullable: false),
                    dateTime = table.Column<DateTime>(nullable: false),
                    TaksFormid = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkInfo", x => x.id);
                    table.ForeignKey(
                        name: "FK_WorkInfo_TaksForms_TaksFormid",
                        column: x => x.TaksFormid,
                        principalTable: "TaksForms",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EducationInfo",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Institution = table.Column<string>(nullable: true),
                    Faculty = table.Column<string>(nullable: true),
                    Form = table.Column<string>(nullable: true),
                    Start = table.Column<string>(nullable: true),
                    Stop = table.Column<string>(nullable: true),
                    dateTime = table.Column<DateTime>(nullable: false),
                    WorkFormid = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EducationInfo", x => x.id);
                    table.ForeignKey(
                        name: "FK_EducationInfo_WorkForms_WorkFormid",
                        column: x => x.WorkFormid,
                        principalTable: "WorkForms",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EducationInfo_WorkFormid",
                table: "EducationInfo",
                column: "WorkFormid");

            migrationBuilder.CreateIndex(
                name: "IX_WorkInfo_TaksFormid",
                table: "WorkInfo",
                column: "TaksFormid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EducationInfo");

            migrationBuilder.DropTable(
                name: "WorkInfo");

            migrationBuilder.DropTable(
                name: "WorkForms");

            migrationBuilder.DropTable(
                name: "TaksForms");
        }
    }
}
