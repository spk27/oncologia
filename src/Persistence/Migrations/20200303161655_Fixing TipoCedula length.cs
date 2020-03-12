using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class FixingTipoCedulalength : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "TipoCedula",
                schema: "Oncologia",
                table: "Paciente",
                maxLength: 5,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "char(2)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "TipoCedula",
                schema: "Oncologia",
                table: "Paciente",
                type: "char(2)",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 5,
                oldNullable: true);
        }
    }
}
