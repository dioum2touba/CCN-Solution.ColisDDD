using System.Collections.Generic;
using CCNSolution.ColisDDD.Application.DTOs;
using Microsoft.AspNetCore.Identity;

namespace CCN_Solution.ColisDDD.Application.DTOs
{
    public class UserDto : IdentityUser
    {
        public UserDto()
        {
            Roles = new List<RoleDto>();
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public int AgenceId { get; set; }
        public AgenceDto Agence { get; set; }

        public virtual List<RoleDto> Roles { get; set; }
    }
}
