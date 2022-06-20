using System.ComponentModel.DataAnnotations.Schema;

namespace LinqOrnek
{
    public class Student
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StudentId { get; set; }
        public string Name { get; set; }
        public string SureName { get; set; }
        public int ClassId { get; set; }
    }
}