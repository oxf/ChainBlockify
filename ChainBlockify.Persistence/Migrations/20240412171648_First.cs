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
                name: "Blockchain",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Blockchain", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BlockchainSource",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlockchainSource", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BlockchainBlockchainSource",
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
                    table.PrimaryKey("PK_BlockchainBlockchainSource", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BlockchainBlockchainSource_BlockchainSource_BlockchainSourceId",
                        column: x => x.BlockchainSourceId,
                        principalTable: "BlockchainSource",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BlockchainBlockchainSource_Blockchain_BlockchainsId",
                        column: x => x.BlockchainsId,
                        principalTable: "Blockchain",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BlockchainBlockchainSource_BlockchainsId",
                table: "BlockchainBlockchainSource",
                column: "BlockchainsId");

            migrationBuilder.CreateIndex(
                name: "IX_BlockchainBlockchainSource_BlockchainSourceId",
                table: "BlockchainBlockchainSource",
                column: "BlockchainSourceId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BlockchainBlockchainSource");

            migrationBuilder.DropTable(
                name: "BlockchainSource");

            migrationBuilder.DropTable(
                name: "Blockchain");
        }
    }
}
