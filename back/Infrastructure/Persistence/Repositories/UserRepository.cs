using Domain.Aggregates.User;
using Domain.Aggregates.User.Entities;

namespace Infrastructure.Persistence.Repositories
{
    internal class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(DatingAppDbContext dbContext) : base(dbContext)
        {
        }
    }
}
