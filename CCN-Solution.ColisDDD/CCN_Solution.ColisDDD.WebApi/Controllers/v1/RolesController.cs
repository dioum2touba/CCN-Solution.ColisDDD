using System.Collections.Generic;
using System.Threading.Tasks;
using CCN_Solution.ColisDDD.Application.DTOs;
using CCN_Solution.ColisDDD.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Annotations;

namespace CCN_Solution.ColisDDD.WebApi.Controllers.v1
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    [ApiExplorerSettings(GroupName = "Gestion des roles")]
    public class RolesController : ControllerBase
    {
        public readonly IRoleService _roleService;

        public RolesController(IRoleService roleService)
            => _roleService = roleService;

        // GET: api/role
        [HttpGet]
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [SwaggerOperation(
            Summary = "Liste de toutes les role",
            Description = "Recupérer la liste des role"
        )]
        [SwaggerResponse(200, "Successfully found role", typeof(List<RoleDto>))]
        [SwaggerResponse(400, "Bad request, error", typeof(List<RoleDto>))]
        public async Task<ActionResult<IEnumerable<RoleDto>>> Getrole()
            => await _roleService.GetAllAsync();

        // GET: api/role/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RoleDto>> Getrole(string id)
        {
            var role = await _roleService.GetByIdAsync(id);
            if (role == null)
                return NotFound();
            return role;
        }

        // PUT: api/role/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> Putrole(string id, RoleDto role)
        {
            if (id != role.Id)
                return BadRequest();
            try
            {
                await _roleService.UpdateAsync(role);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!roleExists(id))
                    return NotFound();
                else
                    throw;
            }
            return NoContent();
        }

        // POST: api/role
        /// <summary>
        /// Save new role
        /// </summary>
        /// <param name="role"></param>
        /// <returns></returns>
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<RoleDto>> Postrole(RoleDto role)
        {
            role = await _roleService.AddAsync(role);

            return CreatedAtAction("Getrole", new { id = role.Id }, role);
        }

        // DELETE: api/role/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<RoleDto>> Deleterole(int id)
        {
            var role = await _roleService.GetByIdAsync(id);
            if (role == null)
            {
                return NotFound();
            }

            await _roleService.DeleteAsync(role);

            return role;
        }

        private bool roleExists(string id)
            => _roleService.IfExists(id).Result;
    }
}
