using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Data.Migrations
{
    public partial class d : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "results",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MontantDachat = table.Column<double>(nullable: false),
                    FraisDachat = table.Column<double>(nullable: false),
                    FondPropre = table.Column<double>(nullable: false),
                    FraisDhypotheque = table.Column<double>(nullable: false),
                    Mensualite = table.Column<double>(nullable: false),
                    MentantEmpBrut = table.Column<double>(nullable: false),
                    MentantEmpNet = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_results", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "results");
        }
    }
}
