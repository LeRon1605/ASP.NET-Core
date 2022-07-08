using FirstProject_MVC.Models;
using FirstProject_MVC.Models.Data;
using FirstProject_MVC.Models.Entity;
using FirstProject_MVC.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;
using Repository_And_UnitOfWork.Models.ViewModel;
using Repository_And_UnitOfWork.Utils;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstProject_MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly UnitOfWork unit;
        private readonly SignInManager<User> signInManager;
        private readonly UserManager<User> userManager;
        private readonly IEmailSender mail;
        public HomeController(UnitOfWork _unit, SignInManager<User> _signInManager, UserManager<User> _userManager, IEmailSender _mail)
        {
            unit = _unit;
            signInManager = _signInManager;
            userManager = _userManager;
            mail = _mail;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterModel input)
        {
            if (ModelState.IsValid)
            {
                User user = new User { UserName = input.UserName, Email = input.Email };
                IdentityResult result = await userManager.CreateAsync(user, input.Password);

                if (result.Succeeded)
                {
                    string code = await userManager.GenerateEmailConfirmationTokenAsync(user);
                    string callbackUrl = Url.ActionLink("ConfirmEmail", "Home", new { userId = user.Id, code = code }, Request.Scheme, Request.Host.ToString());

                    await mail.SendEmailAsync(input.Email, "Xác nhận địa chỉ email",
                        $"Hãy xác nhận địa chỉ email bằng cách <a href='{callbackUrl}'>Bấm vào đây</a>.");

                    if (userManager.Options.SignIn.RequireConfirmedEmail)
                    {
                        return RedirectToPage("RegisterConfirmation", new { email = input.Email });
                    }
                    else
                    {
                        await signInManager.SignInAsync(user, isPersistent: false);
                        return RedirectToAction("Index");
                    }
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            return View();
        }

        public async Task<IActionResult> ConfirmEmail(string code, string userId)
        {
            User user = await userManager.FindByIdAsync(userId);
            if (user == null) return NotFound();
            IdentityResult result = await userManager.ConfirmEmailAsync(user, code);
            if (result.Succeeded)
            {
                ViewBag.Message = "Xác thực thành công";
                await signInManager.SignInAsync(user, true);
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Message = "Xác thực thất bại";
                return RedirectToAction("Index");
            }
        }
        [HttpGet]
        public IActionResult Login()
        {
            if (signInManager.IsSignedIn(User))
            {
                return RedirectToAction("Index");
            }    
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginModel input)
        {
            if (signInManager.IsSignedIn(User))
            {
                return RedirectToAction("Index");
            }
            else
            {
                User user = await userManager.FindByEmailAsync(input.Email);
                if (user != null && await userManager.CheckPasswordAsync(user, input.Password))
                {
                    await signInManager.SignInAsync(user, true);
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.Message = "Lỗi đăng nhập";
                    return RedirectToAction("Login");
                }   
            }
        }

        public async Task<IActionResult> Logout()
        {
            if (signInManager.IsSignedIn(User))
            {
                await signInManager.SignOutAsync();
            }    
            return RedirectToAction("Index");
        }
    }
}
