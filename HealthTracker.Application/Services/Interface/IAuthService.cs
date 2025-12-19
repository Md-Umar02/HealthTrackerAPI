using HealthTracker.Application.DTO.Auth;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthTracker.Application.Services.Interface
{
    public interface IAuthService
    {
        Task<AuthResponseDto?> RegisterAsync(AuthRegisterDto request);
        Task<AuthResponseDto?> LoginAsync(AuthRequestDto request);
    }
}
