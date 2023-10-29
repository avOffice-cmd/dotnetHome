using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Test1.Migrations
{
    /// <inheritdoc />
    public partial class initialmigration : Migration
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

            migrationBuilder.CreateTable(
                name: "Employeess",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SalaryInRS = table.Column<long>(type: "bigint", nullable: false),
                    Boss_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employeess", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bossess");

            migrationBuilder.DropTable(
                name: "Employeess");
        }
    }
}
