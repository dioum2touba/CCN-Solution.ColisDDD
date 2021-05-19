using System.Collections.Generic;
using CCN_Solution.ColisDDD.Domain.Common;

namespace CCN_Solution.ColisDDD.Domain.Entities
{
    public class Region : BaseEntity
    {
        public Region()
            => (Agences, Users, Clients) 
            = (new HashSet<Agence>(), new HashSet<ApplicationUser>(), new HashSet<Client>());
       

        public string Label { get; set; }

        public virtual ICollection<Agence> Agences { get; set; }
        public virtual ICollection<Client> Clients { get; set; }
        public virtual ICollection<ApplicationUser> Users { get; set; }
    }
}