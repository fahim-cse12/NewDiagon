using System.ComponentModel.DataAnnotations;

namespace GLDiagonistic.Domain
{
    public class BaseEntity
    {
        public bool Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string? UpdateddBy { get; set; }
    }
}
