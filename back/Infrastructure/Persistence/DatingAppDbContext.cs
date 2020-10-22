using Application.Persistence;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence
{
    internal class DatingAppDbContext : DbContext, IDatingAppDbContext
    {
        public DatingAppDbContext(DbContextOptions<DatingAppDbContext> dbContextOptions) : base(dbContextOptions)
        {
        }


        public DbSet<User> Users => Set<User>();
    }
}
