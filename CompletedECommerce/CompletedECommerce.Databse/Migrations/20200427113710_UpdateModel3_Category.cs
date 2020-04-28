using Microsoft.EntityFrameworkCore.Migrations;

namespace CompletedECommerce.Databse.Migrations
{
    public partial class UpdateModel3_Category : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "Status",
                table: "Categories",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "Status",
                table: "Categories",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool));
        }
    }
}
