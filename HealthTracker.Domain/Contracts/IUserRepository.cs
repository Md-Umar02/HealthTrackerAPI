using HealthTracker.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthTracker.Domain.Contracts
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task UpdateAsync(User entity);
        Task<bool> ExistsAsync(int id);
        Task<User?> GetByIdentityIdAsync(string userId);
    }
}
