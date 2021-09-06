using Microsoft.EntityFrameworkCore.Migrations;

namespace RegisterSPM.DataAccess.Migrations
{
    public partial class AddChecklistSPMToDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateTable(
                name: "ChecklistSPM",
                columns: table => new
                {
                    SPMId = table.Column<int>(type: "int", nullable: false),
                    ChecklistId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChecklistSPM", x => new { x.ChecklistId, x.SPMId });
                    table.ForeignKey(
                        name: "FK_ChecklistSPM_Checklist_ChecklistId",
                        column: x => x.ChecklistId,
                        principalTable: "Checklist",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChecklistSPM_SPM_SPMId",
                        column: x => x.SPMId,
                        principalTable: "SPM",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "4509de54-f9b8-43ec-bc99-660157c0f37e", "615b17d8-385d-477a-bb52-e714aa5841ef", "Admin", "ADMIN" },
                    { "50340e58-1771-4085-a289-a4de775316a0", "515ad828-0751-4e4e-98d3-6ad3dce7b646", "SA", "SA" },
                    { "ad924998-ceb3-4a4d-bbca-8076306a51de", "9c98df05-de5f-4a0a-8d4d-3de995711a89", "Registrator", "REGISTRATOR" },
                    { "5e41123d-5e2a-4f18-93f2-36946b9e891e", "64c6a13c-7334-4c47-a035-7c3f32d6b957", "Verifikator", "VERIFIKATOR" },
                    { "be982b9a-2d2d-4cc4-8794-a6d93099951a", "72ade860-efef-4862-8893-65f3a97caf96", "Approver", "APPROVER" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChecklistSPM_SPMId",
                table: "ChecklistSPM",
                column: "SPMId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChecklistSPM");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4509de54-f9b8-43ec-bc99-660157c0f37e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "50340e58-1771-4085-a289-a4de775316a0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5e41123d-5e2a-4f18-93f2-36946b9e891e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ad924998-ceb3-4a4d-bbca-8076306a51de");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "be982b9a-2d2d-4cc4-8794-a6d93099951a");

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
        }
    }
}
