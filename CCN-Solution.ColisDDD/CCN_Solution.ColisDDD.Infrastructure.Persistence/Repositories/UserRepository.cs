using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
            => _context.ApplicationUser.Include(u => u.Region)
                .Include(u => u.Agence).ToList();

        public ApplicationUser FindByUsername(string username)
            => _user.SingleOrDefault(u => u.UserName == username);

        public async Task<List<ApplicationUser>> GetByIdAsyncWithInc(int id)
            => await _context.Users.Include(u => u.Region)
                .Include(u => u.Agence).ToListAsync();

        public async Task<List<Role>> GetRoleByUserIdAsyncWithInc(string userId)
        {
            var rolesId = await _context.UserRoles.Where(u => u.UserId == userId)
                .Select(u => u.RoleId).ToListAsync();

            return _context.Roles.Where(r => rolesId.Contains(r.Id)).ToList();
        }
    }
}