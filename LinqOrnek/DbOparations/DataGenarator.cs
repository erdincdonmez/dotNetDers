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
                            Name = "Erdinç",
                            SureName = "Dönmez",
                            ClassId = 3
                        },
                        new Student() {
                            Name = "Erdinç2",
                            SureName = "Dönmez2",
                            ClassId = 2
                        },
                        new Student() {
                            Name = "Erdinç3",
                            SureName = "Dönmez3",
                            ClassId = 33
                        },
                        new Student() {
                            Name = "Erdinç4",
                            SureName = "Dönmez4",
                            ClassId = 4
                        },
                        new Student() {
                            Name = "Erdinç",
                            SureName = "Dönmez4",
                            ClassId = 5
                        }
                    );
                    context.SaveChanges();
                }
            }
        }
    }
}
