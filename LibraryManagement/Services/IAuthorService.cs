using LibraryManagement.Models;

namespace LibraryManagement.Services
{
    public interface IAuthorService
    {
        void CreateAuthor(Author author);
        Author? GetAuthorById(int authorId);
    }
}