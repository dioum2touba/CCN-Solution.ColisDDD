using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CCN_Solution.ColisDDD.Domain.Entities;
using CCN_Solution.ColisDDD.Domain.IRepositories;
using CCN_Solution.ColisDDD.Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace CCN_Solution.ColisDDD.Infrastructure.Persistence.Repositories
{
    public class ColisRepository : RepositoryAsync<Colis>, IColisRepository
    {
        private readonly DbSet<Colis> _colis;
        private readonly ApplicationDbContext _context;

        public ColisRepository(ApplicationDbContext dbContext) : base(dbContext)
            => (_colis, _context) = (dbContext.Set<Colis>(), dbContext);

        public async Task<List<Colis>> GetColisAllAsyncWithInc()
            => await _colis.Include(c => c.AgenceDepart)
                .Include(c => c.AgenceRecepteur)
                .Include(c => c.ClientSource)
                .Include(c => c.ClientRecepteur)
                .Include(c => c.RegionDepart)
                .Include(c => c.RegionRecepteur)
                .Include(c => c.TypeDeColis).ToListAsync();

        public async Task<Colis> GetReceptionneUnColis(int Id)
        {
            var colis = await _context.Colis.FirstOrDefaultAsync(c => c.Id == Id);
            colis.ReceptionAgence = true;
            colis.DateArrivee = DateTime.Now;
            _context.Colis.Update(colis);
            _context.SaveChangesAsync();
            return colis;
        }

        public async Task<Colis> GetByIdAsyncWithInc(int id)
            => await _colis.Include(c => c.AgenceDepart)
                .Include(c => c.AgenceRecepteur)
                .Include(c => c.ClientSource)
                .Include(c => c.ClientRecepteur)
                .Include(c => c.RegionDepart)
                .Include(c => c.RegionRecepteur)
                .Include(c => c.TypeDeColis).FirstOrDefaultAsync(c => c.Id == id);
    }
}