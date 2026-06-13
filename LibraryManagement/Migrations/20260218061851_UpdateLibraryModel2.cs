using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LibraryManagement.Migrations
{
    /// <inheritdoc />
    public partial class UpdateLibraryModel2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "AuthorId",
                keyValue: 7,
                columns: new[] { "FirstName", "LastName" },
                values: new object[] { "Gillian", "Flynn" });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "AuthorId",
                keyValue: 16,
                columns: new[] { "FirstName", "LastName" },
                values: new object[] { "Kathryn", "Stockett" });

            migrationBuilder.UpdateData(
                table: "LibraryBranches",
                keyColumn: "LibraryBranchId",
                keyValue: 5,
                columns: new[] { "BranchAddress", "BranchName" },
                values: new object[] { "13755 102 Ave, Vancouver", "Civic Branch" });

            migrationBuilder.InsertData(
                table: "LibraryBranches",
                columns: new[] { "LibraryBranchId", "BranchAddress", "BranchName" },
                values: new object[,]
                {
                    { 3, "789 Main Ave, Vancouver", "Lower Mainland Branch" },
                    { 4, "1107 First St, Vancouver", "University Branch" },
                    { 6, "231 31st St, Vancouver", "Provincial Branch" },
                    { 7, "1007 Station Rd, Vancouver", "City Centre Branch" },
                    { 8, "656 High St, Vancouver", "North Branch" },
                    { 9, "7481 Park Ave, Vancouver", "Central Branch" },
                    { 10, "331 View Rd, Vancouver", "South Branch" },
                    { 11, "9970 Center Street, Vancouver", "East Branch" },
                    { 12, "385 Queens Rd, Vancouver", "West Branch" },
                    { 13, "17552 Green Lane, Vancouver", "Community Branch" },
                    { 14, "108 School St, Vancouver", "Regional Branch" },
                    { 15, "2219 Elm St, Vancouver", "University Branch" },
                    { 16, "3441 Victoria Rd, Vancouver", "Ridge Branch" },
                    { 17, "102 Hamilton Heights, Vancouver", "Valley Branch" },
                    { 18, "389 Maple Ridge, Vancouver", "Rural Branch" },
                    { 19, "6273 Sun Valley, Vancouver", "Uptown Branch" },
                    { 20, "901 Campus Rd, Vancouver", "First Branch" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "LibraryBranches",
                keyColumn: "LibraryBranchId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "LibraryBranches",
                keyColumn: "LibraryBranchId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "LibraryBranches",
                keyColumn: "LibraryBranchId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "LibraryBranches",
                keyColumn: "LibraryBranchId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "LibraryBranches",
                keyColumn: "LibraryBranchId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "LibraryBranches",
                keyColumn: "LibraryBranchId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "LibraryBranches",
                keyColumn: "LibraryBranchId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "LibraryBranches",
                keyColumn: "LibraryBranchId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "LibraryBranches",
                keyColumn: "LibraryBranchId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "LibraryBranches",
                keyColumn: "LibraryBranchId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "LibraryBranches",
                keyColumn: "LibraryBranchId",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "LibraryBranches",
                keyColumn: "LibraryBranchId",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "LibraryBranches",
                keyColumn: "LibraryBranchId",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "LibraryBranches",
                keyColumn: "LibraryBranchId",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "LibraryBranches",
                keyColumn: "LibraryBranchId",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "LibraryBranches",
                keyColumn: "LibraryBranchId",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "LibraryBranches",
                keyColumn: "LibraryBranchId",
                keyValue: 20);

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "AuthorId",
                keyValue: 7,
                columns: new[] { "FirstName", "LastName" },
                values: new object[] { "Gillian Flynn", "Atwood" });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "AuthorId",
                keyValue: 16,
                columns: new[] { "FirstName", "LastName" },
                values: new object[] { "Kathryn Stockett", "Atwood" });

            migrationBuilder.UpdateData(
                table: "LibraryBranches",
                keyColumn: "LibraryBranchId",
                keyValue: 5,
                columns: new[] { "BranchAddress", "BranchName" },
                values: new object[] { "789 Campus Rd, Vancouver", "University Branch" });
        }
    }
}
