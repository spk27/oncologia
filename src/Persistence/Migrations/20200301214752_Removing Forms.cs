using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class RemovingForms : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FormValidation",
                schema: "Oncologia");

            migrationBuilder.DropTable(
                name: "FormField",
                schema: "Oncologia");

            migrationBuilder.DropTable(
                name: "Validation",
                schema: "Oncologia");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FormField",
                schema: "Oncologia",
                columns: table => new
                {
                    FormFieldID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ColumnsSize = table.Column<int>(type: "int", nullable: true, defaultValue: 12),
                    ControlType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FormName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    KeyField = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Label = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Order = table.Column<int>(type: "int", nullable: true),
                    ValueField = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormField", x => x.FormFieldID);
                });

            migrationBuilder.CreateTable(
                name: "Validation",
                schema: "Oncologia",
                columns: table => new
                {
                    ValidationID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Regex = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ValidationValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    FormFieldID = table.Column<int>(type: "int", nullable: false),
                    ValidationID = table.Column<int>(type: "int", nullable: false)
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
    }
}
