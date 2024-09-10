using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ecf.Vgames.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "publisher",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_publisher", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "gizmondo",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    game = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    year = table.Column<int>(type: "int", nullable: false),
                    dev = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    publisher_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_gizmondo", x => x.id);
                    table.ForeignKey(
                        name: "FK_gizmondo_publisher_publisher_id",
                        column: x => x.publisher_id,
                        principalTable: "publisher",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_gizmondo_publisher_id",
                table: "gizmondo",
                column: "publisher_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "gizmondo");

            migrationBuilder.DropTable(
                name: "publisher");
        }
    }
}
