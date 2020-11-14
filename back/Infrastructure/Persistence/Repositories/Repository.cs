using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Domain.Common;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories
{
    internal abstract class Repository<T> : IRepository<T>
        where T : class, IAggregateRoot
    {
        private readonly DatingAppDbContext _dbContext;

        public Repository(DatingAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<List<T>> Find(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default)
        {
            return _dbContext.Set<T>().Where(predicate).ToListAsync(cancellationToken);
        }

        public Task<T> SingleOrDefault(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default)
        {
            return _dbContext.Set<T>().SingleOrDefaultAsync(predicate, cancellationToken);
        }
    }
}
