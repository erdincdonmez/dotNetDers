using System;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using DenemeWebApi.DBOperations;
using Microsoft.EntityFrameworkCore;

namespace DenemeWebApi.BookOperations.GetBooks
{
    public class GetBooksQuery
    {
        private readonly BookStoreDbContext _dbContext;
        public GetBooksQuery (BookStoreDbContext _dbContext)
        {
            _dbContext = DbContext;
        }
        public List<Book> Handle()
        {
            List<Book> booklist = _dbContext.Books.OrderBy(x => x.Id).ToList<Book>();
            return booklist;

        }
    }


}