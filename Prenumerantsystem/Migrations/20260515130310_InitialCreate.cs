using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Prenumerantsystem.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Prenumeranter",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Prenumerationsnummer = table.Column<int>(type: "integer", nullable: false),
                    Personnummer = table.Column<string>(type: "text", nullable: false),
                    Fornamn = table.Column<string>(type: "text", nullable: false),
                    Efternamn = table.Column<string>(type: "text", nullable: false),
                    Utdelningsadress = table.Column<string>(type: "text", nullable: false),
                    Postnummer = table.Column<string>(type: "text", nullable: false),
                    Ort = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prenumeranter", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Prenumeranter");
        }
    }
}
