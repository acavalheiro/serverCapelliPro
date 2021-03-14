using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CapelliPro.Domain.Data.Migrations
{
    public partial class SurveyTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Surveys",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    Age = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    HairType = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    HairColour = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    HasColouredHair = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    NumberWashes = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    LivingPlace = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    UseHeatTools = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    UseThermalProducts = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    DesiredHair = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Surveys", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Surveys");
        }
    }
}
