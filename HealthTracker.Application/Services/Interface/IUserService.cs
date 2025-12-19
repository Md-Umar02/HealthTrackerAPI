using HealthTracker.Application.DTO.User;
using HealthTracker.Application.InputModels;
using HealthTracker.Application.ViewModels;
using HealthTracker.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthTracker.Application.Services.Interface
{
    public interface IUserService
    {
        Task<PaginationVM<UserDto>> GetPagination(PaginationInputModel pagination);
        Task<IEnumerable<UserDto>> GetAllAsync();
        Task<UserDto> CreateAsync(CreateUserDto createUserDto);
        Task UpdateAsync(UpdateUserDto updateUserDto);
        Task<UserDto?> GetByIdAsync(int id);
        Task DeleteAsync(int id);
        Task<UserProfileDto?> GetByIdentityIdAsync(string userId);
    }
}
