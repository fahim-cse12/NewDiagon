using GLDiagonistice.Application.IService.User;
using GLDiagonistice.Application.Service.User.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GLDiagonistic.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserService _accountService;
        public AccountController(IUserService accountService)
        {
            this._accountService = accountService;
        }
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginDto loginDto, string? returnUrl)
        {

            var result = await _accountService.UserLogin(loginDto);
            if (result.Success)
            {
                TempData["LoginMessage"] = "Successfully Loged in";
                return RedirectToAction("Index", "Home");
            }
           
            return RedirectToAction("Login", "Account");
        }

        [Authorize]
        public async Task<IActionResult> Logout()
        {
            var result = await _accountService.Logout();
            if (result.Success)
            {
                return RedirectToAction("Login", "Account");
            }
            //_logger.LogInformation("Logging Out => User Name: {0}", _httpcontext.HttpContext.Session.GetData<string>(SessionDataKeys.UserNameKey));
            //_accountService.DestroyAuthTicket();
            //_accountService.CleanSessionAndCookie();
            //_accountService.UpdateLoginHistoryOnLogout(_httpcontext.HttpContext.Session.Id);
            return RedirectToAction("Index", "Home");
        }
    }
}
