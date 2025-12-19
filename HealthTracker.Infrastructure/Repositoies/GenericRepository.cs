using HealthTracker.Domain.Contracts;
using HealthTracker.Infrastructure.DbContexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthTracker.Infrastructure.Repositoies
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly ApplicationDbContext _context;
        public GenericRepository(ApplicationDbContext context)
        {
            _context = context; 
        }
        public async Task<T> CreateAsync(T entity)
        {
           var addedEntity = await _context.Set<T>().AddAsync(entity);
           await _context.SaveChangesAsync();
           return addedEntity.Entity;
        }

        public async Task DeleteAsync(T entity)
        {
            _context.Remove(entity);
            await _context.SaveChangesAsync();
        }

        
        public virtual async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public virtual async Task<T?> GetByIdAsync(int id)
        {
            var entity = await _context.Set<T>().FindAsync(id);
            if (entity == null)
            {
                Console.WriteLine($"No entity found with id {id}");
            }
            return entity;
        }
    }
}