using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LibraryManagement.Data;
using LibraryManagement.Models;
using Microsoft.AspNetCore.Authorization;

namespace LibraryManagement.Controllers.Api
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthorsController : ControllerBase
    {
        private readonly LibraryContext _context;

        public AuthorsController(LibraryContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Author>>> GetAuthors()
        {
            return Ok(await _context.Authors.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Author>> GetAuthor(int id)
        {
            var author = await _context.Authors.FirstOrDefaultAsync(a => a.AuthorId == id);
            if (author == null) return NotFound();
            return Ok(author);
        }

        [HttpPost]
        //[Authorize]
        public async Task<ActionResult<Author>> CreateAuthor([FromBody] Author author)
        {
            ModelState.Remove("Books");
            if (author.FirstName != null && author.LastName != null)
            {
                _context.Authors.Add(author);
                await _context.SaveChangesAsync();
                return CreatedAtAction(nameof(GetAuthor), new { id = author.AuthorId }, author);
            }
            return BadRequest("Invalid author data");
        }

        [HttpPut("{id}")]
        //[Authorize]
        public async Task<IActionResult> UpdateAuthor(int id, [FromBody] Author author)
        {
            ModelState.Remove("Books");
            if (id != author.AuthorId) return BadRequest("Author ID mismatch.");

            var existing = await _context.Authors.FirstOrDefaultAsync(a => a.AuthorId == id);
            if (existing == null) return NotFound();

            existing.FirstName = author.FirstName;
            existing.LastName = author.LastName;
            existing.BirthYear = author.BirthYear;
            existing.BooksPublished = author.BooksPublished;

            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        //[Authorize]
        public async Task<IActionResult> DeleteAuthor(int id)
        {
            var author = await _context.Authors.FirstOrDefaultAsync(a => a.AuthorId == id);
            if (author == null) return NotFound();

            _context.Authors.Remove(author);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }  
}