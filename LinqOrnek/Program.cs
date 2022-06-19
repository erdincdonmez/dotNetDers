// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");
//DataGenerator.Initialize();
using LinqOrnek.DbOperations;

namespace LinqOrnek
{
    class Program
    {
        static void Main(String[] args)
        {
            DataGenarator.Initialize();
            LinqDbContext _context = new LinqDbContext(); 
            var Students = _context.Students.ToList<Student>();
        }
    }
}

