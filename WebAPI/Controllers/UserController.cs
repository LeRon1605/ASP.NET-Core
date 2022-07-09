using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models.Data;
using WebAPI.Models.Entity;
using WebAPI.Models.ViewModel;
using WebAPI.Repository;

namespace WebAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly DemoDbContext _context;
        private readonly IUserRepository _userRepository;
        public UserController(DemoDbContext context, IUserRepository userRepository)
        {
            _context = context;
            _userRepository = userRepository;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_userRepository.findAll().ToList());
        }

        [HttpGet("{ID}")]
        public IActionResult GetByID(string ID)
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

        [HttpPost]
        public IActionResult Create(UserVM user)
        {
            User newUser = new User
            {
                ID = Guid.NewGuid().ToString(),
                Name = user.Name,
                Address = user.Address,
                Email = user.Email,
                Password = user.Password,
                CourseID = user.CourseID
            };
            try
            {
                _userRepository.Add(newUser);
                return StatusCode(201);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
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
    }
}
