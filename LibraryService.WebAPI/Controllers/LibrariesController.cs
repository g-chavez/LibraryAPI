using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LibraryService.WebAPI.Data;
using LibraryService.WebAPI.Services;
using System;
using Microsoft.AspNetCore.Http.HttpResults;

namespace LibraryService.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LibrariesController : ControllerBase
    {
        private readonly ILibrariesService _librariesService;
        private readonly IBooksService _booksService;

        public LibrariesController(ILibrariesService librariesService, IBooksService booksService)
        {
            _librariesService = librariesService;
            _booksService = booksService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var libraries = await Task.Run(() => _librariesService.Get(null));
            return Ok(libraries);
        }

        [HttpGet("{libraryId}")]
        public async Task<IActionResult> Get(int libraryId)
        {
            var library = await (Task.Run( ()=>  _librariesService.Get(new[] { libraryId }).FirstOrDefault()));
            if (library == null)
                return NotFound(null);
            return Ok(library);
        }

        [HttpPost]
        public async Task<IActionResult> Add(Library l)
        {
            await Task.Run(() => _librariesService.Add(l));
            return Ok(l);
        }

        [HttpPut("{libraryId}")]
        public async Task<IActionResult> Update(int libraryId, Library library)
        {
            var existingLibrary = await (Task.Run(() => _librariesService.Get(new[] { libraryId }).FirstOrDefault()));
            if (existingLibrary == null)
                return NotFound(null);

            await Task.Run(() => _librariesService.Update(library));
            return NoContent();
        }

        [HttpPost("{libraryId}/books")]
        public async Task<IActionResult> AddBook([FromRoute] int libraryId, [FromBody] Book book)
        {
            var library = await (Task.Run(() => _librariesService.Get([libraryId]).FirstOrDefault()));
            if (library == null)
                return NotFound(null);


            book.LibraryId = libraryId;
            await Task.Run(() => _booksService.Add(book));
            
            return Created();

        }

        [HttpGet("{libraryId}/books")]
        public async Task<IActionResult> GetBooks(int libraryId)
        {
            var library = await (Task.Run(() => _librariesService.Get(new[] { libraryId }).FirstOrDefault()));
            if (library == null)
                return NotFound(null);

            var books = await Task.Run(()=> _booksService.Get(libraryId, null));

            //if (books == null || !books.Any())
            //    return NotFound(null);

            return Ok(Newtonsoft.Json.JsonConvert.SerializeObject(books));
        }

        [HttpDelete("{libraryId}")]
        public async Task<IActionResult> Delete(int libraryId)
        {
            var library = await Task.Run(()=> _librariesService.Get(new[] {libraryId}));
            if (library == null || !library.Any())
                return NotFound(null);


            var libraryItem = new Library()
            {
                Id = libraryId
            };

            var result = await Task.Run(() => _librariesService.Delete(libraryItem));

            

            return NoContent();
        }

        
    }
}
