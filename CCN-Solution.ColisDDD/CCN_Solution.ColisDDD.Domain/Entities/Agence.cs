using System.Collections.Generic;
using CCN_Solution.ColisDDD.Domain.Common;

namespace CCN_Solution.ColisDDD.Domain.Entities
{
    public class Agence: BaseEntity
    {
        public string NomAgence { get; set; }
        public string Adresse { get; set; }
        public string CodeAgence { get; set; }
        public double? Longitude { get; set; }
        public double? Latitude { get; set; }
        public int Telephone { get; set; }
        public string HeureDemarrage { get; set; }
        public string HeureFermeture { get; set; }

        public int RegionId { get; set; }
        public Region Region { get; set; }

        public int TypeAgenceId { get; set; }
        public TypeAgence TypeAgence { get; set; }

        public Agence()
            => Users = new HashSet<ApplicationUser>();
        public virtual ICollection<ApplicationUser> Users { get; set; }

    }
}