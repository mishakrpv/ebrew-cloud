using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eBrew.Cloud.Storage.DataAccess.Impl.Migrations
{
    /// <inheritdoc />
    public partial class VaultAddDescription : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Vaults",
                type: "character varying(300)",
                maxLength: 300,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Vaults");
        }
    }
}
