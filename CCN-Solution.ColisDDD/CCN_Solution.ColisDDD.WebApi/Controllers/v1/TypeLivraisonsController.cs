using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CCN_Solution.ColisDDD.Application.DTOs;
using CCN_Solution.ColisDDD.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CCN_Solution.ColisDDD.WebApi.Controllers.v1
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    [ApiExplorerSettings(GroupName = "Gestion des types de livraison")]
    public class TypeLivraisonsController : BaseApiController
    {
        private readonly ITypeLivraisonService _typeLivraisonService;

        public TypeLivraisonsController(ITypeLivraisonService typeLivraisonService)
            => (_typeLivraisonService) = (typeLivraisonService);

        // GET: api/TypeLivraisons
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TypeLivraisonDto>>> GetTypeLivraison()
            => await _typeLivraisonService.GetAllAsync();

        // GET: api/TypeLivraisons/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TypeLivraisonDto>> GetTypeLivraison(int id)
        {
            var TypeLivraison = await _typeLivraisonService.GetByIdAsync(id);

            if (TypeLivraison == null)
            {
                return NotFound();
            }

            return TypeLivraison;
        }

        // PUT: api/TypeLivraisons/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTypeLivraison(int id, TypeLivraisonDto TypeLivraison)
        {
            if (id != TypeLivraison.Id)
            {
                return BadRequest();
            }

            try
            {
                await _typeLivraisonService.UpdateAsync(TypeLivraison);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TypeLivraisonExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/TypeLivraisons
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TypeLivraisonDto>> PostTypeLivraison(TypeLivraisonDto TypeLivraison)
        {
            try
            {
                await _typeLivraisonService.AddAsync(TypeLivraison);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            return CreatedAtAction("GetTypeLivraison", new { id = TypeLivraison.Id }, TypeLivraison);
        }

        // DELETE: api/TypeLivraisons/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TypeLivraisonDto>> DeleteTypeLivraison(int id)
        {
            var TypeLivraison = await _typeLivraisonService.GetByIdAsync(id);
            if (TypeLivraison == null)
            {
                return NotFound();
            }

            await _typeLivraisonService.DeleteAsync(TypeLivraison);

            return TypeLivraison;
        }

        private bool TypeLivraisonExists(int id)
            => _typeLivraisonService.IfExists(id).Result;
    }
}
