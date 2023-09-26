using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GLDiagonistice.Application.Service.Common
{
    public record ResetPassword(string? Password, string ConfirmedPassword, string Email);
}
