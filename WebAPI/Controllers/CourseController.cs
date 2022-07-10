using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models.Entity;
using WebAPI.Models.ViewModel;
using WebAPI.Repository;

namespace WebAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourseRepository _courseRepository;
        private readonly IUnitOfWork _unitOfWork;
        public CourseController(ICourseRepository courseRepository, IUnitOfWork unitOfWork)
        {
            // Dependency injection scoped -> using the same context for all repository and unit of work
            _courseRepository = courseRepository;
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_courseRepository.findAll().Select(course => new CourseVM { 
                ID = course.ID,
                Credit = course.Credit,
                Name = course.Name
            }));
        }

        [HttpPost]
        public IActionResult Create(CourseVM input)
        {
            Course course = new Course
            {
                ID = Guid.NewGuid().ToString(),
                Name = input.Name,
                Credit = input.Credit
            };
            try
            {
                _courseRepository.Add(course);
                _unitOfWork.Commit();
                return StatusCode(StatusCodes.Status201Created);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        [HttpPut("{ID}")]
        public IActionResult Update(string ID, CourseVM input)
        {
            if (string.IsNullOrEmpty(ID))
            {
                return BadRequest(new
                {
                    status = false,
                    message = "ID required"
                });
            }    
            Course course = _courseRepository.findByID(ID);
            if (course == null)
            {
                return NotFound(new
                {
                    status = false,
                    message = "Course Not Found"
                });
            }
            course.Name = input.Name;
            course.Credit = input.Credit;
            try
            {
                _courseRepository.Update(course);
                _unitOfWork.Commit();
                return Ok(new
                {
                    status = true,
                    message = "Update successfully"
                });
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpDelete("{ID}")]
        public IActionResult Delete(string ID)
        {
            if (string.IsNullOrEmpty(ID))
            {
                return BadRequest("Invalid ID");
            }
            else
            {
                Course course = _courseRepository.findByID(ID);
                if (course == null)
                {
                    return NotFound("Course Not Found");
                }
                try
                {
                    _courseRepository.Delete(ID);
                    _unitOfWork.Commit();
                    return Ok("Delete successfully");
                }
                catch
                {
                    return StatusCode(StatusCodes.Status500InternalServerError);
                }
            }
        }

        [HttpGet("{ID}/users")]
        public IActionResult GetUsers(string ID)
        {
            if (string.IsNullOrEmpty(ID))
            {
                return BadRequest("Invalid ID");
            }
            else
            {
                return Ok(_courseRepository.GetUserOfCourse(ID));
            }
        }    
    }
}
