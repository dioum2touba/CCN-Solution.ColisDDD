using System.Collections.Generic;
using CCN_Solution.ColisDDD.Domain.Common;
using CCN_Solution.ColisDDD.Domain.Entities;

namespace CCN_Solution.ColisDDD.Application.DTOs
{
    public class TypeLivraisonDto : BaseEntity
    {
        public string Libelle { get; set; }
        public string Description { get; set; }

        public TypeLivraisonDto()
            => Livraisons = new HashSet<LivraisonDto>();
        public virtual ICollection<LivraisonDto> Livraisons { get; set; }
    }
}