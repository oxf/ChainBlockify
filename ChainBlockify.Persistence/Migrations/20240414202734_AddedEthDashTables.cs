using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ChainBlockify.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddedEthDashTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BlockchainInfoDash",
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
                    table.PrimaryKey("PK_BlockchainInfoDash", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BlockchainInfoEth",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HighGasPrice = table.Column<long>(type: "bigint", nullable: false),
                    MediumGasPrice = table.Column<long>(type: "bigint", nullable: false),
                    LowGasPrice = table.Column<long>(type: "bigint", nullable: false),
                    HighPriorityFee = table.Column<long>(type: "bigint", nullable: false),
                    MediumPriorityFee = table.Column<long>(type: "bigint", nullable: false),
                    LowPriorityFee = table.Column<long>(type: "bigint", nullable: false),
                    BaseFee = table.Column<long>(type: "bigint", nullable: false),
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
                    table.PrimaryKey("PK_BlockchainInfoEth", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BlockchainInfoDash");

            migrationBuilder.DropTable(
                name: "BlockchainInfoEth");
        }
    }
}
