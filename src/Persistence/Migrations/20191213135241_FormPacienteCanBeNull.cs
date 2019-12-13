using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class FormPacienteCanBeNull : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Paciente_Forms",
                schema: "Oncologia",
                table: "FormField");

            migrationBuilder.AlterColumn<int>(
                name: "PacienteId",
                schema: "Oncologia",
                table: "FormField",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Paciente_Forms",
                schema: "Oncologia",
                table: "FormField",
                column: "PacienteId",
                principalSchema: "Oncologia",
                principalTable: "Paciente",
                principalColumn: "PacienteID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Paciente_Forms",
                schema: "Oncologia",
                table: "FormField");

            migrationBuilder.AlterColumn<int>(
                name: "PacienteId",
                schema: "Oncologia",
                table: "FormField",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Paciente_Forms",
                schema: "Oncologia",
                table: "FormField",
                column: "PacienteId",
                principalSchema: "Oncologia",
                principalTable: "Paciente",
                principalColumn: "PacienteID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
