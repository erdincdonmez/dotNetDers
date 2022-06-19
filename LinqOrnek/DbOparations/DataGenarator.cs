namespace LinqOrnek.DbOperations
{
    public class DataGenarator
    {
        public static void Initialize()
        {
            using (var context = new LinqDbContext())
            {
                if (context.Students.Any()) return;
                else{
                    context.Students.AddRange(
                        new Student() {
                            StudentId = 1,
                            Name = "Erdinç",
                            SureName = "Dönmez",
                            ClassId = 3
                        },
                        new Student() {
                            StudentId = 2,
                            Name = "Erdinç2",
                            SureName = "Dönmez2",
                            ClassId = 2
                        },
                        new Student() {
                            StudentId = 3,
                            Name = "Erdinç3",
                            SureName = "Dönmez3",
                            ClassId = 33
                        },
                                                new Student() {
                            StudentId = 4,
                            Name = "Erdinç4",
                            SureName = "Dönmez4",
                            ClassId = 4
                        }
                    );
                    context.SaveChanges();
                }
            }
        }
    }
}