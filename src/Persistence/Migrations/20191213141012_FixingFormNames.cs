using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class FixingFormNames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Columns",
                schema: "Oncologia",
                table: "FormField");

            migrationBuilder.DropColumn(
                name: "Key",
                schema: "Oncologia",
                table: "FormField");

            migrationBuilder.DropColumn(
                name: "Value",
                schema: "Oncologia",
                table: "FormField");

            migrationBuilder.RenameColumn(
                name: "Required",
                schema: "Oncologia",
                table: "FormField",
                newName: "RequiredField");

            migrationBuilder.AddColumn<int>(
                name: "ColumnsSize",
                schema: "Oncologia",
                table: "FormField",
                nullable: true,
                defaultValue: 12);

            migrationBuilder.AddColumn<string>(
                name: "KeyField",
                schema: "Oncologia",
                table: "FormField",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ValueField",
                schema: "Oncologia",
                table: "FormField",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ColumnsSize",
                schema: "Oncologia",
                table: "FormField");

            migrationBuilder.DropColumn(
                name: "KeyField",
                schema: "Oncologia",
                table: "FormField");

            migrationBuilder.DropColumn(
                name: "ValueField",
                schema: "Oncologia",
                table: "FormField");

            migrationBuilder.RenameColumn(
                name: "RequiredField",
                schema: "Oncologia",
                table: "FormField",
                newName: "Required");

            migrationBuilder.AddColumn<int>(
                name: "Columns",
                schema: "Oncologia",
                table: "FormField",
                type: "int",
                nullable: true,
                defaultValue: 12);

            migrationBuilder.AddColumn<string>(
                name: "Key",
                schema: "Oncologia",
                table: "FormField",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Value",
                schema: "Oncologia",
                table: "FormField",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
