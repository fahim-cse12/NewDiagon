using GLDiagonistice.Application.Service.Common;
using GLDiagonistice.Application.Service.User.Dto;

namespace GLDiagonistice.Application.IService.User
{
    public interface IUserService
    {
        public Task<ResponseModel<UserDto>> UserLogin(LoginDto loginDto);
        public Task<ResponseModel<string>> Logout();
        public Task<ResponseModel<string>> RegisterUser(RegisterDto registerDto);
        public Task<ResponseModel<string>> EmailConfirmation(string token, string email);
        public Task<ResponseModel<string>> ForgetPassword(string email);
        public Task<ResponseModel<string>> UpdatePassword(ResetPassword password);
    }
}
