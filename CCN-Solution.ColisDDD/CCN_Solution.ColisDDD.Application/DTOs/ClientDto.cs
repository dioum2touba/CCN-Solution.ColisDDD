using System.Collections.Generic;
using CCNSolution.ColisDDD.Application.DTOs;

namespace CCN_Solution.ColisDDD.Application.DTOs
{
    public class ClientDto: BaseEntityDto
    {
        public ClientDto()
        {
            Images = new HashSet<ImagesDto>();
        }

        public int CIN { get; set; }
        public int Telephone { get; set; }
        public string Adresse { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string DisplayName => FirstName + " " + LastName;

        public virtual ICollection<ImagesDto> Images { get; set; }
    }
}