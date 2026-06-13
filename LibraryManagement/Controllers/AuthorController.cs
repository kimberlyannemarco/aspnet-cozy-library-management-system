using Microsoft.AspNetCore.Mvc;
using LibraryManagement.Models;
using LibraryManagement.Data;
using Microsoft.EntityFrameworkCore;


namespace LibraryManagement.Controllers
{
public class AuthorController : Controller
{
private readonly LibraryContext _context;


public AuthorController(LibraryContext context)
{
_context = context;
}


// Index
public IActionResult Index()
{
var authors = _context.Authors
.Include(a => a.Books)
.ToList();
return View(authors);
}


// Details
public IActionResult Details(int id)
{
var author = _context.Authors
.Include(a => a.Books)
.FirstOrDefault(a => a.AuthorId == id);
if (author == null) return NotFound();
return View(author);
}


// Create
[HttpGet]
public IActionResult Create()
{
return View();
}
[HttpPost]
public IActionResult Create(Author author)
{
if (author.FirstName != null && author.LastName != null && author.BooksPublished != 0)
{
_context.Authors.Add(author);
_context.SaveChanges();
return RedirectToAction("Index");
}
return View(author);
}


// Edit
[HttpGet]
public IActionResult Edit(int id)
{
var author = _context.Authors.FirstOrDefault(a => a.AuthorId == id);
if (author == null) return NotFound();
return View(author);
}
[HttpPost]
public IActionResult Edit(int id, Author author)
{
if (id != author.AuthorId) return NotFound();

var existing = _context.Authors.FirstOrDefault(a => a.AuthorId == id);
if (existing != null)
{
existing.FirstName = author.FirstName;
existing.LastName = author.LastName;
existing.BirthYear = author.BirthYear;
existing.BooksPublished = author.BooksPublished;
_context.SaveChanges();
}

return RedirectToAction("Index");
}


// Delete
[HttpGet]
public IActionResult Delete(int id)
{
var author = _context.Authors
.Include(a => a.Books)
.FirstOrDefault(a => a.AuthorId == id);
if (author == null) return NotFound();
return View(author);
}
[HttpPost]
public IActionResult Delete(int id, Author author)
{
var authorToDelete = _context.Authors.FirstOrDefault(a => a.AuthorId == id);
if (authorToDelete != null)
{
_context.Authors.Remove(authorToDelete);
_context.SaveChanges();
}
return RedirectToAction("Index");
}
}
}