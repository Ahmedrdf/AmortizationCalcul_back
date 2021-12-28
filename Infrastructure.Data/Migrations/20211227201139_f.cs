using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Data.Migrations
{
    public partial class f : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Capital",
                table: "results",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "InteretAnnuel",
                table: "results",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "InteretMensuel",
                table: "results",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.CreateTable(
                name: "Amortissement",
                columns: table => new
                {
                    AmortissementId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Periode = table.Column<int>(nullable: false),
                    SoldeDebut = table.Column<double>(nullable: false),
                    Mensualite = table.Column<double>(nullable: false),
                    Interet = table.Column<double>(nullable: false),
                    CapitaleRembourse = table.Column<double>(nullable: false),
                    SoldeFin = table.Column<double>(nullable: false),
                    FirstResultsId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Amortissement", x => x.AmortissementId);
                    table.ForeignKey(
                        name: "FK_Amortissement_results_FirstResultsId",
                        column: x => x.FirstResultsId,
                        principalTable: "results",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Amortissement_FirstResultsId",
                table: "Amortissement",
                column: "FirstResultsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Amortissement");

            migrationBuilder.DropColumn(
                name: "Capital",
                table: "results");

            migrationBuilder.DropColumn(
                name: "InteretAnnuel",
                table: "results");

            migrationBuilder.DropColumn(
                name: "InteretMensuel",
                table: "results");
        }
    }
}
