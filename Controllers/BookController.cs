using LibraryManagementSystem.Data;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using LibraryManagementSystem.Dtos;
using LibraryManagementSystem.Models;
using LibraryManagementSystem.SyncDataService.Http;

namespace LibraryManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : Controller
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;
        private readonly ICommandDataClient _commandDataClient;

        public BookController(
            IBookRepository bookRepository, 
            IMapper mapper,
            ICommandDataClient commandDataClient)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
            _commandDataClient = commandDataClient;
        }

        [HttpGet]
        public ActionResult<IEnumerable<BookController>> GetBooks()
        {
            return Ok(_bookRepository.GetAllBooks());
        }

        [HttpGet("{id}", Name = "GetBookById")]
        public ActionResult<BookController> GetBookById(int id)
        {
           var book = _bookRepository.GetBookById(id);

            if (book == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<BookReadDto>(book));

        }

        [HttpPost]
        public async Task<ActionResult<BookCreateDto>> CreateBook(BookCreateDto bookCreateDto)
        {
            var bookModel = _mapper.Map<Book>(bookCreateDto);
            _bookRepository.CreateBook(bookModel);
            _bookRepository.SaveChanges();

            var bookReadDto = _mapper.Map<BookReadDto>(bookModel);

            try
            {
                await _commandDataClient.SendBookToCommand(bookReadDto);
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Could not set synchonously {ex.Message}");
            }

            return CreatedAtRoute(nameof(GetBookById), new { Id = bookReadDto.Id }, bookReadDto);

        }


    }
}
