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
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(ApplicationDbContext context) : base(context)
        {
        }
        public async Task UpdateAsync(User entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();
        }
        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.Users.AnyAsync(u => u.Id == id);
        }

        public async Task<User?> GetByIdentityIdAsync(string userId)
        {
            return await _context.Users.Include(u => u.HealthMetrics)
                .ThenInclude(hm => hm.MetricType)
                .FirstOrDefaultAsync(u => u.IdentityUserId == userId);
        }
    }
}
