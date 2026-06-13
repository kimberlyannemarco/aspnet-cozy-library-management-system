using LibraryManagement.Data;
using LibraryManagement.Exceptions;
using LibraryManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagement.Services
{
    public class LibraryBranchService : ILibraryBranchService
    {
        private readonly LibraryContext _context;

        public LibraryBranchService(LibraryContext context)
        {
            _context = context;
        }

        public void CreateLibraryBranch(LibraryBranch branch)
        {
            if (branch == null)
            {
                throw new InvalidLibraryBranchException("Library branch cannot be null.");
            }

            if (string.IsNullOrEmpty(branch.BranchName))
            {
                throw new InvalidLibraryBranchException("Branch name is required.");
            }

            _context.LibraryBranches.Add(branch);
            _context.SaveChanges();
        }

        public LibraryBranch? GetLibraryBranchById(int branchId)
        {
            var branch = _context.LibraryBranches
                .FirstOrDefault(b => b.LibraryBranchId == branchId);

            if (branch == null)
            {
                throw new LibraryBranchNotFoundException(branchId);
            }

            return branch;
        }
    }

    public class InvalidLibraryBranchException : Exception
    {
        public InvalidLibraryBranchException(string message) : base(message) { }
    }
}