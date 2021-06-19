using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CCN_Solution.ColisDDD.Domain.Entities;
using CCN_Solution.ColisDDD.Domain.IRepositories;
using CCN_Solution.ColisDDD.Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace CCN_Solution.ColisDDD.Infrastructure.Persistence.Repositories
{
    public class LivraisonRepository : RepositoryAsync<Livraison>, ILivraisonRepository
    {
        private readonly DbSet<Livraison> _livraisons;
        private readonly ApplicationDbContext _context;

        public LivraisonRepository(ApplicationDbContext dbContext) : base(dbContext)
            => (_livraisons, _context) = (dbContext.Set<Livraison>(), dbContext);

        public async Task<List<Livraison>> GetLivraisonsAllAsyncWithInc()
        {
            var livraisons = await _livraisons.Include(l => l.Colis)
                .Include(l => l.Livreur)
                .Include(l => l.TypeLivraison)
                .Include(l => l.MoyenTransport)
                .Include(l => l.Colis)
                .ToListAsync();

            livraisons.ForEach(elt =>
            {
                var colis = _context.Colis.Include(c => c.ClientSource)
                    .Include(c => c.ClientRecepteur)
                    .Include(c => c.TypeDeColis)
                    .Include(c => c.RegionDepart)
                    .Include(c => c.RegionRecepteur).FirstOrDefault(c => c.Id == elt.ColisId);
                elt.Colis = colis;
            });
            return livraisons.OrderByDescending(l => l.Id).ToList();
        }
    }
}