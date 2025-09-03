using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryService.WebAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace LibraryService.WebAPI.Services
{
    public class LibrariesService : ILibrariesService
    {
        private readonly LibraryContext _libraryContext;

        public LibrariesService(LibraryContext libraryContext)
        {
            _libraryContext = libraryContext;
        }

        public IEnumerable<Library> Get(int[] ids)
        {
            throw new NotImplementedException();
        }

        public Library Add(Library library)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Library> AddRange(IEnumerable<Library> projects)
        {
            throw new NotImplementedException();
        }

        public Library Update(Library library)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Library library)
        {
            throw new NotImplementedException();
        }
       
    }

    public interface ILibrariesService
    {
        IEnumerable<Library> Get(int[] ids);

        Library Add(Library library);

        Library Update(Library library);

        bool Delete(Library library);
    }
}
