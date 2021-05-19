using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using CCN_Solution.ColisDDD.Domain.Entities;
using CCN_Solution.ColisDDD.Domain.IRepositories;
using CCN_Solution.ColisDDD.Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace CCN_Solution.ColisDDD.Infrastructure.Persistence.Repositories
{
    public class AgenceRepository : RepositoryAsync<Agence>, IAgenceRepository
    {
        private readonly DbSet<Agence> _agences;
        private readonly IMapper _mapper;

        public AgenceRepository(ApplicationDbContext dbContext, IMapper mapper) : base(dbContext)
            => (_agences, _mapper) = (dbContext.Set<Agence>(), mapper);

        public List<Agence> GetAllAgencesIncRegions()
            => _agences.Include(a => a.Region).ToList();
    }
}