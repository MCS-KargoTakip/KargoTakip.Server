using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KargoTakip.Server.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class i_added_cargo_status_column_in_the_cargo_table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CargoStatus",
                table: "Cargos",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CargoStatus",
                table: "Cargos");
        }
    }
}
