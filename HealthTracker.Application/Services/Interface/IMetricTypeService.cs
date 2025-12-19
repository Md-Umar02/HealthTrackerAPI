using HealthTracker.Application.DTO.MetricType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthTracker.Application.Services.Interface
{
    public interface IMetricTypeService
    {
        Task<IEnumerable<MetricTypeDto>> GetAllAsync();
        Task<MetricTypeDto> CreateAsync(CreateMetricTypeDto createMetricTypeDto);
        Task UpdateAsync(UpdateMetricTypeDto updateMetricTypeDto);
        Task<MetricTypeDto?> GetByIdAsync(int id);
        Task DeleteAsync(int id);
    }
}
