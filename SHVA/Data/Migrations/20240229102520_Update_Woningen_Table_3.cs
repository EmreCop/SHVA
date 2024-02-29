using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SHVA.Migrations
{
    /// <inheritdoc />
    public partial class Update_Woningen_Table_3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Huisvestingaanbieder",
                table: "Woningen",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Huisvestingaanbieder",
                table: "Woningen");
        }
    }
}
