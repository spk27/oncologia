using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class InicialPaciente : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Oncologia");

            migrationBuilder.CreateTable(
                name: "Paciente",
                schema: "Oncologia",
                columns: table => new
                {
                    PacienteID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PrimerNombre = table.Column<string>(maxLength: 50, nullable: false),
                    SegundoNombre = table.Column<string>(maxLength: 50, nullable: true),
                    PrimerApellido = table.Column<string>(maxLength: 50, nullable: false),
                    SegundoApellido = table.Column<string>(maxLength: 50, nullable: true),
                    Cedula = table.Column<string>(maxLength: 15, nullable: false),
                    TipoCedula = table.Column<string>(type: "char(2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paciente", x => x.PacienteID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Paciente",
                schema: "Oncologia");
        }
    }
}
