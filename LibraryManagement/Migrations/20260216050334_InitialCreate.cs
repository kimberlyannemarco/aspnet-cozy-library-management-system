using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LibraryManagement.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    AuthorId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirstName = table.Column<string>(type: "TEXT", nullable: false),
                    LastName = table.Column<string>(type: "TEXT", nullable: false),
                    BooksPublished = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.AuthorId);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CustomerFirstName = table.Column<string>(type: "TEXT", nullable: false),
                    CustomerLastName = table.Column<string>(type: "TEXT", nullable: false),
                    CustomerEmail = table.Column<string>(type: "TEXT", nullable: false),
                    CustomerPhone = table.Column<string>(type: "TEXT", nullable: false),
                    AcctOpenDate = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerId);
                });

            migrationBuilder.CreateTable(
                name: "LibraryBranches",
                columns: table => new
                {
                    LibraryBranchId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    BranchName = table.Column<string>(type: "TEXT", nullable: false),
                    BranchAddress = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LibraryBranches", x => x.LibraryBranchId);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    BookId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    ISBN = table.Column<string>(type: "TEXT", nullable: false),
                    AuthorId = table.Column<int>(type: "INTEGER", nullable: false),
                    PublicationYear = table.Column<int>(type: "INTEGER", nullable: false),
                    LibraryBranchId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.BookId);
                    table.ForeignKey(
                        name: "FK_Books_Authors_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Authors",
                        principalColumn: "AuthorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Books_LibraryBranches_LibraryBranchId",
                        column: x => x.LibraryBranchId,
                        principalTable: "LibraryBranches",
                        principalColumn: "LibraryBranchId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "AuthorId", "BooksPublished", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, 3, "Madeline", "Miller" },
                    { 2, 1, "Shelby", "Van Pelt" },
                    { 3, 66, "Margaret", "Atwood" },
                    { 20, 80, "Agatha", "Christie" }
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "CustomerId", "AcctOpenDate", "CustomerEmail", "CustomerFirstName", "CustomerLastName", "CustomerPhone" },
                values: new object[,]
                {
                    { 1, "Feb 1, 2025", "john.smith@email.com", "John", "Smith", "604-123-4567" },
                    { 20, "Feb 1, 2025", "sarah.w@email.com", "Sarah", "Wilson", "604-987-6543" }
                });

            migrationBuilder.InsertData(
                table: "LibraryBranches",
                columns: new[] { "LibraryBranchId", "BranchAddress", "BranchName" },
                values: new object[,]
                {
                    { 1, "123 Library St, Vancouver", "Main Branch" },
                    { 2, "456 City Ave, Vancouver", "Downtown Branch" },
                    { 5, "789 Campus Rd, Vancouver", "University Branch" }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "BookId", "AuthorId", "ISBN", "LibraryBranchId", "PublicationYear", "Title" },
                values: new object[,]
                {
                    { 1, 1, "978-0747532699", 1, 1997, "Harry Potter and the Philosopher's Stone" },
                    { 2, 2, "978-0547928227", 1, 1937, "The Hobbit" },
                    { 20, 20, "978-0062073488", 2, 1939, "And Then There Were None" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Books_AuthorId",
                table: "Books",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Books_LibraryBranchId",
                table: "Books",
                column: "LibraryBranchId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Authors");

            migrationBuilder.DropTable(
                name: "LibraryBranches");
        }
    }
}
