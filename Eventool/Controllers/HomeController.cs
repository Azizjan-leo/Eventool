using Eventool.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Eventool.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        RoleManager<IdentityRole> _roleManager;
        UserManager<IdentityUser> _userManager;

        public HomeController(ILogger<HomeController> logger, RoleManager<IdentityRole> roleManager, UserManager<IdentityUser> userManager)
        {
            _logger = logger;
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {

            var adminRole = new IdentityRole(nameof(Boost.Enums.Roles.Admin));
            await _roleManager.CreateAsync(adminRole);
            var adminUser = new IdentityUser
            {
                Email = "artemartemovsk11@gmail.com",
                UserName = "artemartemovsk11@gmail.com",
                EmailConfirmed = true,
            };
            var result = await _userManager.CreateAsync(adminUser, "Password123!!");
            await _userManager.AddToRoleAsync(adminUser, nameof(Boost.Enums.Roles.Admin));
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
