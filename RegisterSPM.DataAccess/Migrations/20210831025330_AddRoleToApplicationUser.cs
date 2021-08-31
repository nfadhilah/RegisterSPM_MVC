using Microsoft.EntityFrameworkCore.Migrations;

namespace RegisterSPM.DataAccess.Migrations
{
    public partial class AddRoleToApplicationUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1b6f4c7b-3073-4a17-938c-bfebb908a1b0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5f8695dd-b24e-4565-9dcd-85a9eff77cce");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6b924686-b4f4-4b13-a42c-26ffed581104");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "91e51fa2-0857-4bb6-95eb-fcbd03e7ecf0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d5039926-93c0-46ce-b71c-042d182f25db");

            migrationBuilder.AddColumn<string>(
                name: "Role",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "Role",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "91e51fa2-0857-4bb6-95eb-fcbd03e7ecf0", "11d8156c-d318-45d2-a232-20170dda0694", "Admin", "ADMIN" },
                    { "d5039926-93c0-46ce-b71c-042d182f25db", "8844d5b1-dd2d-4e99-8c24-6cb46f7054c3", "SA", "SA" },
                    { "6b924686-b4f4-4b13-a42c-26ffed581104", "21e9fa29-5a25-435b-b47e-0bed1f8e93f3", "Registrator", "REGISTRATOR" },
                    { "1b6f4c7b-3073-4a17-938c-bfebb908a1b0", "efa64fa7-be1e-4c49-99e5-23be19f5b5db", "Verifikator", "VERIFIKATOR" },
                    { "5f8695dd-b24e-4565-9dcd-85a9eff77cce", "4e45aa2b-253f-40d3-9ad6-091b4aa33b63", "Approver", "APPROVER" }
                });
        }
    }
}
