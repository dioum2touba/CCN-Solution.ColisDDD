using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using CCN_Solution.ColisDDD.Domain.Entities;
using CCN_Solution.ColisDDD.Domain.IRepositories;
using CCN_Solution.ColisDDD.Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace CCN_Solution.ColisDDD.Infrastructure.Persistence.Repositories
{
    public class MoyenTransportRepository : RepositoryAsync<MoyenTransport>, IMoyenTransportRepository
    {
        private readonly DbSet<MoyenTransport> _moyenTransport;
        private readonly IMapper _mapper;

        public MoyenTransportRepository(ApplicationDbContext dbContext, IMapper mapper) : base(dbContext)
            => (_moyenTransport, _mapper) = (dbContext.Set<MoyenTransport>(), mapper);

    }
}
