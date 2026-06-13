using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LibraryManagement.Data;
using LibraryManagement.Models;
using Microsoft.AspNetCore.Authorization;

namespace LibraryManagement.Controllers.Api
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly LibraryContext _context;

        public BooksController(LibraryContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Book>>> GetBooks()
        {
            var books = await _context.Books
                .Include(b => b.Author)
                .Include(b => b.LibraryBranch)
                .ToListAsync();

            return Ok(books);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Book>> GetBook(int id)
        {
            var book = await _context.Books
                .Include(b => b.Author)
                .Include(b => b.LibraryBranch)
                .Include(b => b.BookRatings)
                .FirstOrDefaultAsync(b => b.BookId == id);

            if (book == null)
            {
                return NotFound();
            }

            return Ok(book);
        }

        [HttpPost]
        // INTEGRATIONTEST
        [Authorize]
        public async Task<ActionResult<Book>> CreateBook([FromBody] Book book)
        {
            ModelState.Remove("Author");
            ModelState.Remove("LibraryBranch");
            ModelState.Remove("BookRatings");

            if (book.Title != null && book.ISBN != null && book.PublicationYear != 0 && book.AuthorId != 0 && book.LibraryBranchId != 0)
            {
                _context.Books.Add(book);
                await _context.SaveChangesAsync();
                return CreatedAtAction(nameof(GetBook), new { id = book.BookId }, book);
            }
            
            return BadRequest("Invalid book data");
        }

        [HttpPut("{id}")]
        // INTEGRATIONTEST
        [Authorize]
        public async Task<IActionResult> UpdateBook(int id, [FromBody] Book book)
        {
            // Remove navigation property validation errors
            ModelState.Remove("Author");
            ModelState.Remove("LibraryBranch");
            ModelState.Remove("BookRatings");

            if (id != book.BookId)
            {
                return BadRequest("Book ID mismatch.");
            }

            var existingBook = await _context.Books.FirstOrDefaultAsync(b => b.BookId == id);
            if (existingBook == null)
            {
                return NotFound();
            }

            existingBook.Title = book.Title;
            existingBook.ISBN = book.ISBN;
            existingBook.PublicationYear = book.PublicationYear;
            existingBook.AuthorId = book.AuthorId;
            existingBook.LibraryBranchId = book.LibraryBranchId;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteBook(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Invalid book ID.");
            }

            var book = await _context.Books.FindAsync(id);
            if (book == null)
            {
                return NotFound();
            }

            // Remove any ratings first (safe for in‑memory)
            var ratings = await _context.BookRatings
                .Where(r => r.BookId == id)
                .ToListAsync();
            _context.BookRatings.RemoveRange(ratings);

            _context.Books.Remove(book);
            await _context.SaveChangesAsync();

            return NoContent();
        }
            }
        }