using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using WebApplication3.Model;

namespace WebApplication3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        // Temporary in-memory storage for demonstration
        private static List<Student> students = new List<Student>();

        // GET: api/Student
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(students);
        }

        // GET: api/Student/{id}
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var student = students.FirstOrDefault(s => s.Id == id);
            if (student == null)
                return NotFound($"Student with ID {id} not found.");

            return Ok(student);
        }

        // POST: api/Student
        [HttpPost]
        public IActionResult Create([FromBody] Student student)
        {
            if (student == null)
                return BadRequest("Invalid student data.");

            student.Id = students.Count > 0 ? students.Max(s => s.Id) + 1 : 1;
            students.Add(student);
            return CreatedAtAction(nameof(GetById), new { id = student.Id }, student);
        }

        // PUT: api/Student/{id}
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Student updatedStudent)
        {
            var student = students.FirstOrDefault(s => s.Id == id);
            if (student == null)
                return NotFound($"Student with ID {id} not found.");

            student.Name = updatedStudent.Name;
            student.EnrollmentDate = updatedStudent.EnrollmentDate;

            return NoContent();
        }

        // DELETE: api/Student/{id}
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var student = students.FirstOrDefault(s => s.Id == id);
            if (student == null)
                return NotFound($"Student with ID {id} not found.");

            students.Remove(student);
            return NoContent();
        }
    }
}

