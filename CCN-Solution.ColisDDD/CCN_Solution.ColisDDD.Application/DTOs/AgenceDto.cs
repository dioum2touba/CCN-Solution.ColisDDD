using System.Collections.Generic;
using CCNSolution.ColisDDD.Application.DTOs;

namespace CCN_Solution.ColisDDD.Application.DTOs
{
    public class AgenceDto: BaseEntityDto
    {
        public AgenceDto()
            => Users = new HashSet<UserDto>();

        public string NomAgence { get; set; }
        public string Adresse { get; set; }
        public string CodeAgence { get; set; }
        public string Pays { get; set; }
        public string Longitude { get; set; }
        public string Latitude { get; set; }
        public string Telephone { get; set; }
        public string HeureDemarrage { get; set; }
        public string HeureFermeture { get; set; }
        public string RegionId { get; set; }

        public RegionDto Region { get; set; }

        public virtual ICollection<UserDto> Users { get; set; }

    }
}