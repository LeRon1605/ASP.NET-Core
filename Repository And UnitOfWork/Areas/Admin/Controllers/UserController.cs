using FirstProject_MVC.Models.Entity;
using FirstProject_MVC.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repository_And_UnitOfWork.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : Controller
    {
        private readonly UnitOfWork unit;
        private readonly UserManager<User> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        public UserController(RoleManager<IdentityRole> _roleManager, UnitOfWork _unit, UserManager<User> _userManager)
        {
            userManager = _userManager;
            roleManager = _roleManager;
            unit = _unit;
        }
        public IActionResult Index()
        {
            List<User> users = userManager.Users.ToList();
            return View(users);
        }

        public async Task<IActionResult> AddRole(string id)
        {
            User user = await userManager.FindByIdAsync(id);
            List<IdentityRole> roles = roleManager.Roles.ToList();

            return View();
        }
    }
}
