using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Security.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Security.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Index()
        {
            return View();
        }

        [Authorize(Policy = "Admin")]
        public IActionResult Secret()
        {
            return View("Index");
        }

        public async Task<IActionResult> Service([FromServices] IAuthorizationService authorizationService)
        {
            var result = await authorizationService.AuthorizeAsync(User, "Admin");
            if (result.Succeeded)
            {
                return View("Index");
            }
            return Unauthorized();
        }
        
        public async Task<IActionResult> Login()
        {
            Claim[] claims = new Claim[]
            {
                new Claim("ID", "1abc"),
                new Claim(ClaimTypes.Role, "Admin"),
                new Claim(ClaimTypes.Name, "Lê Rôn")
            };

            ClaimsIdentity identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(identity);

            await HttpContext.SignInAsync(claimsPrincipal);
            return RedirectToAction("Index");
        }
    }
}
