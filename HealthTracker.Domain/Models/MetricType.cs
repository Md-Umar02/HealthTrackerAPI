using HealthTracker.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthTracker.Domain.Models
{
    public class MetricType : BaseModel
    {
        public string Name { get; set; }
    }
}
