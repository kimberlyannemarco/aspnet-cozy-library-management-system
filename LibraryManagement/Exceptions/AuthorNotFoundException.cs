using System;
using System.Runtime.Serialization;

namespace LibraryManagement.Exceptions
{
    public class AuthorNotFoundException : Exception
    {
        public int AuthorId { get; }

        public AuthorNotFoundException(int authorId)
            : base($"Author with ID {authorId} was not found in the library.")
        {
            AuthorId = authorId;
        }
    }
}