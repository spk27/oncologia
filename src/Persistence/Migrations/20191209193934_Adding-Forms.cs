using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class AddingForms : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FormField",
                schema: "Oncologia",
                columns: table => new
                {
                    FormFieldID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Key = table.Column<string>(maxLength: 50, nullable: false),
                    Value = table.Column<int>(nullable: false),
                    Label = table.Column<string>(maxLength: 250, nullable: true),
                    Required = table.Column<bool>(type: "bit", nullable: true),
                    Order = table.Column<int>(nullable: true),
                    ControlType = table.Column<string>(maxLength: 50, nullable: false),
                    PacienteId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormField", x => x.FormFieldID);
                    table.ForeignKey(
                        name: "FK_Paciente_Forms",
                        column: x => x.PacienteId,
                        principalSchema: "Oncologia",
                        principalTable: "Paciente",
                        principalColumn: "PacienteID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FormField_PacienteId",
                schema: "Oncologia",
                table: "FormField",
                column: "PacienteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FormField",
                schema: "Oncologia");
        }
    }
}
