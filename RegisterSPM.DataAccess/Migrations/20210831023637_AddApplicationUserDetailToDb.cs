using Microsoft.EntityFrameworkCore.Migrations;

namespace RegisterSPM.DataAccess.Migrations
{
    public partial class AddApplicationUserDetailToDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "31b84946-1a90-4052-9432-c6296fd78219");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "408611c6-1206-466d-a57b-eda73e644cc6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "803f9e3f-9a91-4ba6-824a-46daf6a0d3e1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9441d2b2-7cac-4ad5-9dd4-9a6e0ef0a618");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9bb30555-24f3-4934-9d6a-108b9da70bfa");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Jabatan",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NIP",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Nama",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Jabatan",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "NIP",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Nama",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "803f9e3f-9a91-4ba6-824a-46daf6a0d3e1", "5d436174-f112-47bc-aa1c-d3e571a14223", "Admin", "ADMIN" },
                    { "9441d2b2-7cac-4ad5-9dd4-9a6e0ef0a618", "d40f4b47-e747-4df8-b495-583f085547df", "SA", "SA" },
                    { "9bb30555-24f3-4934-9d6a-108b9da70bfa", "a5fb75b4-b25f-4913-a717-9100125ff24e", "Registrator", "REGISTRATOR" },
                    { "408611c6-1206-466d-a57b-eda73e644cc6", "c9240699-bd56-47c5-a624-b2bfdb5f2d74", "Verifikator", "VERIFIKATOR" },
                    { "31b84946-1a90-4052-9432-c6296fd78219", "e5068b06-6646-42ab-ada0-7b2fedf3f944", "Approver", "APPROVER" }
                });
        }
    }
}
