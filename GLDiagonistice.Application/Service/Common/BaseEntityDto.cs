using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GLDiagonistice.Application.Service.Common
{
    public class BaseEntityDto
    {
        public int Id { get; set; }
        public bool Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string? UpdateddBy { get; set; }
    }
}
