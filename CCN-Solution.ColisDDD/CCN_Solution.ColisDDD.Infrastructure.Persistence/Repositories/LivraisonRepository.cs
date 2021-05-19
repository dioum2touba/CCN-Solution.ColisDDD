using CCN_Solution.ColisDDD.Domain.Entities;
using CCN_Solution.ColisDDD.Domain.IRepositories;
using CCN_Solution.ColisDDD.Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace CCN_Solution.ColisDDD.Infrastructure.Persistence.Repositories
{
    public class LivraisonRepository : RepositoryAsync<Livraison>, ILivraisonRepository
    {
        private readonly DbSet<Livraison> _livraisons;

        public LivraisonRepository(ApplicationDbContext dbContext) : base(dbContext)
            => _livraisons = dbContext.Set<Livraison>();
    }
}