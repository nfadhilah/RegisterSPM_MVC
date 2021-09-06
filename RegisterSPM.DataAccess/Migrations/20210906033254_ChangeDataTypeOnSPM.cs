using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RegisterSPM.DataAccess.Migrations
{
    public partial class ChangeDataTypeOnSPM : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0570e223-4c6e-432e-ab0c-7e38a2864567");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0cdc8477-dfe3-496a-abdc-53cdd0fb5a64");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3cf1d52c-8c2a-46c6-b7d7-c9968867e3a3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "87da8d3a-1c2b-4bea-b05d-2f609e4a1c46");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ae4274e4-f654-4908-b040-0873f6973581");

            migrationBuilder.AlterColumn<DateTime>(
                name: "VerifiedDate",
                table: "SPM",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DocStatus",
                table: "SPM",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "SPM",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ApprovedDate",
                table: "SPM",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AlterColumn<string>(
                name: "VerifiedDate",
                table: "SPM",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DocStatus",
                table: "SPM",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedDate",
                table: "SPM",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ApprovedDate",
                table: "SPM",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "ae4274e4-f654-4908-b040-0873f6973581", "28dda1a8-29b7-42e4-b894-e7e3bebe257a", "Admin", "ADMIN" },
                    { "0570e223-4c6e-432e-ab0c-7e38a2864567", "606fea19-c593-415d-b6ad-8e67877a5a23", "SA", "SA" },
                    { "87da8d3a-1c2b-4bea-b05d-2f609e4a1c46", "9ded930b-d056-4249-ac1e-5d77a404e794", "Registrator", "REGISTRATOR" },
                    { "3cf1d52c-8c2a-46c6-b7d7-c9968867e3a3", "a2ef868a-29c9-4a80-bd7d-35865305e1c2", "Verifikator", "VERIFIKATOR" },
                    { "0cdc8477-dfe3-496a-abdc-53cdd0fb5a64", "a8ad9284-b6d8-4850-ad89-36fd2979c637", "Approver", "APPROVER" }
                });
        }
    }
}
