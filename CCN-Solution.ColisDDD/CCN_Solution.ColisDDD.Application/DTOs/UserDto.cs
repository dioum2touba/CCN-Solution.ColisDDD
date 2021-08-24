using System.Collections.Generic;
using CCNSolution.ColisDDD.Application.DTOs;
using Microsoft.AspNetCore.Identity;

namespace CCN_Solution.ColisDDD.Application.DTOs
{
    public class UserDto : IdentityUser
    {

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? Matricule { get; set; }
        public string DisplayName => FirstName + " " + LastName;

        public int AgenceId { get; set; }
        public AgenceDto Agence { get; set; }

        public int RegionId { get; set; }
        public virtual RegionDto Region { get; set; }

        public UserDto() => (Roles) = (new List<RoleDto>());
        public virtual List<RoleDto> Roles { get; set; }
        public string rolesId { get; set; }
    }
}
