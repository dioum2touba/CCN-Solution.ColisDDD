using System.Collections.Generic;
using CCNSolution.ColisDDD.Application.DTOs;

namespace CCN_Solution.ColisDDD.Application.DTOs
{
    public class TypeDeColisDto : BaseEntityDto
    {
        public TypeDeColisDto()
        {
            Colis = new HashSet<ColisDto>();
        }

        public string Libelle { get; set; }
        public string Categorie { get; set; }
        public double Prix { get; set; }

        public virtual ICollection<ColisDto> Colis { get; set; }
    }
}