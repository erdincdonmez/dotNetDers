using System;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using DenemeWebApi.DBOperations;
using Microsoft.EntityFrameworkCore;
using DenemeWebApi.Common;

namespace DenemeWebApi.BookOperations.GetBooks
{
    public class GetBooksQuery
    {
        private readonly BookStoreDbContext _dbContext;
        public GetBooksQuery (BookStoreDbContext _dbContext)
        {
            _dbContext = dbContext;
        }
        public List<BooksViewModel> Handle()
        {
            List<Book> booklist = _dbContext.Books.OrderBy(x => x.Id).ToList<Book>();
            List<BooksViewModel> vm = new List<BooksViewModel>(); 
            foreach (var book in booklist)
            {
                vm.Add(new BooksViewModel(){
                        Title = book.Title,
                        Genre = ((GenreEnum).Books.GenreId).ToString(),
                        PublishDate = book.PublishDate.Date.ToString("dd/MM/yyyy"),
                        PageCount = book.PageCount,
                    }
                );

            }
            return vm;

        }
        public class BooksViewModel
        {
            public string Title { get; set; }   
            public int PageCount { get; set; }
            public string PublishDate { get; set; } 
            public string Genre { get; set; }
        }
    }


}