using LibraryManagement.Models;

namespace LibraryManagement.Services
{
    public interface ILibraryBranchService
    {
        void CreateLibraryBranch(LibraryBranch branch);
        LibraryBranch? GetLibraryBranchById(int branchId);
    }
}