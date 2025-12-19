using HealthTracker.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthTracker.Domain.Contracts
{
    public interface IMetricTypeRepository : IGenericRepository<MetricType>
    {
        Task UpdateAsync(MetricType entity);
        Task<bool> ExistsAsync(string name);
    }
}
