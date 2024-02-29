using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SHVA.Migrations
{
    /// <inheritdoc />
    public partial class Add_HuisvesstingAanbieders_table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Huisvestingaanbieders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WoningIDs = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StudentenIds = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Huisvestingaanbieders", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Huisvestingaanbieders");
        }
    }
}
