using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KargoTakip.Server.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class i_added_cargo_table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cargos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Sender_FirstName = table.Column<string>(type: "varchar(50)", nullable: false),
                    Sender_LastName = table.Column<string>(type: "varchar(50)", nullable: false),
                    Sender_IdentityNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sender_Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sender_PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Receiver_FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Receiver_LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Receiver_IdentityNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Receiver_Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Receiver_PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeliveryAddress_City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeliveryAddress_District = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeliveryAddress_Neighborhood = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeliveryAddress_Street = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeliveryAddress_FullAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CargoInfo_CargoType = table.Column<int>(type: "int", nullable: false),
                    CargoInfo_Weight = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreateAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreateUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdateAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    UpdateUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleteAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    DeleteUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cargos", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cargos");
        }
    }
}
