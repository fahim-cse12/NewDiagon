using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GLDiagonistic.Domain
{
    public class PatientInvestigation : BaseEntity
    {
        [Key]
        public long Id { get; set; }
        public long AppointmentId { get; set; }
        public int InvestigationId { get; set; }
        public string InvestigationName { get; set; }
        public decimal InvestigationPrice { get; set; }
        public decimal DiscountPrice { get; set; }

    }
}
