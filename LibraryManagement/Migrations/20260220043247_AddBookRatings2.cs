using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibraryManagement.Migrations
{
    /// <inheritdoc />
    public partial class AddBookRatings2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookRatings_Customers_CustomerId",
                table: "BookRatings");

            migrationBuilder.DropIndex(
                name: "IX_BookRatings_CustomerId",
                table: "BookRatings");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "BookRatings");

            migrationBuilder.UpdateData(
                table: "BookRatings",
                keyColumn: "RatingId",
                keyValue: 1,
                column: "Comment",
                value: "Great world-building");

            migrationBuilder.UpdateData(
                table: "BookRatings",
                keyColumn: "RatingId",
                keyValue: 2,
                column: "Comment",
                value: "Cozy read");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CustomerId",
                table: "BookRatings",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "BookRatings",
                keyColumn: "RatingId",
                keyValue: 1,
                columns: new[] { "Comment", "CustomerId" },
                values: new object[] { "Amazing book!", 1 });

            migrationBuilder.UpdateData(
                table: "BookRatings",
                keyColumn: "RatingId",
                keyValue: 2,
                columns: new[] { "Comment", "CustomerId" },
                values: new object[] { "Great read", 2 });

            migrationBuilder.CreateIndex(
                name: "IX_BookRatings_CustomerId",
                table: "BookRatings",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_BookRatings_Customers_CustomerId",
                table: "BookRatings",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "CustomerId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
