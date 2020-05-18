using Microsoft.EntityFrameworkCore.Migrations;

namespace CompletedECommerce.Databse.Migrations
{
    public partial class UM_Account : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Accounts_Username_Email",
                table: "Accounts");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Accounts",
                maxLength: 1000,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "Accounts",
                maxLength: 14,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_Username_Email_Phone",
                table: "Accounts",
                columns: new[] { "Username", "Email", "Phone" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Accounts_Username_Email_Phone",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "Accounts");

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_Username_Email",
                table: "Accounts",
                columns: new[] { "Username", "Email" },
                unique: true);
        }
    }
}
