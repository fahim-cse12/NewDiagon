using GLDiagonistice.Application.Service.User.Dto;

namespace GLDiagonistice.Application.IRepository
{
    public interface IUserRepository
    {
        Task<UserDto> GetUserByUserNameAndPassword(string userName, string password);
        Task<UserDto?> GetUserByUserName(string userName);
    }
}
