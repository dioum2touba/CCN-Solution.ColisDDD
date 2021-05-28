using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using CCN_Solution.ColisDDD.Domain.Settings;

namespace CCN_Solution.ColisDDD.Domain.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<RefreshToken> RefreshTokens { get; set; }
        public bool OwnsToken(string token)
        {
            return this.RefreshTokens?.Find(x => x.Token == token) != null;
        }

        public int AgenceId { get; set; }
        public virtual Agence Agence { get; set; }

        public int RegionId { get; set; }
        public virtual Region Region { get; set; }

        // public ApplicationUser() => Roles = new List<Role>();
        // public virtual List<Role> Roles { get; set; }

    }
}
