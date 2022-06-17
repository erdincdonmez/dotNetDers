using Microsoft.EntityFrameworkCore;

namespace DenemeWebApi.DBOperations
{
    public class BookStoreDbContext : DbContext
    {
        public BookStoreDbContext(DbContextOptions<BookStoreDbContext>options):base(options){
        }    
        public DbSet<Book> Books {get;set;}
        
    }
}