using CCN_Solution.ColisDDD.Domain.Entities;
using CCN_Solution.ColisDDD.Domain.IRepositories;
using CCN_Solution.ColisDDD.Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace CCN_Solution.ColisDDD.Infrastructure.Persistence.Repositories
{
    public class ImageRepository : RepositoryAsync<Images>, IImageRepository
    {
        private readonly DbSet<Images> _images;

        public ImageRepository(ApplicationDbContext dbContext) : base(dbContext)
            => _images = dbContext.Set<Images>();
    }
}