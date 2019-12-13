using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class AddingValidations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Paciente_Forms",
                schema: "Oncologia",
                table: "FormField");

            migrationBuilder.DropIndex(
                name: "IX_FormField_PacienteId",
                schema: "Oncologia",
                table: "FormField");

            migrationBuilder.DropColumn(
                name: "PacienteId",
                schema: "Oncologia",
                table: "FormField");

            migrationBuilder.DropColumn(
                name: "RequiredField",
                schema: "Oncologia",
                table: "FormField");

            migrationBuilder.CreateTable(
                name: "Validation",
                schema: "Oncologia",
                columns: table => new
                {
                    ValidationID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Type = table.Column<string>(maxLength: 50, nullable: false),
                    ValidationValue = table.Column<string>(nullable: true),
                    Regex = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Validation", x => x.ValidationID);
                });

            migrationBuilder.CreateTable(
                name: "FormValidation",
                schema: "Oncologia",
                columns: table => new
                {
                    FormFieldID = table.Column<int>(nullable: false),
                    ValidationID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormValidation", x => new { x.FormFieldID, x.ValidationID });
                    table.ForeignKey(
                        name: "FK_FormField_Validations",
                        column: x => x.FormFieldID,
                        principalSchema: "Oncologia",
                        principalTable: "FormField",
                        principalColumn: "FormFieldID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Validation_FormFields",
                        column: x => x.ValidationID,
                        principalSchema: "Oncologia",
                        principalTable: "Validation",
                        principalColumn: "ValidationID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FormValidation_ValidationID",
                schema: "Oncologia",
                table: "FormValidation",
                column: "ValidationID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FormValidation",
                schema: "Oncologia");

            migrationBuilder.DropTable(
                name: "Validation",
                schema: "Oncologia");

            migrationBuilder.AddColumn<int>(
                name: "PacienteId",
                schema: "Oncologia",
                table: "FormField",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "RequiredField",
                schema: "Oncologia",
                table: "FormField",
                type: "bit",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_FormField_PacienteId",
                schema: "Oncologia",
                table: "FormField",
                column: "PacienteId");

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
    }
}
