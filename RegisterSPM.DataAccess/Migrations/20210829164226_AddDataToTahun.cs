using Microsoft.EntityFrameworkCore.Migrations;

namespace RegisterSPM.DataAccess.Migrations
{
    public partial class AddDataToTahun : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5c047807-b909-4623-b92e-b332c57df14b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6a06a7a1-1c38-435b-a804-590dec4fbb32");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9f837b9d-0999-4e7d-a989-c09d90f20ba0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b8a0e5b4-238b-4dfe-8305-0bac6480dabc");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bc1eca6b-55f0-4e97-b79c-eb1c9ed1b32a");

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

            migrationBuilder.InsertData(
                table: "Tahun",
                columns: new[] { "Id", "Label", "SeqNo" },
                values: new object[] { 1, "2021", "00001" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DeleteData(
                table: "Tahun",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "b8a0e5b4-238b-4dfe-8305-0bac6480dabc", "3b484219-15bc-4ba8-a7cc-2b0cd5e49ee8", "Admin", "ADMIN" },
                    { "9f837b9d-0999-4e7d-a989-c09d90f20ba0", "cee57905-1e73-481a-997b-3fb1924aebe6", "SA", "SA" },
                    { "bc1eca6b-55f0-4e97-b79c-eb1c9ed1b32a", "a2882fa7-60bd-4a9e-a1bb-81cb02782b0e", "Registrator", "REGISTRATOR" },
                    { "6a06a7a1-1c38-435b-a804-590dec4fbb32", "e5698ec8-7724-4bc6-8330-045632229f85", "Verifikator", "VERIFIKATOR" },
                    { "5c047807-b909-4623-b92e-b332c57df14b", "0301e027-dc29-46a6-b65a-5df01ac14b13", "Approver", "APPROVER" }
                });
        }
    }
}
