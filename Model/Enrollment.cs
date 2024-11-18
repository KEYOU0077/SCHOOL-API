using System.ComponentModel.DataAnnotations;

namespace WebApplication3.Model
{
    public class Enrollment
    {
        [Key]
        public int Id { get; set; }

        public int StudentId { get; set; }

        public int CourseId { get; set; }

        public DateTime EnrollmentDate { get; set; }
    }
}
