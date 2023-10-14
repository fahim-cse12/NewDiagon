using GLDiagonistice.Application.Service.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GLDiagonistice.Application.Service.Admin.Dto
{
    public class InvestigationDto : BaseEntityDto
    {
        public string InvestigationName { get; set; }
        public string Description { get; set; }
        public decimal Cost { get; set; }
    }
}
