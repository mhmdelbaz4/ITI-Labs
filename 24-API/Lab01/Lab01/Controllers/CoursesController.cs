using Lab01.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Lab01.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly Context _context;

        public CoursesController(Context context)
        {
            _context = context;
        }


        [HttpGet]
        public IActionResult get()
        {
            List<Course> courses = _context.Courses.ToList();
            if(courses is null)
                return NotFound();

            return Ok(courses);
        }

        [HttpDelete("{id:int}")]
        public IActionResult deleteCourse(int id)
        {
            Course? course = _context.Courses.FirstOrDefault(c => c.Id == id);
            if(course is null)
                return NotFound();

            _context.Courses.Remove(course);
            _context.SaveChanges();
            return Ok();
        }


        [HttpPut("{id:int}")]
        public IActionResult put([FromRoute] int id,Course course)
        {
            if(id != course.Id)
                return BadRequest();

            bool existed= _context.Courses.Any(c => c.Id == id);
            if (!existed)
                return NotFound();

            if(! ModelState.IsValid)
                return BadRequest();

            _context.Entry(course).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();

            return NoContent();
        }


        [HttpPost]
        public IActionResult post(Course course)
        {
            if(course is null)
                return BadRequest();

            if(! ModelState.IsValid)
                return BadRequest();

            _context.Courses.Add(course);
            _context.SaveChanges();
            return Created(nameof(getById),course);   
        }

        [HttpGet("{id:int}")]
        public IActionResult getById(int id)
        {
            Course? course = _context.Courses.Find(id);
            if(course is null)
                return NotFound();
            
            return Ok(course);
        }

        [HttpGet("{name:alpha}")]
        public IActionResult courseByName(string name)
        {
            Course? course = _context.Courses
                            .FirstOrDefault(c => string.Equals(c.CrsName,name));
            if (course is null)
                return NotFound();

            return Ok(course);
        }
    }
}
