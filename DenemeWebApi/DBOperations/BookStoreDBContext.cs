using Microsoft.EntityFrameworkCore;

namespace DenemeWebApi.DBOperations
{
    public class BookStoreDBContext : DbContext
    {
        public BookStoreDBContext(DbContextOptions<BookStoreDBContext>options):base(options){
        }    
        public DbSet<Book> Books {get;set;}
        
    }
}