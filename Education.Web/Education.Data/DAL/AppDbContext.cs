using Education.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Education.Data.DAL
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) :base(options) { }

        public DbSet<Intro> Intros { get; set; }
        public DbSet<Employee> Employees { get; set; }
    }
}
