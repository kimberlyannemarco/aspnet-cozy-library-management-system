using System;
using System.Runtime.Serialization;

namespace LibraryManagement.Exceptions
{
    public class BookNotFoundException : Exception
    {
        public int BookId { get; }

        public BookNotFoundException(int bookId)
            : base($"Book with ID {bookId} was not found in the library.")
        {
            BookId = bookId;
        }
    }
}