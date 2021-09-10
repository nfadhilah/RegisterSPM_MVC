using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RegisterSPM.DataAccess.Migrations
{
    public partial class ChangeCreatedDateToDateTimeOnSPM : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "19b30aa5-3912-440a-8a64-113d6f504793");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "808cad2c-9253-4c59-acd3-b9cbf0fc1d05");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b9a421be-c00b-4936-a827-88952eaeec73");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d62c7742-76e5-4a10-9c0b-a341b4681ab5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d94445f9-fa22-47f8-b1c5-a3656098cc13");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
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
                    { "a302bc2d-d755-4ad9-bac5-93271d0e83b0", "68f21122-278f-4cdb-a1fe-0c3f9e1e8307", "Admin", "ADMIN" },
                    { "eb38f9cf-d618-46bc-a834-17928c94f155", "75ae93a9-5426-4adf-89a6-02bdddce1ffb", "SA", "SA" },
                    { "ed8a5e31-3984-48b2-a526-6adf4f94c485", "68b65b0a-f1e3-4996-b69f-5d8a9d4afea2", "Registrator", "REGISTRATOR" },
                    { "11ff67fa-3eaa-46dc-b3ef-0bdc7b0570a2", "70295885-389c-45c3-b35b-cd8e53d14f3d", "Verifikator", "VERIFIKATOR" },
                    { "e5c7d747-2256-47b3-a01f-a1c3b0f8896f", "7f5bdf08-1d21-4762-ac6c-927740b60cfd", "Approver", "APPROVER" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
                name: "CreatedDate",
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
                    { "b9a421be-c00b-4936-a827-88952eaeec73", "5b4adbbc-64e8-47d0-9bfb-e8fb491de8c4", "Admin", "ADMIN" },
                    { "808cad2c-9253-4c59-acd3-b9cbf0fc1d05", "c8cbe351-b0c9-4bd9-b701-4c64d235b93b", "SA", "SA" },
                    { "19b30aa5-3912-440a-8a64-113d6f504793", "6853ad38-2b37-4172-b5c8-7f003ea518f8", "Registrator", "REGISTRATOR" },
                    { "d62c7742-76e5-4a10-9c0b-a341b4681ab5", "f7e381ca-5c01-4e75-b01c-1f1f9ea51f7b", "Verifikator", "VERIFIKATOR" },
                    { "d94445f9-fa22-47f8-b1c5-a3656098cc13", "8a6dc435-ae16-499d-aeb3-68658a98df0f", "Approver", "APPROVER" }
                });
        }
    }
}
