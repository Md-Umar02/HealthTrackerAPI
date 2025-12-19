using HealthTracker.Domain.Contracts;
using HealthTracker.Domain.Models;
using HealthTracker.Infrastructure.DbContexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthTracker.Infrastructure.Repositoies
{
    public class MetricTypeRepository : GenericRepository<MetricType>, IMetricTypeRepository
    {
        public MetricTypeRepository(ApplicationDbContext context) : base(context)
        {
        }
        public async Task<bool> ExistsAsync(string name)
        { 
            return await _context.MetricTypes.AnyAsync(mt => mt.Name.ToLower() == name.ToLower());
        }


        public async Task UpdateAsync(MetricType entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
