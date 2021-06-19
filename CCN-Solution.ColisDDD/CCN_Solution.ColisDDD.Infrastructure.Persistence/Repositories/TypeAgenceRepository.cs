using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using CCN_Solution.ColisDDD.Domain.Entities;
using CCN_Solution.ColisDDD.Domain.IRepositories;
using CCN_Solution.ColisDDD.Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace CCN_Solution.ColisDDD.Infrastructure.Persistence.Repositories
{
    public class TypeAgenceRepository : RepositoryAsync<TypeAgence>, ITypeAgenceRepository
    {
        private readonly DbSet<TypeAgence> _typeAgence;
        private readonly IMapper _mapper;

        public TypeAgenceRepository(ApplicationDbContext dbContext, IMapper mapper) : base(dbContext)
            => (_typeAgence, _mapper) = (dbContext.Set<TypeAgence>(), mapper);

    }
}
