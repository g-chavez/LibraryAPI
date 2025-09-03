using LibraryService.WebAPI.Data;

namespace LibraryService.WebAPI.Services
{
    public class BooksService : IBooksService
    {
        private readonly LibraryContext _libraryContext;

        public BooksService(LibraryContext libraryContext)
        {
            _libraryContext = libraryContext;
        }

        public IEnumerable<Book> Get(int libraryId, int[] ids)
        {
            // Complete the implementation
            throw new NotImplementedException();
        }

        public Book Add(Book book)
        {
            // Complete the implementation
            throw new NotImplementedException();
        }

        public Book Update(Book book)
        {
            // Complete the implementation
            throw new NotImplementedException();
        }

        public bool Delete(Book book)
        {
            // Complete the implementation
            throw new NotImplementedException();
        }
    }

    public interface IBooksService
    {
        IEnumerable<Book> Get(int libraryId, int[] ids);

        Book Add(Book book);

        Book Update(Book book);

        bool Delete(Book book);
    }
}
