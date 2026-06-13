using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LibraryManagement.Migrations
{
    /// <inheritdoc />
    public partial class UpdateLibraryModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "AuthorId",
                keyValue: 20,
                columns: new[] { "BooksPublished", "FirstName", "LastName" },
                values: new object[] { 26, "Colleen", "Hoover" });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "AuthorId", "BooksPublished", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 4, 7, "Markus", "Zusak" },
                    { 5, 9, "Taylor Jenkins", "Reid" },
                    { 6, 34, "T.J.", "Klune" },
                    { 7, 3, "Gillian Flynn", "Atwood" },
                    { 8, 6, "R.F.", "Kuang" },
                    { 9, 30, "David", "Levithan" },
                    { 10, 7, "Antoine", "de Saint-Exupery" },
                    { 11, 2, "Stephen", "Chbosky" },
                    { 12, 40, "Lois", "Lowry" },
                    { 13, 3, "Alex", "Michaelides" },
                    { 14, 3, "Morgan", "Housel" },
                    { 15, 4, "Khaled", "Hosseini" },
                    { 16, 1, "Kathryn Stockett", "Atwood" },
                    { 17, 3, "Jason", "Rekulak" },
                    { 18, 26, "Rebecca", "Yarros" },
                    { 19, 80, "Agatha", "Christie" }
                });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 1,
                columns: new[] { "AuthorId", "ISBN", "PublicationYear", "Title" },
                values: new object[] { 4, "978-1784162122", 2005, "The Book Thief" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 2,
                columns: new[] { "AuthorId", "ISBN", "PublicationYear", "Title" },
                values: new object[] { 5, "978-1501161933", 2017, "The Seven Husbands of Evelyn Hugo" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 20,
                columns: new[] { "ISBN", "PublicationYear", "Title" },
                values: new object[] { "978-1538724736", 2018, "Verity" });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "BookId", "AuthorId", "ISBN", "LibraryBranchId", "PublicationYear", "Title" },
                values: new object[,]
                {
                    { 6, 1, "978-1408890042", 1, 2018, "Circe" },
                    { 7, 2, "978-0063254480", 1, 2022, "Remarkably Bright Creatures" },
                    { 8, 3, "978-0771008795", 1, 1985, "The Handmaid's Tale" },
                    { 3, 6, "978-1250217318", 1, 2020, "The House in the Cerulean Sea" },
                    { 4, 7, "978-3596188789", 1, 2012, "Gone Girl" },
                    { 5, 8, "978-0008501853", 1, 2022, "Babel" },
                    { 9, 9, "978-0307931894", 1, 2012, "Every Day" },
                    { 10, 10, "978-3140464079", 1, 1943, "The Little Prince" },
                    { 11, 11, "978-1847394071", 1, 1999, "The Perks of Being a Wallflower" },
                    { 12, 12, "978-0440237686", 1, 1993, "The Giver" },
                    { 13, 13, "978-1250301703", 1, 2019, "The Silent Patient" },
                    { 14, 14, "978-0857197689", 1, 2020, "The Psychology of Money" },
                    { 15, 15, "978-0670064915", 1, 2007, "A Thousand Splendid Suns" },
                    { 16, 16, "978-0399155345", 1, 2009, "The Help" },
                    { 17, 17, "978-1250819345", 1, 2022, "Hidden Pictures" },
                    { 18, 18, "978-1649377579", 1, 2023, "Iron Flame" },
                    { 19, 19, "978-0008123208", 1, 1939, "And Then There Were None" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "AuthorId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "AuthorId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "AuthorId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "AuthorId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "AuthorId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "AuthorId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "AuthorId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "AuthorId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "AuthorId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "AuthorId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "AuthorId",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "AuthorId",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "AuthorId",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "AuthorId",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "AuthorId",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "AuthorId",
                keyValue: 19);

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "AuthorId",
                keyValue: 20,
                columns: new[] { "BooksPublished", "FirstName", "LastName" },
                values: new object[] { 80, "Agatha", "Christie" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 1,
                columns: new[] { "AuthorId", "ISBN", "PublicationYear", "Title" },
                values: new object[] { 1, "978-0747532699", 1997, "Harry Potter and the Philosopher's Stone" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 2,
                columns: new[] { "AuthorId", "ISBN", "PublicationYear", "Title" },
                values: new object[] { 2, "978-0547928227", 1937, "The Hobbit" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 20,
                columns: new[] { "ISBN", "PublicationYear", "Title" },
                values: new object[] { "978-0062073488", 1939, "And Then There Were None" });
        }
    }
}
