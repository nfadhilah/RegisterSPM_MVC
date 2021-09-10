using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RegisterSPM.DataAccess.Migrations
{
    public partial class ChangeDateTime2ToDateTime : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "11ff67fa-3eaa-46dc-b3ef-0bdc7b0570a2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a302bc2d-d755-4ad9-bac5-93271d0e83b0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e5c7d747-2256-47b3-a01f-a1c3b0f8896f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "eb38f9cf-d618-46bc-a834-17928c94f155");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ed8a5e31-3984-48b2-a526-6adf4f94c485");

            migrationBuilder.AlterColumn<DateTime>(
                name: "VerifiedDate",
                table: "SPM",
                type: "datetime",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "RejectedDate",
                table: "SPM",
                type: "datetime",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ApprovedDate",
                table: "SPM",
                type: "datetime",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "9cbba6a1-5581-4f1f-a1b3-b38501d68f1b", "aa251ba7-f6e7-461b-80fa-d700cc82a0ef", "Admin", "ADMIN" },
                    { "3dd6b657-0d7d-48c9-aeec-4d847d6999db", "1e1a2833-3ff3-4330-8c2c-ab9ba7b14248", "SA", "SA" },
                    { "f4744d77-b829-4ac2-b057-59075cd31257", "eacec4d3-f7f1-452e-af46-7f6eea26c6b6", "Registrator", "REGISTRATOR" },
                    { "af4611a5-c67b-42b6-8b9f-3b67a86ef429", "afd30bf7-4957-4b0b-85f4-af3d06603b4e", "Verifikator", "VERIFIKATOR" },
                    { "2e5e2696-2e44-4eca-bd13-1144922f9553", "5c7af4de-7583-4a75-8c86-3842b7c2322a", "Approver", "APPROVER" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2e5e2696-2e44-4eca-bd13-1144922f9553");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3dd6b657-0d7d-48c9-aeec-4d847d6999db");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9cbba6a1-5581-4f1f-a1b3-b38501d68f1b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "af4611a5-c67b-42b6-8b9f-3b67a86ef429");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f4744d77-b829-4ac2-b057-59075cd31257");

            migrationBuilder.AlterColumn<DateTime>(
                name: "VerifiedDate",
                table: "SPM",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "RejectedDate",
                table: "SPM",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ApprovedDate",
                table: "SPM",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "a302bc2d-d755-4ad9-bac5-93271d0e83b0", "68f21122-278f-4cdb-a1fe-0c3f9e1e8307", "Admin", "ADMIN" },
                    { "eb38f9cf-d618-46bc-a834-17928c94f155", "75ae93a9-5426-4adf-89a6-02bdddce1ffb", "SA", "SA" },
                    { "ed8a5e31-3984-48b2-a526-6adf4f94c485", "68b65b0a-f1e3-4996-b69f-5d8a9d4afea2", "Registrator", "REGISTRATOR" },
                    { "11ff67fa-3eaa-46dc-b3ef-0bdc7b0570a2", "70295885-389c-45c3-b35b-cd8e53d14f3d", "Verifikator", "VERIFIKATOR" },
                    { "e5c7d747-2256-47b3-a01f-a1c3b0f8896f", "7f5bdf08-1d21-4762-ac6c-927740b60cfd", "Approver", "APPROVER" }
                });
        }
    }
}
