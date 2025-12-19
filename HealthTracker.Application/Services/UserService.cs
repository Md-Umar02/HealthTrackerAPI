using AutoMapper;
using HealthTracker.Application.DTO.User;
using HealthTracker.Application.Services.Interface;
using HealthTracker.Domain.Contracts;
using HealthTracker.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HealthTracker.Application.ViewModels;
using HealthTracker.Application.InputModels;
using HealthTracker.Application.Exceptions;

namespace HealthTracker.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IPaginationService<UserDto, User> _paginationService;
        private readonly IMapper _mapper;
        public UserService(IUserRepository userRepository,
            IPaginationService<UserDto, User> paginationService,
            IMapper mapper)
        {
            _userRepository = userRepository;
            _paginationService = paginationService;
            _mapper = mapper;
        }
        public async Task<UserDto> CreateAsync(CreateUserDto createUserDto)
        {
            var validator = new CreateUserValidatior();
            var validationResult = await validator.ValidateAsync(createUserDto);
            if (validationResult.Errors.Any()) 
            {
                throw new BadRequestException("Inavlid", validationResult);
            }
            var userEntity = _mapper.Map<User>(createUserDto);
            var createdUser = await _userRepository.CreateAsync(userEntity);
            var userDto = _mapper.Map<UserDto>(createdUser);
            return userDto;
        }

        public async Task DeleteAsync(int id)
        {
            var userTask = await _userRepository.GetByIdAsync(id);
            if (userTask != null)
            {
                await _userRepository.DeleteAsync(userTask);
            }
            return;
        }

        public async Task<IEnumerable<UserDto>> GetAllAsync()
        {
            //Manually mapping entities to DTOs
            //var users = await _healthMetricRepository.GetAllAsync();
            //return users.Select(u => new UserDto
            //{
            //    Id = u.Id,
            //    Name = u.Name,
            //    Email = u.Email,
            //    Age = u.Age
            //});
            var users = await _userRepository.GetAllAsync();
            var userDtos = _mapper.Map<IEnumerable<UserDto>>(users);
            return userDtos;
        }

        public async Task<UserDto?> GetByIdAsync(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user == null)
            {
                return null;
            }
            return _mapper.Map<UserDto>(user);
        }

        public async Task<UserProfileDto?> GetByIdentityIdAsync(string userId)
        {
            var user = await _userRepository.GetByIdentityIdAsync(userId);
            if (user == null)
            {
                return null;
            }
            return _mapper.Map<UserProfileDto>(user);
        }

        public async Task<PaginationVM<UserDto>> GetPagination(PaginationInputModel pagination)
        {
            var source = await _userRepository.GetAllAsync();
            var result = _paginationService.GetPagination((List<User>)source, pagination);
            return result;
        }

        public async Task UpdateAsync(UpdateUserDto updateUserDto)
        {
            //var existingUser = await _healthMetricRepository.GetByIdAsync(id);
            //if (existingUser == null)
            //{
            //    return null;
            //}
            //return _mapper.Map<User>(updateUserDto);
            var userEntity = _mapper.Map<User>(updateUserDto);
            await _userRepository.UpdateAsync(userEntity);
        }
    }
}
