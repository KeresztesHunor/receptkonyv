using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Kategoriak",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nev = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kategoriak", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Receptek",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nev = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KatId = table.Column<int>(type: "int", nullable: false),
                    KepEleresiUt = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Leiras = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Receptek", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Receptek_Kategoriak_KatId",
                        column: x => x.KatId,
                        principalTable: "Kategoriak",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Receptek_KatId",
                table: "Receptek",
                column: "KatId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Receptek");

            migrationBuilder.DropTable(
                name: "Kategoriak");
        }
    }
}
