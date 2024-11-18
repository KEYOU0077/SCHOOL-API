using System.ComponentModel.DataAnnotations;

namespace WebApplication3.Model
{
    public class Course
    {
        [Key]
        public int Id { get; set; }

        public string Title { get; set; }

        public int Credits { get; set; }
    }
}
