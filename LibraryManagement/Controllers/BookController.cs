using Microsoft.AspNetCore.Mvc;
using LibraryManagement.Models;
using LibraryManagement.ViewModels;
using LibraryManagement.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using LibraryManagement.Exceptions;
using LibraryManagement.Middleware;
using Microsoft.AspNetCore.Authorization;
using LibraryManagement.Services;

namespace LibraryManagement.Controllers
{
    public class BookController : Controller
    {
        private readonly LibraryContext _context;
        private readonly IBookService _bookService;

        public BookController(LibraryContext context, IBookService bookService)
        {
            _context = context;
            _bookService = bookService;
        }

        // Index
        public IActionResult Index()
        {
            var books = _context.Books
            .Include(b => b.Author)
            .Include(b => b.LibraryBranch)
            .ToList();
            return View(books);
        }

        // Details
        public IActionResult Details(int id)
        {
            try
            {
                var viewModel = _bookService.GetBookWithDetails(id);
                return View(viewModel);
            }
                catch (BookNotFoundException)
            {
                return NotFound();
            }
        }

        // Create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Book book)
        {
            if (book == null)
            {
                return View(book);
            }
            try
            {
                _bookService.CreateBook(book);
                return RedirectToAction(nameof(Index));
            }
            catch (InvalidBookException)
            {
                ModelState.AddModelError("Title", "Please fill in all required fields.");
                return View(book);
            }
        }
        
        // Edit
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var book = _context.Books.FirstOrDefault(b => b.BookId == id);
            if (book == null) return NotFound();

            ViewBag.Authors = new SelectList(_context.Authors, "AuthorId", "LastName", book.AuthorId);
            ViewBag.Branches = new SelectList(_context.LibraryBranches, "LibraryBranchId", "BranchName", book.LibraryBranchId);

            return View(book);
        }

        [HttpPost]
        public IActionResult Edit(int id, Book book)
        {
            if (id != book.BookId) return NotFound();

            var existing = _context.Books.FirstOrDefault(b => b.BookId == id);
            if (existing == null) return NotFound();

            existing.Title = book.Title;
            existing.ISBN = book.ISBN;
            existing.PublicationYear = book.PublicationYear;
            existing.AuthorId = book.AuthorId;
            existing.LibraryBranchId = book.LibraryBranchId;

            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        // Delete
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var book = _context.Books
                .Include(b => b.Author)
                .Include(b => b.LibraryBranch)
                .FirstOrDefault(b => b.BookId == id);

            if (book == null) return NotFound();

            return View(book);
        }

        [HttpPost]
        public IActionResult Delete(int id, Book book)
        {
            var bookToDelete = _context.Books.FirstOrDefault(b => b.BookId == id);

            if (bookToDelete != null)
            {
                _context.Books.Remove(bookToDelete);
                _context.SaveChanges();
            }

            return RedirectToAction(nameof(Index));
        }

        // Rate
        [HttpPost]
        public IActionResult Rate(int bookId, int rating, string? comment)
        {
            try
            {
                _bookService.RateBook(bookId, rating, comment);
                return RedirectToAction(nameof(Details), new { id = bookId });
            }
            catch (BookNotFoundException)
            {
                return BadRequest("Book not found.");
            }
        }
    }
}