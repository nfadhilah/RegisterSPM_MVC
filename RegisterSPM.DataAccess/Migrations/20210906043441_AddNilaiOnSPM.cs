using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RegisterSPM.DataAccess.Migrations
{
    public partial class AddNilaiOnSPM : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_SPM_OPD_NoSPM",
                table: "SPM");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6b387985-7df6-4462-8cb7-25ed907577cf");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b7cfcc51-57c9-4044-ae0f-7f3d5be9ad5f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d0d9cb7c-994d-42f0-bead-9b145e188c8e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d1b0ee02-4db5-41e0-87bd-13aaf9761a4c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d687ba05-ed69-45d8-b3ee-0f9f3bdf1142");

            migrationBuilder.AddColumn<decimal>(
                name: "Nilai",
                table: "SPM",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "RejectedBy",
                table: "SPM",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "RejectedDate",
                table: "SPM",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UnitKey",
                table: "SPM",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "d8a789b3-351b-48f8-95b0-92345b383057", "22f77f3d-9076-494f-a7b7-c3ed037b249c", "Admin", "ADMIN" },
                    { "b04e0587-4182-4cf9-84b2-ec3b159683ee", "913cd0e2-9de9-47f2-810a-26f2848a7ef4", "SA", "SA" },
                    { "781206ca-25ed-4d27-bc11-7fdd2991a22e", "f96f2520-b504-40e0-af83-4bd75bc9cec1", "Registrator", "REGISTRATOR" },
                    { "8e7f2aca-781a-452f-809a-beb9c68ce9c4", "3aadf0f4-c2d0-4b4c-89ea-12b759717702", "Verifikator", "VERIFIKATOR" },
                    { "42780693-f7bb-4142-829a-ee2631a1d544", "1d6e81f8-e99d-4edb-9484-7b81ec69460f", "Approver", "APPROVER" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_SPM_OPD_NoSPM_UnitKey",
                table: "SPM",
                columns: new[] { "OPD", "NoSPM", "UnitKey" },
                unique: true,
                filter: "[OPD] IS NOT NULL AND [NoSPM] IS NOT NULL AND [UnitKey] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_SPM_OPD_NoSPM_UnitKey",
                table: "SPM");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "42780693-f7bb-4142-829a-ee2631a1d544");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "781206ca-25ed-4d27-bc11-7fdd2991a22e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8e7f2aca-781a-452f-809a-beb9c68ce9c4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b04e0587-4182-4cf9-84b2-ec3b159683ee");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d8a789b3-351b-48f8-95b0-92345b383057");

            migrationBuilder.DropColumn(
                name: "Nilai",
                table: "SPM");

            migrationBuilder.DropColumn(
                name: "RejectedBy",
                table: "SPM");

            migrationBuilder.DropColumn(
                name: "RejectedDate",
                table: "SPM");

            migrationBuilder.DropColumn(
                name: "UnitKey",
                table: "SPM");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "d687ba05-ed69-45d8-b3ee-0f9f3bdf1142", "70b52d85-47bf-415e-bcf9-983a2af11a5b", "Admin", "ADMIN" },
                    { "b7cfcc51-57c9-4044-ae0f-7f3d5be9ad5f", "471e9c2e-301c-499b-ab91-1ce85ed1721e", "SA", "SA" },
                    { "d0d9cb7c-994d-42f0-bead-9b145e188c8e", "a4b4aa09-603e-4de7-9bbe-433a10d2f610", "Registrator", "REGISTRATOR" },
                    { "6b387985-7df6-4462-8cb7-25ed907577cf", "5daa54ae-e50b-4960-b4ab-cecaad37f152", "Verifikator", "VERIFIKATOR" },
                    { "d1b0ee02-4db5-41e0-87bd-13aaf9761a4c", "befdb852-c42e-4328-a16d-e2dcbde779eb", "Approver", "APPROVER" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_SPM_OPD_NoSPM",
                table: "SPM",
                columns: new[] { "OPD", "NoSPM" },
                unique: true,
                filter: "[OPD] IS NOT NULL AND [NoSPM] IS NOT NULL");
        }
    }
}
