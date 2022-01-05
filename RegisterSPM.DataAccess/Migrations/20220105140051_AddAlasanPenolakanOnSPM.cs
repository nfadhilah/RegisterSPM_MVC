using Microsoft.EntityFrameworkCore.Migrations;

namespace RegisterSPM.DataAccess.Migrations
{
    public partial class AddAlasanPenolakanOnSPM : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AlasanPenolakan",
                table: "SPM",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AlasanPenolakan",
                table: "SPM");
        }
    }
}
