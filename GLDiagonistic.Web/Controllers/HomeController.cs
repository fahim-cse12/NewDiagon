using GLDiagonistic.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace GLDiagonistic.Web.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            string selectedMenu = HttpContext.Request.Cookies["selectedMenu"]; // Use the appropriate key

            if (!string.IsNullOrEmpty(selectedMenu))
            {
                // Clear the local storage data by setting it to an empty value
                Response.Cookies.Append("selectedMenu", "", new CookieOptions
                {
                    Expires = DateTime.Now.AddYears(-1) // Expire the cookie
                });
            }
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