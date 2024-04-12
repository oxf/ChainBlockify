using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ChainBlockify.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class First : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BlockchainDbSet",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlockchainDbSet", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BlockchainSourceDbSet",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlockchainSourceDbSet", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BlockchainBlockchainSourceDbSet",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BlockchainsId = table.Column<int>(type: "int", nullable: false),
                    BlockchainSourceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlockchainBlockchainSourceDbSet", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BlockchainBlockchainSourceDbSet_BlockchainDbSet_BlockchainsId",
                        column: x => x.BlockchainsId,
                        principalTable: "BlockchainDbSet",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BlockchainBlockchainSourceDbSet_BlockchainSourceDbSet_BlockchainSourceId",
                        column: x => x.BlockchainSourceId,
                        principalTable: "BlockchainSourceDbSet",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BlockchainBlockchainSourceDbSet_BlockchainSourceId",
                table: "BlockchainBlockchainSourceDbSet",
                column: "BlockchainSourceId");

            migrationBuilder.CreateIndex(
                name: "IX_BlockchainBlockchainSourceDbSet_BlockchainsId",
                table: "BlockchainBlockchainSourceDbSet",
                column: "BlockchainsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BlockchainBlockchainSourceDbSet");

            migrationBuilder.DropTable(
                name: "BlockchainDbSet");

            migrationBuilder.DropTable(
                name: "BlockchainSourceDbSet");
        }
    }
}
