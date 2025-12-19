using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthTracker.Application.DTO.HealthMetric
{
    public class CreateHealthMetricDto
    {
        public int MetricTypeId { get; set; }
        public double Value { get; set; }

    }
}
