using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthTracker.Application.DTO.HealthMetric
{
    public class UpdateHealthMetricDto
    {
        public int Id { get; set; }
        [Required]
        public int UserId { get; set; }
        public string MetricType { get; set; }
        public double Value { get; set; }
    }
}
