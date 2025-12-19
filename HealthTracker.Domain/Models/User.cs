using HealthTracker.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthTracker.Domain.Models
{
    public class User : BaseModel
    {
        public string? IdentityUserId { get; set; }
        [Required]
        public string Name { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }

        public ICollection<HealthMetric> HealthMetrics { get; set; }
    }
}
