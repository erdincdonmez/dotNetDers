using System;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using WebApi.DBOperations;
using WebApi.BookOperations.GetBooks;
using System.Data;

namespace WebApi.AddControllers
{
using static WebApi.BookOperations.CreateBook.CreateBookCommand;

    [ApiController]
    [Route("[controller]s")]
    public class BookController : ControllerBase
    {
        private readonly BookStoreDbContext _context;
        public BookController (BookStoreDbContext context)
        //public CreateBookCommand (BookStoreDbContext dbContext)
        {
            _context = context;
        }
/*         private static List<Book> BookList = new List<Book>{
            new Book{
                Id = 1,
                Title = "Deneme Kitap Başlığı1",
                GenreId = 3,
                PageCount = 100,
                PublishDate = new DateTime(2022,05,06),
            },
            new Book{
                Id = 4,
                Title = "Deneme Kitap Başlığı4",
                GenreId = 1,
                PageCount = 200,
                PublishDate = new DateTime(2022,05,06),
            },
            new Book{
                Id = 3,
                Title = "Deneme Kitap Başlığı1",
                GenreId = 4,
                PageCount = 300,
                PublishDate = new DateTime(2022,05,06),
            },
        };
 */
        [HttpGet]
        /*public List<Book> GetBooks()
        {
            //List<Book> booklist = BookList.OrderBy(x => x.Id).ToList<Book>();
            List<Book> booklist = _context.Books.OrderBy(x => x.Id).ToList<Book>();
            return booklist;
        }*/
        public IActionResult GetBooks()
        {
            GetBooksQuery query = new GetBooksQuery(_context);
            var result = query.Handle();
            return Ok(result);
        }
        [HttpGet("{id}")]
        public Book GetById(int id)
        {
            //var book = BookList.Where(book => book.Id == id).SingleOrDefault();
            var book = _context.Books.Where(book => book.Id == id).SingleOrDefault();
            return book;
        }
        /*
        [HttpGet]
        public Book Get ([FromQuery] string id){
            var book = BookList.Where(book => book.Id==Convert.ToInt32(id)).SingleOrDefault();
            return book;
        }
        */
        [HttpPost]
        public IActionResult AddBook([FromBody] CreateBookModel newBook) 
        {

            CreateBookCommand command = new CreateBookCommand(_context);
            try
            {
                command.Model = newBook;
                command.Handle();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
            /*var book = _context.Books.SingleOrDefault(x => x.Title == newBook.Title);
            if (book is not null) {
                return BadRequest();
            }
            //BookList.Add(newBook);
            _context.Books.Add(newBook);
            _context.SaveChanges();*/
            return Ok();
        }
        [HttpPut("{id}")]
        public IActionResult UpdateBook(int id, [FromBody] Book updateBook)
        {
            var book = _context.Books.SingleOrDefault(x => x.Id == id);
            if (book is null)
            {
                BadRequest();

            }
            book.GenreId = book.GenreId != default ? updateBook.GenreId : book.GenreId; ;
            book.PageCount = book.PageCount != default ? updateBook.PageCount : book.PageCount; ;
            book.PublishDate = book.PublishDate != default ? updateBook.PublishDate : book.PublishDate; ;
            book.Title = book.Title != default ? updateBook.Title : book.Title; ;

            _context.SaveChanges();
            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id) // to delete.
        {
            var book = _context.Books.SingleOrDefault(x => x.Id == id);
            if (book is null)
                BadRequest();
            _context.Books.Remove(book);
            _context.SaveChanges();
            return Ok();
        } 
    }
}