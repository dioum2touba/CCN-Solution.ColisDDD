using System.Collections.Generic;
using CCN_Solution.ColisDDD.Domain.Common;
using CCN_Solution.ColisDDD.Domain.Entities;

namespace CCN_Solution.ColisDDD.Application.DTOs
{
    public class MoyenTransportDto: BaseEntity
    {
        public string Libelle { get; set; }
        public string Type { get; set; }
        public string Matricule { get; set; }
        public string Description { get; set; }

        public MoyenTransportDto()
            => (Colis, Livraisons) = (new HashSet<ColisDto>(), new HashSet<LivraisonDto>());
        public virtual ICollection<ColisDto> Colis { get; set; }
        public virtual ICollection<LivraisonDto> Livraisons { get; set; }
    }
}