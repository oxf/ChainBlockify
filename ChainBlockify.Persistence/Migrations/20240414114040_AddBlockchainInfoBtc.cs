using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ChainBlockify.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddBlockchainInfoBtc : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BlockchainInfoBtcDbSet",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HighFeePerKB = table.Column<int>(type: "int", nullable: false),
                    MediumFeePerKB = table.Column<int>(type: "int", nullable: false),
                    LowFeePerKB = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Height = table.Column<int>(type: "int", nullable: false),
                    Hash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LatestUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PreviousHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PreviousUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PeerCount = table.Column<int>(type: "int", nullable: false),
                    UnconfirmedCount = table.Column<int>(type: "int", nullable: false),
                    LastForkHeight = table.Column<int>(type: "int", nullable: false),
                    LastForkHash = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlockchainInfoBtcDbSet", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BlockchainInfoBtcDbSet");
        }
    }
}
