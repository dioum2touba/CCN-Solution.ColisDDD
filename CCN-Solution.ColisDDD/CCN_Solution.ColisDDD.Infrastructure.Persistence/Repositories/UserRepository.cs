using System.Collections.Generic;
using System.Linq;
using CCN_Solution.ColisDDD.Domain.Entities;
using CCN_Solution.ColisDDD.Domain.IRepositories;
using CCN_Solution.ColisDDD.Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace CCN_Solution.ColisDDD.Infrastructure.Persistence.Repositories
{
    public class UserRepository : RepositoryAsync<ApplicationUser>, IUserRepository
    {
        public ApplicationDbContext _context;
        private readonly DbSet<ApplicationUser> _user;

        public UserRepository(ApplicationDbContext dbContext) : base(dbContext)
            => (_context, _user) = (dbContext, dbContext.Set<ApplicationUser>());

        public List<ApplicationUser> GetApplicationUsersWithRoles()
            => null;//_context.Users.Include(u => u.Roles).ToList();

        public ApplicationUser FindByUsername(string username)
            => _user.SingleOrDefault(u => u.UserName == username);
    }
}