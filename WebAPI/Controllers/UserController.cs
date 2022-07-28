using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using WebAPI.Helper;
using WebAPI.Models.Data;
using WebAPI.Models.Entity;
using WebAPI.Models.ViewModel;
using WebAPI.Repository;

namespace WebAPI.Controllers
{
    [Route("users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly ICourseRepository _courseRepository;
        private readonly IUnitOfWork _unitOfWork;
        public UserController(IUserRepository userRepository, ICourseRepository courseRepository, IUnitOfWork unitOfWork, ITokenProvider tokenProvider)
        {
            // Dependency injection scoped -> using the same context for all repository and unit of work
            _userRepository = userRepository;
            _courseRepository = courseRepository;
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult GetAll(string keyword = "", int page = 1)
        {
            return Ok(_userRepository.GetPage(page, 5, keyword));
        }

        [HttpGet("{ID}")]
        [Authorize]
        public IActionResult GetByID(string ID)
        {
            string userID = User.Claims.First(i => i.Type == "ID").Value;
            if (ID == userID)
            {
                User user = _userRepository.findByID(ID);
                if (user != null)
                {
                    return Ok(user);
                }
                else
                {
                    return NotFound();
                }
            }
            else
            {
                return Forbid();
            }
        }

        [HttpPut("{ID}")]
        public IActionResult Update(string ID, UserVM input)
        {
            User user = _userRepository.findByID(ID);
            if (user != null)
            {
                try
                {
                    user.Name = input.Name;
                    user.Address = input.Address;
                    user.Email = user.Email;
                    user.CourseID = user.CourseID;
                    _userRepository.Update(user);
                    _unitOfWork.Commit();
                    return Ok();
                }
                catch
                {
                    return StatusCode(StatusCodes.Status500InternalServerError);
                }
            }
            else
            {
                return NotFound();
            }
        }    

        [HttpDelete("{ID}")]
        public IActionResult Delete(string ID)
        {
            User user = _userRepository.findByID(ID);
            if (user != null)
            {
                try
                {
                    _userRepository.Delete(ID);
                    _unitOfWork.Commit();
                    return Ok();
                }
                catch
                {
                    return StatusCode(StatusCodes.Status500InternalServerError);
                }
            }
            else
            {
                return NotFound();
            }
        }


        [HttpPost("{ID}/course")]
        public IActionResult Register(string ID, string CourseID)
        {
            User user = _userRepository.findByID(ID);
            if (user == null)
            {
                return NotFound("User not found");
            }
            Course course = _courseRepository.findByID(CourseID);
            if (course == null)
            {
                return NotFound("Course not found");
            }
            user.Course = course;
            try
            {
                _userRepository.Update(user);
                _unitOfWork.Commit();
                return Ok();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpDelete("{ID}/course")]
        public ActionResult Drop(string ID)
        {
            User user = _userRepository.findByID(ID);
            if (user == null)
            {
                return NotFound("User not found");
            }
            Course course = _userRepository.GetCourseOfUser(ID);
            if (course == null)
            {
                return NotFound(new 
                { 
                    status = false, 
                    message = "User has not registered to any course yet"
                });
            }
            else
            {
                user.Course = null;
                try
                {
                    _userRepository.Update(user);
                    _unitOfWork.Commit();
                    return Ok(new
                    {
                        status = true,
                        message = "Drop Course Successfully"
                    });
                }
                catch
                {
                    return StatusCode(StatusCodes.Status500InternalServerError);
                }
            }
        }
    }
}
