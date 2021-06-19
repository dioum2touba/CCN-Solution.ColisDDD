using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using CCN_Solution.ColisDDD.Domain.Entities;
using CCN_Solution.ColisDDD.Domain.IRepositories;
using CCN_Solution.ColisDDD.Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace CCN_Solution.ColisDDD.Infrastructure.Persistence.Repositories
{
    public class TypeLivraisonRepository : RepositoryAsync<TypeLivraison>, ITypeLivraisonRepository
    {
        private readonly DbSet<TypeLivraison> _typeLivraison;
        private readonly IMapper _mapper;

        public TypeLivraisonRepository(ApplicationDbContext dbContext, IMapper mapper) : base(dbContext)
            => (_typeLivraison, _mapper) = (dbContext.Set<TypeLivraison>(), mapper);

    }
}
