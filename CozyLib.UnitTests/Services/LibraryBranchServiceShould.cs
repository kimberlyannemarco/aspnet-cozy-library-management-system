using System.Collections.Generic;
using System.Linq;
using LibraryManagement.Data;
using LibraryManagement.Exceptions;
using LibraryManagement.Models;
using LibraryManagement.Services;
using Microsoft.EntityFrameworkCore;
using Moq;
using Xunit;

namespace CozyLibrary.UnitTests.Services
{
    public class LibraryBranchServiceShould
    {
        private readonly Mock<LibraryContext> _mockContext;
        private readonly Mock<DbSet<LibraryBranch>> _mockBranches;
        private readonly LibraryBranchService _service;

        public LibraryBranchServiceShould()
        {
            var branchesData = new List<LibraryBranch>().AsQueryable();

            _mockBranches = new Mock<DbSet<LibraryBranch>>();
            _mockBranches.As<IQueryable<LibraryBranch>>().Setup(m => m.Provider).Returns(branchesData.Provider);
            _mockBranches.As<IQueryable<LibraryBranch>>().Setup(m => m.Expression).Returns(branchesData.Expression);
            _mockBranches.As<IQueryable<LibraryBranch>>().Setup(m => m.ElementType).Returns(branchesData.ElementType);
            _mockBranches.As<IQueryable<LibraryBranch>>().Setup(m => m.GetEnumerator()).Returns(branchesData.GetEnumerator());

            _mockContext = new Mock<LibraryContext>(new DbContextOptions<LibraryContext>());
            _mockContext.Setup(c => c.LibraryBranches).Returns(_mockBranches.Object);

            _service = new LibraryBranchService(_mockContext.Object);
        }

        /****************************************************************************
         * CREATE tests
         ****************************************************************************/

        [Fact]
        public void CreateLibraryBranch_WithValidBranch_ShouldAddToContextAndSave()
        {
            var branch = new LibraryBranch
            {
                LibraryBranchId = 1,
                BranchName = "Downtown Branch",
                BranchAddress = "123 Main St, Downtown"
            };

            _service.CreateLibraryBranch(branch);

            _mockBranches.Verify(m => m.Add(branch), Times.Once);
            _mockContext.Verify(m => m.SaveChanges(), Times.Once);
        }

        [Fact]
        public void CreateLibraryBranch_WithNullBranch_ShouldThrowInvalidLibraryBranchException()
        {
            Assert.Throws<InvalidLibraryBranchException>(() => _service.CreateLibraryBranch(null!));
        }

        [Fact]
        public void CreateLibraryBranch_WithMissingBranchName_ShouldThrowInvalidLibraryBranchException()
        {
            var branch = new LibraryBranch
            {
                LibraryBranchId = 1,
                BranchName = null,
                BranchAddress = "123 Main St, Downtown"
            };

            Assert.Throws<InvalidLibraryBranchException>(() => _service.CreateLibraryBranch(branch));
        }

        /****************************************************************************
         * GET / GetLibraryBranchById tests
         ****************************************************************************/

        [Fact]
        public void GetLibraryBranchById_WithExistingBranch_ShouldReturnBranch()
        {
            var branch = new LibraryBranch
            {
                LibraryBranchId = 1,
                BranchName = "Downtown Branch",
                BranchAddress = "123 Main St, Downtown"
            };

            var branches = new List<LibraryBranch> { branch }.AsQueryable();

            var mockBranches = new Mock<DbSet<LibraryBranch>>();
            mockBranches.As<IQueryable<LibraryBranch>>().Setup(m => m.Provider).Returns(branches.Provider);
            mockBranches.As<IQueryable<LibraryBranch>>().Setup(m => m.Expression).Returns(branches.Expression);
            mockBranches.As<IQueryable<LibraryBranch>>().Setup(m => m.ElementType).Returns(branches.ElementType);
            mockBranches.As<IQueryable<LibraryBranch>>().Setup(m => m.GetEnumerator()).Returns(branches.GetEnumerator());

            var mockContext = new Mock<LibraryContext>(new DbContextOptions<LibraryContext>());
            mockContext.Setup(c => c.LibraryBranches).Returns(mockBranches.Object);

            var service = new LibraryBranchService(mockContext.Object);

            var result = service.GetLibraryBranchById(1);

            Assert.NotNull(result);
            Assert.Equal(1, result.LibraryBranchId);
            Assert.Equal("Downtown Branch", result.BranchName);
            Assert.Equal("123 Main St, Downtown", result.BranchAddress);
        }

        [Fact]
        public void GetLibraryBranchById_WithMissingBranchId_ShouldThrowLibraryBranchNotFoundException()
        {
            var branches = new List<LibraryBranch>().AsQueryable();

            var mockBranches = new Mock<DbSet<LibraryBranch>>();
            mockBranches.As<IQueryable<LibraryBranch>>().Setup(m => m.Provider).Returns(branches.Provider);
            mockBranches.As<IQueryable<LibraryBranch>>().Setup(m => m.Expression).Returns(branches.Expression);
            mockBranches.As<IQueryable<LibraryBranch>>().Setup(m => m.ElementType).Returns(branches.ElementType);
            mockBranches.As<IQueryable<LibraryBranch>>().Setup(m => m.GetEnumerator()).Returns(branches.GetEnumerator());

            var mockContext = new Mock<LibraryContext>(new DbContextOptions<LibraryContext>());
            mockContext.Setup(c => c.LibraryBranches).Returns(mockBranches.Object);

            var service = new LibraryBranchService(mockContext.Object);

            Assert.Throws<LibraryBranchNotFoundException>(() => service.GetLibraryBranchById(999));
        }
    }
}