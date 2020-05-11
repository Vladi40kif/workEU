using Microsoft.EntityFrameworkCore.Migrations;

namespace EU_Work.Migrations
{
    public partial class Third : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EducationInfo_WorkForms_WorkFormid",
                table: "EducationInfo");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkInfo_TaksForms_TaksFormid",
                table: "WorkInfo");

            migrationBuilder.RenameColumn(
                name: "TaksFormid",
                table: "WorkInfo",
                newName: "taksFormid");

            migrationBuilder.RenameIndex(
                name: "IX_WorkInfo_TaksFormid",
                table: "WorkInfo",
                newName: "IX_WorkInfo_taksFormid");

            migrationBuilder.RenameColumn(
                name: "WorkFormid",
                table: "EducationInfo",
                newName: "workFormid");

            migrationBuilder.RenameIndex(
                name: "IX_EducationInfo_WorkFormid",
                table: "EducationInfo",
                newName: "IX_EducationInfo_workFormid");

            migrationBuilder.AddForeignKey(
                name: "FK_EducationInfo_WorkForms_workFormid",
                table: "EducationInfo",
                column: "workFormid",
                principalTable: "WorkForms",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkInfo_TaksForms_taksFormid",
                table: "WorkInfo",
                column: "taksFormid",
                principalTable: "TaksForms",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EducationInfo_WorkForms_workFormid",
                table: "EducationInfo");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkInfo_TaksForms_taksFormid",
                table: "WorkInfo");

            migrationBuilder.RenameColumn(
                name: "taksFormid",
                table: "WorkInfo",
                newName: "TaksFormid");

            migrationBuilder.RenameIndex(
                name: "IX_WorkInfo_taksFormid",
                table: "WorkInfo",
                newName: "IX_WorkInfo_TaksFormid");

            migrationBuilder.RenameColumn(
                name: "workFormid",
                table: "EducationInfo",
                newName: "WorkFormid");

            migrationBuilder.RenameIndex(
                name: "IX_EducationInfo_workFormid",
                table: "EducationInfo",
                newName: "IX_EducationInfo_WorkFormid");

            migrationBuilder.AddForeignKey(
                name: "FK_EducationInfo_WorkForms_WorkFormid",
                table: "EducationInfo",
                column: "WorkFormid",
                principalTable: "WorkForms",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkInfo_TaksForms_TaksFormid",
                table: "WorkInfo",
                column: "TaksFormid",
                principalTable: "TaksForms",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
