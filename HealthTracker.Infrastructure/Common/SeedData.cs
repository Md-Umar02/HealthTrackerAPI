using HealthTracker.Domain.Models;
using HealthTracker.Infrastructure.DbContexts;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthTracker.Infrastructure.Common
{
    public class SeedData
    {
        public static async Task SeedRoles(IServiceProvider serviceProvider)
        {
            using var scope = serviceProvider.CreateScope();
            var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var roles = new List<IdentityRole>
            {
                new IdentityRole {Name="ADMIN", NormalizedName="admin"},
                new IdentityRole {Name="USER", NormalizedName="user"}
            };
            foreach (var role in roles) 
            {
                if (!await roleManager.RoleExistsAsync(role.Name))
                {
                    await roleManager.CreateAsync(role);
                }
            }
        }
        public static async Task SeedDataAsync(ApplicationDbContext _context)
        {
            if (!_context.MetricTypes.Any())
            {
                await _context.AddRangeAsync(
                    new MetricType
                    {
                        Name = "HeartRate"
                    },
                    new MetricType
                    {
                        Name = "Steps"
                    },
                    new MetricType
                    {
                        Name = "Calories"
                    },
                    new MetricType
                    {
                        Name = "BloodPressure"
                    });

                await _context.SaveChangesAsync();
            }
        }
    }
}
