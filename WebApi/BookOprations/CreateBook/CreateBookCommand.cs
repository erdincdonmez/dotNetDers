using System;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using WebApi.DBOperations;
using Microsoft.EntityFrameworkCore;
using WebApi.Common;

//namespace WebApi.BookOperations.GetBooks
namespace WebApi.BookOperations.CreateBook
{
    public class GetBookCommand
    {
        public CreateBookModel Model { get; set; }
        private readonly BookStoreDbContext _dbContext;
        public CreateBookCommand (BookStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Handle()
        {
            var book = _dbContext.Books.SingleOrDefault(x => x.Title == Model.Title);
            if (book is not null) 
                throw new InvalidOperationException("Kitap mevcut");
            book = new Book();
            book.Title = Model.Title;
            book.PageCount = Model.PageCount;
            book.GenreId = Model.GenreId;
            _dbContext.Books.Add(book);
            _dbContext.SaveChanges();
            
        }
        public class CreateBookModel
        {
            public String Title { get; set; }   
            public int GenreId { get; set; }
            public int PageCount { get; set; }
            public DateTime PublishDate { get; set; }
        }
    }
}