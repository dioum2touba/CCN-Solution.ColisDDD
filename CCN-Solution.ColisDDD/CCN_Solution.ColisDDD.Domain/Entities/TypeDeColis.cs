using System.Collections.Generic;
using CCN_Solution.ColisDDD.Domain.Common;

namespace CCN_Solution.ColisDDD.Domain.Entities
{
    public class TypeDeColis : BaseEntity
    {
        public TypeDeColis()
        {
            Colis = new HashSet<Colis>();
        }

        public string Libelle { get; set; }
        public string Categorie { get; set; }
        public double Prix { get; set; }
        public double? Poid { get; set; }

        public virtual ICollection<Colis> Colis { get; set; }
    }
}