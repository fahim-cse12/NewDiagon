using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GLDiagonistic.Domain
{
    public class Investigation : BaseEntity
    {
        public int Id { get; set; } 
        public string InvestigationName { get; set; }
        public string Description { get; set; }
        public decimal Cost { get; set; }
    }
}
