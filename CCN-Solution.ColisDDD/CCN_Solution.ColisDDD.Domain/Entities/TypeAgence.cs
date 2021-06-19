using System.Collections.Generic;
using CCN_Solution.ColisDDD.Domain.Common;

namespace CCN_Solution.ColisDDD.Domain.Entities
{
    public class TypeAgence: BaseEntity
    {
        public string Libelle { get; set; }
        public string Description { get; set; }

        public TypeAgence()
            => Agences = new HashSet<Agence>();
        public virtual ICollection<Agence> Agences { get; set; }
    }
}