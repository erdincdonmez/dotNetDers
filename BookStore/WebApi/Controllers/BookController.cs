using Microsoft.AspNetCore.Mvc;
//using System.Collections.Generic;
namespace WebApi.AddControllers{
     
    [ApiController]
    [Route("[controller]s")]
    public class BookController : ControllerBase{
        private static List<Book> BookList = new List<Book>{
            new Book{
                id = 1,
                Title = "Deneme Kitap Başlığı1",
                GenreId = 3,
                PageCount = 100,
                PublishDate = new DateTime(2022,05,06),
            },
            new Book{
                id = 2,
                Title = "Deneme Kitap Başlığı1",
                GenreId = 1,
                PageCount = 200,
                PublishDate = new DateTime(2022,05,06),
            },
            new Book{
                id = 3,
                Title = "Deneme Kitap Başlığı1",
                GenreId = 4,
                PageCount = 300,
                PublishDate = new DateTime(2022,05,06),
            },
        };
        [HttpGet]
        public List<Book> GetBooks(){
            var booklist = BookList.OrderBy(x=>id).ToList<Book>();
            return booklist;
        }
        [HttpPost]
        public IActionResult AddBook([fromBody] new Book){
            var book = BookList.SingleOrDefault(x => x.Title == newBook.Title);
            if (book is not null){
                return BadRequest();
            }
            BookList.AddBook(newBook);
            return Ok();
        }

    }
}