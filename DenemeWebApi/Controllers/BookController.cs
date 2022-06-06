using System;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace DenemeWebApi.AddControllers{
     
    [ApiController]
    [Route("[controller]s")]
    public class BookController : ControllerBase{
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
        public List<Book> GetBooks(){
            List<Book> booklist = BookList.OrderBy(x => x.Id).ToList<Book>();
            return booklist;
        }
        [HttpGet("{id}")]
        public Book GetById(int id){
            var book = BookList.Where(book => book.Id==id).SingleOrDefault();
            return book;
        }
        /*
        [HttpGet]
        public Book Get ([FromQuery] string id){
            var book = BookList.Where(book => book.Id==Convert.ToInt32(id)).SingleOrDefault();
            return book;
        }
        */

    }
}