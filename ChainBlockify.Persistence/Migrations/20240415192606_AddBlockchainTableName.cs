using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ChainBlockify.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddBlockchainTableName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DbTableName",
                table: "Blockchain",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DbTableName",
                table: "Blockchain");
        }
    }
}
