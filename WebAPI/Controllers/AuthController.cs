using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Helper;
using WebAPI.Models.Entity;
using WebAPI.Models.ViewModel;
using WebAPI.Repository;

namespace WebAPI.Controllers
{
    [Route("auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ITokenProvider _tokenProvider;
        public AuthController(IUserRepository userRepository, ICourseRepository courseRepository, IUnitOfWork unitOfWork, ITokenProvider tokenProvider)
        {
            // Dependency injection scoped -> using the same context for all repository and unit of work
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
            _tokenProvider = tokenProvider;
        }

        [HttpPost("login")]
        public IActionResult Login(LoginVM input)
        {
            User user = _userRepository.GetByEmail(input.Email);
            if (user == null)
            {
                return NotFound(new
                {
                    status = false,
                    message = "Tài khoản không tồn tại"
                });
            }
            else
            {
                if (user.Password != input.Password)
                {
                    return NotFound(new
                    {
                        status = false,
                        message = "Mật khẩu không đúng"
                    });
                }
                else
                {
                    // Cấp Token
                    return Ok(new
                    {
                        status = true,
                        message = "Login successfully",
                        token = _tokenProvider.GenerateToken(user)
                    });
                }
            }
        }

        [HttpPost("register")]
        public IActionResult Register(User user)
        {
            if (_userRepository.GetByEmail(user.Email) != null)
            {
                return BadRequest(new
                {
                    status = false,
                    message = "Email already exist"
                });
            }    
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
                _unitOfWork.Commit();
                return StatusCode(201);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
