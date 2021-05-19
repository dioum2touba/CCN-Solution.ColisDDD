using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Identity;

namespace CCN_Solution.ColisDDD.Application.DTOs
{
    public class RoleDto : IdentityRole<string>
    {
        [NotMapped]
        [JsonIgnore]
        public virtual List<UserDto> Users { get; set; }
    }
}