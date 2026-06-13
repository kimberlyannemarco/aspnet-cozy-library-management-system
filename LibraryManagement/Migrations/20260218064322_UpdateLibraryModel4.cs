using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LibraryManagement.Migrations
{
    /// <inheritdoc />
    public partial class UpdateLibraryModel4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 1,
                columns: new[] { "AcctOpenDate", "CustomerEmail", "CustomerFirstName", "CustomerLastName", "CustomerPhone" },
                values: new object[] { "Jan 22, 2025", "maria.w@email.com", "Maria", "Wang", "236-356-7381" });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 20,
                columns: new[] { "AcctOpenDate", "CustomerEmail", "CustomerFirstName", "CustomerLastName", "CustomerPhone" },
                values: new object[] { "Jan 4, 2026", "santiago.s@email.com", "Santiago", "Silva", "654-890-7843" });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "CustomerId", "AcctOpenDate", "CustomerEmail", "CustomerFirstName", "CustomerLastName", "CustomerPhone" },
                values: new object[,]
                {
                    { 2, "Feb 14, 2025", "emma.li@email.com", "Emma", "Li", "604-274-9981" },
                    { 3, "Feb 25, 2025", "fatima.zhang@email.com", "Fatima", "Zhang", "234-100-4567" },
                    { 4, "Apr 28, 2025", "anna.nguyen@email.com", "Anna", "Nguyen", "604-123-6607" },
                    { 5, "May 4, 2025", "liv.garcia@email.com", "Olivia", "Garcia", "889-678-2231" },
                    { 6, "Jun 3, 2025", "sarah.kumar@email.com", "Sarah", "Kumar", "604-265-5689" },
                    { 7, "Jun 7, 2025", "mary.ali@email.com", "Mary", "Ali", "604-654-7819" },
                    { 8, "Jul 2, 2025", "sofia.smith@email.com", "Sofia", "Smith", "235-246-0921" },
                    { 9, "Jul 9, 2025", "lizzie.johnson@email.com", "Elizabeth", "Johnson", "604-120-2345" },
                    { 10, "Jul 12, 2025", "issa.williams@email.com", "Isabella", "Williams", "778-099-9876" },
                    { 11, "Jul 19, 2025", "muhammad.brown@email.com", "Muhammad", "Brown", "604-180-1234" },
                    { 12, "Jul 22, 2025", "john.jones@email.com", "John", "Jones", "604-457-0200" },
                    { 13, "Aug 10, 2025", "james.miller@email.com", "James", "Miller", "604-123-2012" },
                    { 14, "Aug 13, 2025", "david.davis@email.com", "David", "Davis", "912-942-8671" },
                    { 15, "Oct 25, 2025", "ahmed.rodriguez@email.com", "Ahmed", "Rodriguez", "604-227-4252" },
                    { 16, "Nov 6, 2025", "mike.martinez@email.com", "Michael", "Martinez", "224-764-7781" },
                    { 17, "Nov 25, 2025", "ali.hern@email.com", "Ali", "Hernandez", "604-246-3453" },
                    { 18, "Dec 1, 2025", "omar.gonzi@email.com", "Omar", "Gonzalez", "887-063-2342" },
                    { 19, "Dec 28, 2025", "joe.mueller@email.com", "Joseph", "Mueller", "604-567-8555" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 19);

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 1,
                columns: new[] { "AcctOpenDate", "CustomerEmail", "CustomerFirstName", "CustomerLastName", "CustomerPhone" },
                values: new object[] { "Feb 1, 2025", "john.smith@email.com", "John", "Smith", "604-123-4567" });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 20,
                columns: new[] { "AcctOpenDate", "CustomerEmail", "CustomerFirstName", "CustomerLastName", "CustomerPhone" },
                values: new object[] { "Feb 1, 2025", "sarah.w@email.com", "Sarah", "Wilson", "604-987-6543" });
        }
    }
}
