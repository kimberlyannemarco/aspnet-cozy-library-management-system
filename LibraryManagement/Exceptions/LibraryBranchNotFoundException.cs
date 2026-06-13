using System;
using System.Runtime.Serialization;

namespace LibraryManagement.Exceptions
{
    public class LibraryBranchNotFoundException : Exception
    {
        public int LibraryBranchId { get; }

        public LibraryBranchNotFoundException(int librarybranchId)
            : base($"Library Branch with ID {librarybranchId} was not found in the library.")
        {
            LibraryBranchId = librarybranchId;
        }
    }
}