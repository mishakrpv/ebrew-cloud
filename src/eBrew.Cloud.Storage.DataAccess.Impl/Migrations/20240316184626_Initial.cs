using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eBrew.Cloud.Storage.DataAccess.Impl.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Vaults",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vaults", x => new { x.Name, x.UserId });
                });

            migrationBuilder.CreateTable(
                name: "Secrets",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    VaultName = table.Column<string>(type: "character varying(100)", nullable: true),
                    VaultUserId = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Secrets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Secrets_Vaults_VaultName_VaultUserId",
                        columns: x => new { x.VaultName, x.VaultUserId },
                        principalTable: "Vaults",
                        principalColumns: new[] { "Name", "UserId" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Secrets_VaultName_VaultUserId",
                table: "Secrets",
                columns: new[] { "VaultName", "VaultUserId" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Secrets");

            migrationBuilder.DropTable(
                name: "Vaults");
        }
    }
}
