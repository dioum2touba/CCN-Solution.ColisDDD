using System.Collections.Generic;
using CCN_Solution.ColisDDD.Domain.Common;

namespace CCN_Solution.ColisDDD.Domain.Entities
{
    public class Region : BaseEntity
    {
        public Region()
            => (Agences, Users) 
            = (new HashSet<Agence>(), new HashSet<ApplicationUser>());

        public string Label { get; set; }
        public string Adresse { get; set; }
        public string Pays { get; set; }
        public int Telephone { get; set; }
        public string Longitude { get; set; }
        public string Latitude { get; set; }

        public virtual ICollection<Agence> Agences { get; set; }
        public virtual ICollection<ApplicationUser> Users { get; set; }
    }
}