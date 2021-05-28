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
    [ApiExplorerSettings(GroupName = "Gestion des régions")]
    public class RegionsController : BaseApiController
    {
        private readonly IRegionService _regionService;

        public RegionsController(IRegionService regionService)
            => (_regionService) = (regionService);

        // GET: api/Regions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RegionDto>>> GetRegion()
            => await _regionService.GetAllAsync();

        // GET: api/Regions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RegionDto>> GetRegion(int id)
        {
            var region = await _regionService.GetByIdAsync(id);

            if (region == null)
            {
                return NotFound();
            }

            return region;
        }

        // PUT: api/Regions/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRegion(int id, RegionDto region)
        {
            if (id != region.Id)
            {
                return BadRequest();
            }

            try
            {
                await _regionService.UpdateAsync(region);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RegionExists(id))
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

        // POST: api/Regions
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<RegionDto>> PostRegion(RegionDto region)
        {
            try
            {
                await _regionService.AddAsync(region);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            return CreatedAtAction("GetRegion", new { id = region.Id }, region);
        }

        // DELETE: api/Regions/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<RegionDto>> DeleteRegion(int id)
        {
            var region = await _regionService.GetByIdAsync(id);
            if (region == null)
            {
                return NotFound();
            }

            await _regionService.DeleteAsync(region);

            return region;
        }

        private bool RegionExists(int id)
            => _regionService.IfExists(id).Result;
    }
}
