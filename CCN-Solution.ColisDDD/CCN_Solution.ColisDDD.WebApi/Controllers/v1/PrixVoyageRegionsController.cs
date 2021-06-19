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
    [ApiExplorerSettings(GroupName = "Gestion des prix des voyages")]
    public class PrixVoyageRegionsController : ControllerBase
    {
        public readonly IPrixVoyageRegionService _prixVoyageRegionservice;

        public PrixVoyageRegionsController(IPrixVoyageRegionService prixVoyageRegionservice)
            => _prixVoyageRegionservice = prixVoyageRegionservice;

        // GET: api/role
        [HttpGet]
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [SwaggerOperation(
            Summary = "Liste de toutes les role",
            Description = "Recupérer la liste des role"
        )]
        [SwaggerResponse(200, "Successfully found role", typeof(List<PrixVoyageRegionDto>))]
        [SwaggerResponse(400, "Bad request, error", typeof(List<PrixVoyageRegionDto>))]
        public async Task<ActionResult<IEnumerable<PrixVoyageRegionDto>>> Getrole()
            => await _prixVoyageRegionservice.GetAllAsync();

        // GET: api/role/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PrixVoyageRegionDto>> Getrole(int id)
        {
            var role = await _prixVoyageRegionservice.GetByIdAsync(id);
            if (role == null)
                return NotFound();
            return role;
        }

        // PUT: api/role/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> Putrole(int id, PrixVoyageRegionDto prixVoyageRegion)
        {
            if (id != prixVoyageRegion.Id)
                return BadRequest();
            try
            {
                await _prixVoyageRegionservice.UpdateAsync(prixVoyageRegion);
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
        public async Task<ActionResult<PrixVoyageRegionDto>> Postrole(PrixVoyageRegionDto role)
        {
            role = await _prixVoyageRegionservice.AddAsync(role);

            return CreatedAtAction("Getrole", new { id = role.Id }, role);
        }

        // DELETE: api/role/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PrixVoyageRegionDto>> Deleterole(int id)
        {
            var role = await _prixVoyageRegionservice.GetByIdAsync(id);
            if (role == null)
            {
                return NotFound();
            }

            await _prixVoyageRegionservice.DeleteAsync(role);

            return role;
        }

        private bool roleExists(int id)
            => _prixVoyageRegionservice.IfExists(id).Result;
    }
}
