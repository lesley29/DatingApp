using System.Threading;
using System.Threading.Tasks;
using Domain.Aggregates.Users.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Common.Persistence
{
    public interface IDatingAppDbContext
    {
        public DbSet<User> Users { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
