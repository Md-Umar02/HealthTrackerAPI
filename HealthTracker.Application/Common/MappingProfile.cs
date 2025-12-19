using AutoMapper;
using HealthTracker.Application.DTO.HealthMetric;
using HealthTracker.Application.DTO.MetricType;
using HealthTracker.Application.DTO.User;
using HealthTracker.Application.Services;
using HealthTracker.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthTracker.Application.Common
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserDto>();
            CreateMap<CreateUserDto, User>();
            CreateMap<UpdateUserDto, User>();
            CreateMap<User, UserProfileDto>();
                //.ForMember(dest => dest.PasswordHash, opt => opt.MapFrom(src => src.Password));

            CreateMap<HealthMetric, HealthMetricDto>()
                .ForMember(dest => dest.MetricType, opt => opt.MapFrom(src => src.MetricType.Name));
            CreateMap<CreateHealthMetricDto, HealthMetric>();
            CreateMap<UpdateHealthMetricDto, HealthMetric>();

            CreateMap<MetricType, MetricTypeDto>();
            CreateMap<CreateMetricTypeDto, MetricType>();
            CreateMap<UpdateMetricTypeDto, MetricType>();
        }
    }
}
