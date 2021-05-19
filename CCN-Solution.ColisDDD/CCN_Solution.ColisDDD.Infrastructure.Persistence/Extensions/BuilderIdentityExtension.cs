using CCN_Solution.ColisDDD.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace CCN_Solution.ColisDDD.Infrastructure.Persistence.Extensions
{
    public static class BuilderIdentityExtension
    {
        public static void AddModelCreating(this ModelBuilder builder)
        {
            //builder.HasDefaultSchema("Identity");
            builder.Entity<ApplicationUser>(entity =>
            {
                entity.ToTable(name: "User");
            });

            builder.Entity<Role>(entity =>
            {
                entity.ToTable(name: "Role");
            });

            builder.Entity<IdentityUserRole<string>>(entity =>
            {
                // Primary key
                entity.HasKey(r => new { r.UserId, r.RoleId });
                entity.ToTable("UserRoles");
            });

            builder.Entity<IdentityUserClaim<string>>(entity =>
            {
                entity.ToTable("UserClaims");
            });

            builder.Entity<IdentityUserLogin<string>>(entity =>
            {
                // Composite primary key consisting of the LoginProvider and the key to use
                // with that provider
                entity.HasKey(l => new { l.LoginProvider, l.ProviderKey });
                entity.ToTable("UserLogins");
            });

            builder.Entity<IdentityRoleClaim<string>>(entity =>
            {
                entity.ToTable("RoleClaims");
            });

            builder.Entity<IdentityUserToken<string>>(entity =>
            {
                // Composite primary key consisting of the UserId, LoginProvider and Name
                entity.HasKey(t => new { t.UserId, t.LoginProvider, t.Name });
                entity.ToTable("UserTokens");
            });
        }
    }
}