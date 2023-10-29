using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConsoleApp1.Migrations
{
    /// <inheritdoc />
    public partial class add_new_table2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           
            migrationBuilder.CreateTable(
                name: "Bossess",
                columns: table => new
                {
                    Boss_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Boss_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Boss_Post = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Boss_experience = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bossess", x => x.Boss_id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bossess");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Employeess",
                table: "Employeess");

            migrationBuilder.RenameTable(
                name: "Employeess",
                newName: "EmployeeModel");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EmployeeModel",
                table: "EmployeeModel",
                column: "Id");
        }
    }
}
