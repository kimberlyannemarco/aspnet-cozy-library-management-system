using Microsoft.AspNetCore.Mvc;
using LibraryManagement.Models;
using LibraryManagement.Data;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagement.Controllers
{
    public class LibraryBranchController : Controller
    {
        private readonly LibraryContext _context;

        public LibraryBranchController(LibraryContext context)
        {
            _context = context;
        }

        // Index
        public IActionResult Index()
        {
            var branches = _context.LibraryBranches.ToList();
            return View(branches);
        }

        // Details
        public IActionResult Details(int id)
        {
            var branch = _context.LibraryBranches.FirstOrDefault(b => b.LibraryBranchId == id);
            if (branch == null) return NotFound();
            return View(branch);
        }

        // Create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(LibraryBranch branch)
        {
            if (branch.BranchName != null && branch.BranchAddress != null)
            {
                _context.LibraryBranches.Add(branch);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(branch);
        }

        // Edit
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var branch = _context.LibraryBranches.FirstOrDefault(b => b.LibraryBranchId == id);
            if (branch == null) return NotFound();
            return View(branch);
        }
        [HttpPost]        
        public IActionResult Edit(int id, LibraryBranch branch)
        {
            if (id != branch.LibraryBranchId) return NotFound();
            
            var existing = _context.LibraryBranches.FirstOrDefault(lb => lb.LibraryBranchId == id);
            if (existing != null)
            {
                existing.BranchAddress = branch.BranchAddress;
                _context.SaveChanges();
            }
            
            return RedirectToAction("Index");
        }

        // Delete
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var branch = _context.LibraryBranches.FirstOrDefault(b => b.LibraryBranchId == id);
            if (branch == null) return NotFound();
            return View(branch);
        }
        [HttpPost]
        public IActionResult Delete(int id, LibraryBranch branch)
        {
            var branchToDelete = _context.LibraryBranches.FirstOrDefault(b => b.LibraryBranchId == id);
            if (branchToDelete != null)
            {
                _context.LibraryBranches.Remove(branchToDelete);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
