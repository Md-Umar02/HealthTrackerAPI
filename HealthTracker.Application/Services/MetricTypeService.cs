using AutoMapper;
using HealthTracker.Domain.Contracts;
using HealthTracker.Application.DTO.MetricType;
using HealthTracker.Application.DTO.User;
using HealthTracker.Application.Services.Interface;
using HealthTracker.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthTracker.Application.Services
{
    public class MetricTypeService : IMetricTypeService
    {
        private readonly IMetricTypeRepository _metricTypeRepository;
        private readonly IMapper _mapper;
        public MetricTypeService(IMetricTypeRepository metricTypeRepository, IMapper mapper)
        {
            _metricTypeRepository = metricTypeRepository;
            _mapper = mapper;
        }

        public async Task<MetricTypeDto> CreateAsync(CreateMetricTypeDto createMetricTypeDto)
        {
            var metricEntity = _mapper.Map<MetricType>(createMetricTypeDto);
            var createdMetric = await _metricTypeRepository.CreateAsync(metricEntity);
            var metricDto = _mapper.Map<MetricTypeDto>(createdMetric);
            return metricDto;
        }

        public async Task DeleteAsync(int id)
        {
            var metricTask = await _metricTypeRepository.GetByIdAsync(id);
            if (metricTask != null)
            {
                await _metricTypeRepository.DeleteAsync(metricTask);
            }
            return;
        }

        public async Task<IEnumerable<MetricTypeDto>> GetAllAsync()
        {
            var metrics = await _metricTypeRepository.GetAllAsync();
            var metricDtos = _mapper.Map<IEnumerable<MetricTypeDto>>(metrics);
            return metricDtos;
        }

        public async Task<MetricTypeDto?> GetByIdAsync(int id)
        {
            var metric = await _metricTypeRepository.GetByIdAsync(id);
            if (metric == null)
            {
                return null;
            }
            return _mapper.Map<MetricTypeDto>(metric);
        }

        public async Task UpdateAsync(UpdateMetricTypeDto updateMetricTypeDto)
        {
            var metric = _mapper.Map<MetricType>(updateMetricTypeDto);
            await _metricTypeRepository.UpdateAsync(metric);
        }
    }
}
