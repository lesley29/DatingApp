using System.Threading;
using System.Threading.Tasks;
using Domain.Aggregates.User.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Persistence
{
    public interface IDatingAppDbContext
    {
        public DbSet<User> Users { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
