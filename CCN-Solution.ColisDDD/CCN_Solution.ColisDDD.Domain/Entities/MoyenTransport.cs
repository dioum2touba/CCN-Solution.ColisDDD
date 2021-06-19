using System.Collections.Generic;
using CCN_Solution.ColisDDD.Domain.Common;

namespace CCN_Solution.ColisDDD.Domain.Entities
{
    public class MoyenTransport: BaseEntity
    {
        public string Libelle { get; set; }
        public string Type { get; set; }
        public string Matricule { get; set; }
        public string Description { get; set; }

        public MoyenTransport()
            => (Colis, Livraisons) = (new HashSet<Colis>(), new HashSet<Livraison>());
        public virtual ICollection<Colis> Colis { get; set; }
        public virtual ICollection<Livraison> Livraisons { get; set; }
    }
}