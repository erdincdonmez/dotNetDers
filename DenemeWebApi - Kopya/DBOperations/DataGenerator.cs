using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DenemeWebApi.DBOperations
{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider){
            using (var context = new BookStoreDbContext(serviceProvider.GetRequiredService<DbContextOptions<BookStoreDbContext>>()))
            {
                if (context.Books.Any()) return;
                context.Books.AddRange(
                    new Book{
                        //Id = 1,
                        Title = "Deneme Kitap Başlığı1",
                        GenreId = 3,
                        PageCount = 100,
                        PublishDate = new DateTime(2022,05,06),
                    },
                    new Book{
                        //Id = 4,
                        Title = "Deneme Kitap Başlığı44",
                        GenreId = 1,
                        PageCount = 200,
                        PublishDate = new DateTime(2022,05,06),
                    },
                    new Book{
                        //Id = 3,
                        Title = "Deneme Kitap Başlığı1",
                        GenreId = 4,
                        PageCount = 300,
                        PublishDate = new DateTime(2022,05,06),
                    }

                );
                context.SaveChanges();
            }
        }
    }
}