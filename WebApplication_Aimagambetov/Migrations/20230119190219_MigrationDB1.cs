using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication_Aimagambetov.Migrations
{
    public partial class MigrationDB1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Login = table.Column<string>(type: "TEXT", nullable: false),
                    Password = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CalculationDatas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<int>(type: "INTEGER", nullable: true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    H0 = table.Column<double>(type: "REAL", nullable: false),
                    t_nachMat = table.Column<double>(type: "REAL", nullable: false),
                    T_nachTemp = table.Column<double>(type: "REAL", nullable: false),
                    Wg = table.Column<double>(type: "REAL", nullable: false),
                    Cg = table.Column<double>(type: "REAL", nullable: false),
                    Gm = table.Column<double>(type: "REAL", nullable: false),
                    Cm = table.Column<double>(type: "REAL", nullable: false),
                    aV = table.Column<double>(type: "REAL", nullable: false),
                    D = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CalculationDatas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CalculationDatas_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CalculationDatas_UserId",
                table: "CalculationDatas",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CalculationDatas");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
