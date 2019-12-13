using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class AddingFormFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Value",
                schema: "Oncologia",
                table: "FormField",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "Columns",
                schema: "Oncologia",
                table: "FormField",
                nullable: true,
                defaultValue: 12);

            migrationBuilder.AddColumn<string>(
                name: "FormName",
                schema: "Oncologia",
                table: "FormField",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Columns",
                schema: "Oncologia",
                table: "FormField");

            migrationBuilder.DropColumn(
                name: "FormName",
                schema: "Oncologia",
                table: "FormField");

            migrationBuilder.AlterColumn<int>(
                name: "Value",
                schema: "Oncologia",
                table: "FormField",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
