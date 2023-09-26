using GLDiagonistice.Application.IRepository;
using GLDiagonistice.Application.Service.User.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GLDiagonistic.Infrastucture.Repository.User
{
    public class UserRepository : IUserRepository
    {
        public async Task<UserDto?> GetUserByUserName(string userName)
        {
            throw new NotImplementedException();
        }

        public async Task<UserDto> GetUserByUserNameAndPassword(string userName, string password)
        {
            throw new NotImplementedException();
        }
    }
}
