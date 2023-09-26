using GLDiagonistice.Application.IService.Common;
using GLDiagonistice.Application.IService.User;
using GLDiagonistice.Application.Service.Common;
using GLDiagonistice.Application.Service.User.Dto;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System.Security.Claims;

namespace GLDiagonistice.Application.Service.User
{
    public class UserService : IUserService
    {
        private readonly SignInManager<GLDiagonistic.Domain.Users.User> _signInManager;
        private readonly IMailService _mailService;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<GLDiagonistic.Domain.Users.User> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IConfiguration _configuration;

        public UserService(SignInManager<GLDiagonistic.Domain.Users.User> signInManager, IMailService mailService, IConfiguration configuration,
           RoleManager<IdentityRole> roleManager, UserManager<GLDiagonistic.Domain.Users.User> userManager, IHttpContextAccessor httpContextAccessor)
        {
            _signInManager = signInManager;
            _mailService = mailService;
            _roleManager = roleManager;
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
            _configuration = configuration;

        }

        #region Common Private Methods

        private ResponseModel<T> CreateResponse<T>(bool status, T? data, string message, List<string>? erros)
        {
            return new ResponseModel<T>
            {
                Success = status,
                Data = data,
                Message = message,
                Errors = erros
            };
        }

        #endregion

        public Task<ResponseModel<string>> EmailConfirmation(string token, string email)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel<string>> ForgetPassword(string email)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel<string>> RegisterUser(RegisterDto registerDto)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel<string>> UpdatePassword(ResetPassword password)
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseModel<UserDto>> UserLogin(LoginDto loginDto)
        {
            try
            {
                if (loginDto == null)
                {
                    return CreateResponse<UserDto>(false, null, "User name And Password should not be bull", null);
                }


                var user = await _userManager.FindByNameAsync(loginDto.UserName);

                if (user != null && await _userManager.CheckPasswordAsync(user, loginDto.Password))
                {

                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, user.UserName),
                        new Claim(ClaimTypes.Email, user.Email),

                    };
                    var identity = new ClaimsIdentity(claims, "AuthCookie");
                    ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(identity);
                    var utcNow = DateTime.UtcNow;

                    var props = new AuthenticationProperties()
                    {
                        IsPersistent = false,
                        IssuedUtc = utcNow,
                        ExpiresUtc = utcNow.AddMinutes(Convert.ToDouble(_configuration["AuthenticationExpireMinutes"]))
                    };

                    await _httpContextAccessor.HttpContext.SignInAsync("AuthCookie", claimsPrincipal, props);

                    return CreateResponse<UserDto>(true, null, "Login Successfully", null);
                }

                return CreateResponse<UserDto>(false, null, "Invalid User name or Password", null);

            }
            catch (Exception ex)
            {
                return CreateResponse<UserDto>(false, null, ex.Message, null);

            }
        }

        public async Task<ResponseModel<string>> Logout()
        {
            try
            {
                await _httpContextAccessor.HttpContext.SignOutAsync("AuthCookie");
                _httpContextAccessor.HttpContext.Session.Clear();
                return CreateResponse<string>(true, null, "Successfully Logout", null);
            }
            catch (Exception ex)
            {
                return CreateResponse<string>(false, null, ex.Message, null);
            }
        }
    }
}

