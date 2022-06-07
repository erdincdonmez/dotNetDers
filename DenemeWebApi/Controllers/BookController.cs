using System;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace DenemeWebApi.AddControllers
{

    [ApiController]
    [Route("[controller]s")]
    public class BookController : ControllerBase
    {
        private static List<Book> BookList = new List<Book>{
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

        [HttpGet]
        public List<Book> GetBooks()
        {
            List<Book> booklist = BookList.OrderBy(x => x.Id).ToList<Book>();
            return booklist;
        }
        [HttpGet("{id}")]
        public Book GetById(int id)
        {
            var book = BookList.Where(book => book.Id == id).SingleOrDefault();
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
        public IActionResult AddBook([FromBody] Book newBook) {
            var book = BookList.SingleOrDefault(x => x.Title == newBook.Title);
            if (book is not null) {
                return BadRequest();
            }
            BookList.Add(newBook);
            return Ok();
        }
        [HttpPut("{id}")]
        public IActionResult UpdateBook(int id, [FromBody] Book updateBook)
        {
            var book = BookList.SingleOrDefault(x => x.Id == id);
            if (book is null)
            {
                BadRequest();

            }
            book.GenreId = book.GenreId != default ? updateBook.GenreId : book.GenreId; ;
            book.PageCount = book.PageCount != default ? updateBook.PageCount : book.PageCount; ;
            book.PublishDate = book.PublishDate != default ? updateBook.PublishDate : book.PublishDate; ;
            book.Title = book.Title != default ? updateBook.Title : book.Title; ;
            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id)
        {
            var book = BookList.SingleOrDefault(x => x.Id == id);
            if (book is null)
                BadRequest();
            BookList.Remove(book);
            return Ok();
        } 
    }
}