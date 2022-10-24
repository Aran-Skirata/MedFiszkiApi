using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MedFiszkiApi.Data.Migrations
{
    public partial class categoriesAndParts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Category",
                table: "AnatomyTranslations");

            migrationBuilder.DropColumn(
                name: "Portion",
                table: "AnatomyTranslations");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "AnatomyTranslations",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PartId",
                table: "AnatomyTranslations",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CategoryName = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Parts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PartName = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parts", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AnatomyTranslations_CategoryId",
                table: "AnatomyTranslations",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_AnatomyTranslations_PartId",
                table: "AnatomyTranslations",
                column: "PartId");

            migrationBuilder.AddForeignKey(
                name: "FK_AnatomyTranslations_Categories_CategoryId",
                table: "AnatomyTranslations",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AnatomyTranslations_Parts_PartId",
                table: "AnatomyTranslations",
                column: "PartId",
                principalTable: "Parts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AnatomyTranslations_Categories_CategoryId",
                table: "AnatomyTranslations");

            migrationBuilder.DropForeignKey(
                name: "FK_AnatomyTranslations_Parts_PartId",
                table: "AnatomyTranslations");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Parts");

            migrationBuilder.DropIndex(
                name: "IX_AnatomyTranslations_CategoryId",
                table: "AnatomyTranslations");

            migrationBuilder.DropIndex(
                name: "IX_AnatomyTranslations_PartId",
                table: "AnatomyTranslations");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "AnatomyTranslations");

            migrationBuilder.DropColumn(
                name: "PartId",
                table: "AnatomyTranslations");

            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "AnatomyTranslations",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Portion",
                table: "AnatomyTranslations",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }
    }
}
