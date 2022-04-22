using Ardalis.Specification.EntityFrameworkCore;
using MyFinances.Core.Interfaces;

namespace MyFinances.Infra.Repositories
{
    public class EfRepository<T> : RepositoryBase<T>, IRepository<T> where T : class, IAggregateRoot
    {
        public EfRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}
