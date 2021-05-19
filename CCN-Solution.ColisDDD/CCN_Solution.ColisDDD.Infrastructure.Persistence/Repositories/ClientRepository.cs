using CCN_Solution.ColisDDD.Domain.Entities;
using CCN_Solution.ColisDDD.Domain.IRepositories;
using CCN_Solution.ColisDDD.Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace CCN_Solution.ColisDDD.Infrastructure.Persistence.Repositories
{
    public class ClientRepository : RepositoryAsync<Client>, IClientRepository
    {
        private readonly DbSet<Client> _clients;

        public ClientRepository(ApplicationDbContext dbContext) : base(dbContext)
            => _clients = dbContext.Set<Client>();
    }
}