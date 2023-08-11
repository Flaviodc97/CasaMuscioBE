using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CasaMuscioBENew.DAL.Migrations
{
    /// <inheritdoc />
    public partial class Initialize_Project : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Roomate",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Ip = table.Column<string>(type: "TEXT", nullable: false),
                    PackageCount = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roomate", x => x.ID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Roomate");
        }
    }
}
