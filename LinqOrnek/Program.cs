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

            //find
            Console.WriteLine("\n\n\n=== ARAMA Find ===");
            var student = _context.Students.Where(student => student.StudentId==1).FirstOrDefault();
            student = _context.Students.Find(2);
            Console.WriteLine(student.Name);

            Console.WriteLine("\n=== First or default1 ===");
            student = _context.Students.Where(student => student.SureName=="Dönmez3").FirstOrDefault();
            Console.WriteLine(student.Name);

            Console.WriteLine("\n=== First or default2 ===");
            student = _context.Students.FirstOrDefault(x => x.SureName=="Dönmez3");
            Console.WriteLine(student.Name);

            Console.WriteLine("\n=== Single or default ===");
            student = _context.Students.SingleOrDefault(x => x.SureName=="Dönmez3"); 
            // Birden fazla veri gelirse hata verir.
            Console.WriteLine(student.Name);

            Console.WriteLine("\n=== Listeleme - to list ===");
            var StudentList = _context.Students.Where(listelenecek => listelenecek.Name=="Erdinç").ToList();
            //student = _context.Students.ToList(x => x.SureName=="Dönmez3");
            Console.WriteLine(StudentList.Count);

            Console.WriteLine("\n=== Sıralama - OrderBy ===");
            Students = _context.Students.OrderBy(x=>x.Name).ToList();
            foreach (var a in Students) Console.WriteLine(a.Name);

            Console.WriteLine("\n=== Sıralama Tersten - OrderByDescending ===");
            Students = _context.Students.OrderByDescending(x=>x.Name).ToList();
            foreach (var a in Students) Console.WriteLine(a.Name);

            Console.WriteLine("\n=== Anonymous Ocbject result ===");
            var AnonimObje = _context.Students.Where(x => x.Name == "Erdinç").Select(x => new{id = x.StudentId, adSoyad = x.Name + " "+x.SureName});
            foreach (var aa in AnonimObje) Console.WriteLine(aa.adSoyad);


            Console.WriteLine("\n\n\n");
        }
    }
}

