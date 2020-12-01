using Domain.Aggregates.Users;
using Domain.Aggregates.Users.Entities;

namespace Infrastructure.Persistence.Repositories
{
    internal class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(DatingAppDbContext dbContext) : base(dbContext)
        {
        }
    }
}
