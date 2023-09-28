using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_Shop.Migrations
{
    /// <inheritdoc />
    public partial class addingCustomerIdinOrderDetails : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CustomerId",
                table: "OrderDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "OrderDetails");
        }
    }
}
