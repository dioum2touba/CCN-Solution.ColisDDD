using CCN_Solution.ColisDDD.Domain.Entities;
using CCN_Solution.ColisDDD.Domain.IRepositories;
using CCN_Solution.ColisDDD.Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace CCN_Solution.ColisDDD.Infrastructure.Persistence.Repositories
{
    public class TypeDeColisRepository : RepositoryAsync<TypeDeColis>, ITypeDeColisRepository
    {
        private readonly DbSet<TypeDeColis> _typeDeColis;

        public TypeDeColisRepository(ApplicationDbContext dbContext) : base(dbContext)
            => _typeDeColis = dbContext.Set<TypeDeColis>();
    }
}