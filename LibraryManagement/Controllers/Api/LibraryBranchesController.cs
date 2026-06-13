using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LibraryManagement.Data;
using LibraryManagement.Models;
using Microsoft.AspNetCore.Authorization;

namespace LibraryManagement.Controllers.Api
{
    [ApiController]
    [Route("api/[controller]")]
    public class LibraryBranchesController : ControllerBase
    {
        private readonly LibraryContext _context;

        public LibraryBranchesController(LibraryContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<LibraryBranch>>> GetLibraryBranches()
        {
            return Ok(await _context.LibraryBranches.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<LibraryBranch>> GetLibraryBranch(int id)
        {
            var branch = await _context.LibraryBranches.FirstOrDefaultAsync(b => b.LibraryBranchId == id);
            if (branch == null) return NotFound();
            return Ok(branch);
        }

        [HttpPost]
        //[Authorize]
        public async Task<ActionResult<LibraryBranch>> CreateLibraryBranch([FromBody] LibraryBranch branch)
        {
            if (branch.BranchName != null && branch.BranchAddress != null)
            {
                _context.LibraryBranches.Add(branch);
                await _context.SaveChangesAsync();
                return CreatedAtAction(nameof(GetLibraryBranch), new { id = branch.LibraryBranchId }, branch);
            }
            return BadRequest("Invalid branch data");
        }

        [HttpPut("{id}")]
public async Task<IActionResult> UpdateLibraryBranch(int id, [FromBody] LibraryBranch branch)
{
    if (id != branch.LibraryBranchId) return BadRequest("Branch ID mismatch.");
    if (!ModelState.IsValid) return BadRequest(ModelState);  // Extra safety

    try
    {
        var existing = await _context.LibraryBranches.FirstOrDefaultAsync(b => b.LibraryBranchId == id);
        if (existing == null) return NotFound();

        // Copy properties safely
        existing.BranchName = branch.BranchName ?? existing.BranchName;
        existing.BranchAddress = branch.BranchAddress ?? existing.BranchAddress;

        await _context.SaveChangesAsync();
        return NoContent();
    }
    catch (DbUpdateException ex)
    {
        // Log ex.InnerException?.Message for details (e.g., unique violation)
        return BadRequest($"Update failed: {ex.InnerException?.Message ?? ex.Message}");
    }
    catch (Exception ex)
    {
        // Log ex
        return StatusCode(500, "Internal server error");
    }
}

        [HttpDelete("{id}")]
        //[Authorize]
        public async Task<IActionResult> DeleteLibraryBranch(int id)
        {
            var branch = await _context.LibraryBranches.FirstOrDefaultAsync(b => b.LibraryBranchId == id);
            if (branch == null) return NotFound();

            _context.LibraryBranches.Remove(branch);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}