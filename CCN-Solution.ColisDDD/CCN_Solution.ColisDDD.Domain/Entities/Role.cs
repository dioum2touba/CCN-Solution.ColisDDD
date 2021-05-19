using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace CCN_Solution.ColisDDD.Domain.Entities
{
    public class Role : IdentityRole
    {
        [NotMapped]
        public virtual List<ApplicationUser> ApplicationUser { get; set; }
    }
}