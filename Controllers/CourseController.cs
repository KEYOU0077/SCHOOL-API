using Microsoft.AspNetCore.Mvc;
using WebApplication3.Model;
using System.Collections.Generic;
using System.Linq;

namespace WebApplication3.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CourseController : ControllerBase
    {
        private static List<Course> courses = new List<Course>();

        // GET: api/Course
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(courses);
        }

        // GET: api/Course/{id}
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            Console.WriteLine($"Requested ID: {id}");
            var course = courses.FirstOrDefault(c => c.Id == id);
            if (course == null)
            {
                Console.WriteLine($"Course with ID {id} not found.");
                return NotFound($"Course with ID {id} not found.");
            }

            return Ok(course);
        }


        // POST: api/Course
        [HttpPost]
        public IActionResult Create([FromBody] Course course)
        {
            if (course == null)
                return BadRequest("Invalid course data.");

            course.Id = courses.Count > 0 ? courses.Max(c => c.Id) + 1 : 1;
            courses.Add(course);
            return CreatedAtAction(nameof(GetById), new { id = course.Id }, course);
        }

        // PUT: api/Course/{id}
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Course updatedCourse)
        {
            var course = courses.FirstOrDefault(c => c.Id == id);
            if (course == null)
                return NotFound($"Course with ID {id} not found.");

            course.Title = updatedCourse.Title;
            course.Credits = updatedCourse.Credits;

            return NoContent();
        }

        // DELETE: api/Course/{id}
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var course = courses.FirstOrDefault(c => c.Id == id);
            if (course == null)
                return NotFound($"Course with ID {id} not found.");

            courses.Remove(course);
            return NoContent();
        }
    }
}
