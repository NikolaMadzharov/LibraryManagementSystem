using LibraryManagementSystem.Models;

namespace LibraryManagementSystem.Data
{
    public interface IBookRepository
    {
        void CreateBook(Book book);
        IEnumerable<Book> GetAllBooks();
        Book GetBookById(int id);

        bool SaveChanges();
    }
}
