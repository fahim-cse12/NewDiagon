using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GLDiagonistice.Application.Service.User.Dto
{
    public record RegisterDto(
        string UserName,
        string Password,
        string Email
        );
}
