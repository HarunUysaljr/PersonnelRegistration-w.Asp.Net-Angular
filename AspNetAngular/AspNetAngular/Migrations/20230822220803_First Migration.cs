using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AspNetAngular.Migrations
{
    /// <inheritdoc />
    public partial class FirstMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PersonDetails",
                columns: table => new
                {
                    PerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PerName = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    PerSname = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    PerAge = table.Column<string>(type: "nvarchar(10)", nullable: false),
                    PerMail = table.Column<string>(type: "nvarchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonDetails", x => x.PerId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PersonDetails");
        }
    }
}
