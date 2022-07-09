﻿using Microsoft.AspNetCore.Http;
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
        private readonly IUserRepository _userRepository;
        private readonly ICourseRepository _courseRepository;
        private readonly IUnitOfWork _unitOfWork;
        public UserController(IUserRepository userRepository, ICourseRepository courseRepository, IUnitOfWork unitOfWork)
        {
            _userRepository = userRepository;
            _courseRepository = courseRepository;
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IActionResult GetAll(string keyword = "", int page = 1)
        {
            return Ok(_userRepository.GetPage(page, 5, keyword));
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
        public IActionResult Create(User user)
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
                _unitOfWork.Commit();
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


        [HttpPost("{ID}/Course")]
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


    }
}
