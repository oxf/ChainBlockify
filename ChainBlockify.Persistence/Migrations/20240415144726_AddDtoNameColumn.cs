using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ChainBlockify.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddDtoNameColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DtoName",
                table: "BlockchainBlockchainSource",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DtoName",
                table: "BlockchainBlockchainSource");
        }
    }
}
