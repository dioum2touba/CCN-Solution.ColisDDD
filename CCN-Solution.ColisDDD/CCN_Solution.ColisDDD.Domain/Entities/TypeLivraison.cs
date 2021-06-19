using System.Collections.Generic;
using CCN_Solution.ColisDDD.Domain.Common;

namespace CCN_Solution.ColisDDD.Domain.Entities
{
    public class TypeLivraison : BaseEntity
    {
        public string Libelle { get; set; }
        public string Description { get; set; }

        public TypeLivraison()
            => Livraisons = new HashSet<Livraison>();
        public virtual ICollection<Livraison> Livraisons { get; set; }
    }
}