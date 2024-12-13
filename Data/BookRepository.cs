using LibraryManagementSystem.Models;

namespace LibraryManagementSystem.Data
{
    public class BookRepository : IBookRepository
    {
        private readonly AppDbContext _context;
        public BookRepository(AppDbContext context)
        {
            _context = context;
        }

        public void CreateBook(Book book)
        {
            if (book == null)
            {
                throw new ArgumentNullException(nameof(book));
            }

           _context.Book.Add(book);
        }

        public IEnumerable<Book> GetAllBooks()
        {
            return _context.Book.ToList();
        }

        public Book GetBookById(int id)
        {
            return _context.Book.FirstOrDefault(x => x.Id == id);
        }

        public bool SaveChanges()
        {
           return (_context.SaveChanges() >= 0);
        }
    }
}
