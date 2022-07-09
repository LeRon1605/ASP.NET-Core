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
    public class RoleController : Controller
    {
        private readonly UnitOfWork unit;
        private readonly RoleManager<IdentityRole> roleManager;
        public RoleController(RoleManager<IdentityRole> _roleManager, UnitOfWork _unit)
        {
            roleManager = _roleManager;
            unit = _unit;
        }

        public IActionResult Index()
        {
            ViewBag.Roles = roleManager.Roles.ToList();
            return View();
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(string Name)
        {
            IdentityRole role = new IdentityRole(Name);
            IdentityResult result = await roleManager.CreateAsync(role);
            if (result.Succeeded)
            {
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                return View();
            }
        }

        public async Task<IActionResult> Update(string id)
        {
            IdentityRole role = await roleManager.FindByIdAsync(id);
            if (role == null) return RedirectToAction("Index");
            return View(role);
        }
        [HttpPost]
        public async Task<IActionResult> Update(IdentityRole input)
        {
            IdentityRole role = await roleManager.FindByIdAsync(input.Id);
            if (role == null) return RedirectToAction("Index");
            role.Name = input.Name;
            await roleManager.UpdateAsync(role);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Delete(string id)
        {
            IdentityRole role = await roleManager.FindByIdAsync(id);
            if (role == null) return RedirectToAction("Index");
            await roleManager.DeleteAsync(role);
            return RedirectToAction("Index");
        }
    }
}
