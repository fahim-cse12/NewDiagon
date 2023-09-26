using GLDiagonistice.Application.Service.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GLDiagonistice.Application.IService.Common
{
    public interface IMailService
    {
        void SendEmail(Message message);
    }
}
