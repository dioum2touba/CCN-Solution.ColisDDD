using System.Collections.Generic;
using CCNSolution.ColisDDD.Application.DTOs;

namespace CCN_Solution.ColisDDD.Application.DTOs
{
    public class RegionDto : BaseEntityDto
    {
        public RegionDto()
            => (Agences, Users, Clients) 
            = (new HashSet<AgenceDto>(), new HashSet<UserDto>(), new HashSet<ClientDto>());
       

        public string Label { get; set; }

        public virtual ICollection<AgenceDto> Agences { get; set; }
        public virtual ICollection<ClientDto> Clients { get; set; }
        public virtual ICollection<UserDto> Users { get; set; }
    }
}