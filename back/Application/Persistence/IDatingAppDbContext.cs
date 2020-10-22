using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Persistence
{
    public interface IDatingAppDbContext
    {
        public DbSet<User> Users { get; }
    }
}
