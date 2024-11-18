using Microsoft.AspNetCore.Mvc;
using WebApplication3.Model;
using System.Collections.Generic;
using System.Linq;

namespace WebApplication3.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EnrollmentController : ControllerBase
    {
        private static List<Enrollment> enrollments = new List<Enrollment>();

        // GET: api/Enrollment
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(enrollments);
        }

        // GET: api/Enrollment/{id}
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var enrollment = enrollments.FirstOrDefault(e => e.Id == id);
            if (enrollment == null)
                return NotFound($"Enrollment with ID {id} not found.");

            return Ok(enrollment);
        }

        // POST: api/Enrollment
        [HttpPost]
        public IActionResult Create([FromBody] Enrollment enrollment)
        {
            if (enrollment == null)
                return BadRequest("Invalid enrollment data.");

            enrollment.Id = enrollments.Count > 0 ? enrollments.Max(e => e.Id) + 1 : 1;
            enrollments.Add(enrollment);
            return CreatedAtAction(nameof(GetById), new { id = enrollment.Id }, enrollment);
        }

        // PUT: api/Enrollment/{id}
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Enrollment updatedEnrollment)
        {
            var enrollment = enrollments.FirstOrDefault(e => e.Id == id);
            if (enrollment == null)
                return NotFound($"Enrollment with ID {id} not found.");

            enrollment.StudentId = updatedEnrollment.StudentId;
            enrollment.CourseId = updatedEnrollment.CourseId;
            enrollment.EnrollmentDate = updatedEnrollment.EnrollmentDate;

            return NoContent();
        }

        // DELETE: api/Enrollment/{id}
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var enrollment = enrollments.FirstOrDefault(e => e.Id == id);
            if (enrollment == null)
                return NotFound($"Enrollment with ID {id} not found.");

            enrollments.Remove(enrollment);
            return NoContent();
        }
    }
}
