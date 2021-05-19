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
    [ApiExplorerSettings(GroupName = "Gestion des livraisons")]
    public class LivraisonsController : ControllerBase
    {
        public readonly ILivraisonService _livraisonService;

        public LivraisonsController(ILivraisonService LivraisonService)
            => _livraisonService = LivraisonService;

        // GET: api/Livraison
        [HttpGet]
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [SwaggerOperation(
            Summary = "Liste de toutes les Livraison",
            Description = "Recupérer la liste des Livraison"
        )]
        [SwaggerResponse(200, "Successfully found Livraison", typeof(List<LivraisonDto>))]
        [SwaggerResponse(400, "Bad request, error", typeof(List<LivraisonDto>))]
        public async Task<ActionResult<IEnumerable<LivraisonDto>>> GetLivraison()
            => await _livraisonService.GetAllAsync();

        // GET: api/Livraison/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LivraisonDto>> GetLivraison(int id)
        {
            var Livraison = await _livraisonService.GetByIdAsync(id);
            if (Livraison == null)
                return NotFound();
            return Livraison;
        }

        // PUT: api/Livraison/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLivraison(int id, LivraisonDto Livraison)
        {
            if (id != Livraison.Id)
                return BadRequest();
            try
            {
                await _livraisonService.UpdateAsync(Livraison);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LivraisonExists(id))
                    return NotFound();
                else
                    throw;
            }
            return NoContent();
        }

        // POST: api/Livraison
        /// <summary>
        /// Save new Livraison
        /// </summary>
        /// <param name="Livraison"></param>
        /// <returns></returns>
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<LivraisonDto>> PostLivraison(LivraisonDto Livraison)
        {
            Livraison = await _livraisonService.AddAsync(Livraison);

            return CreatedAtAction("GetLivraison", new { id = Livraison.Id }, Livraison);
        }

        // DELETE: api/Livraison/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<LivraisonDto>> DeleteLivraison(int id)
        {
            var Livraison = await _livraisonService.GetByIdAsync(id);
            if (Livraison == null)
            {
                return NotFound();
            }

            await _livraisonService.DeleteAsync(Livraison);

            return Livraison;
        }

        private bool LivraisonExists(int id)
            => _livraisonService.IfExists(id).Result;
    }
}
