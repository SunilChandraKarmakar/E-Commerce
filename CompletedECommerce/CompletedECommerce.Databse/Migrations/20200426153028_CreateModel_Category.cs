using Microsoft.EntityFrameworkCore.Migrations;

namespace CompletedECommerce.Databse.Migrations
{
    public partial class CreateModel_Category : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RoleAccounts_Accounts_AccountId",
                table: "RoleAccounts");

            migrationBuilder.DropForeignKey(
                name: "FK_RoleAccounts_Roles_RoleId",
                table: "RoleAccounts");

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    CategoryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Categories_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Categories_CategoryId",
                table: "Categories",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_Name",
                table: "Categories",
                column: "Name",
                unique: true,
                filter: "[Name] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_RoleAccounts_Accounts_AccountId",
                table: "RoleAccounts",
                column: "AccountId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RoleAccounts_Roles_RoleId",
                table: "RoleAccounts",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RoleAccounts_Accounts_AccountId",
                table: "RoleAccounts");

            migrationBuilder.DropForeignKey(
                name: "FK_RoleAccounts_Roles_RoleId",
                table: "RoleAccounts");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.AddForeignKey(
                name: "FK_RoleAccounts_Accounts_AccountId",
                table: "RoleAccounts",
                column: "AccountId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RoleAccounts_Roles_RoleId",
                table: "RoleAccounts",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
