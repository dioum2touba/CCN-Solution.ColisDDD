using System.Collections.Generic;
using CCN_Solution.ColisDDD.Domain.Common;

namespace CCN_Solution.ColisDDD.Application.DTOs
{
    public class TypeAgenceDto: BaseEntity
    {
        public string Libelle { get; set; }
        public string Description { get; set; }

        public TypeAgenceDto()
            => Agences = new HashSet<AgenceDto>();
        public virtual ICollection<AgenceDto> Agences { get; set; }
    }
}