using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NZWalksAPI.Models.Domain;
using NZWalksAPI.Models.DTO;
using NZWalksAPI.Repositories.Interfaces;

namespace NZWalksAPI.Controllers
{
    [ApiController]
    [Route("Regions")]
    public class RegionController : Controller
    {
        private readonly IRegionRepository _regionRepository;
        private readonly IMapper _mapper;

        public RegionController(IRegionRepository regionRepository, IMapper mapper)
        {
            _regionRepository = regionRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRegions()
        {
            var regions = await _regionRepository.GetAllRegionsAsync();
            var regionDTOs = _mapper.Map<List<RegionDTO>>(regions);
            return Ok(regionDTOs);
        }

        [HttpGet]
        [Route("{id:guid}")]
        [ActionName("GetRegionById")]
        public async Task<IActionResult> GetRegionById(Guid id)
        {
            var region = await _regionRepository.GetRegionAsync(id);

            if(region == null)
            {
                return NotFound();
            }

            var regionDTO = _mapper.Map<RegionDTO>(region);
            return Ok(regionDTO);

        }


        [HttpPost]
        public async Task<IActionResult> AddRegionAsync(AddRegionRequest region)
        {
            // Convert DTO to Domain object
            var dbRegion = new Region()
            {
                Lat = region.Lat,
                Long = region.Long,
                Area = region.Area,
                Code = region.RegionCode,
                Name = region.RegionName,
                Population = region.TotalPopulation,
            };

            // Save the region to Db through repository method
            var result = await _regionRepository.AddRegionAsync(dbRegion);

            // Convert the resulting Domain object to DTO and send to client
            var finalResponse = _mapper.Map<RegionDTO>(result);
            return CreatedAtAction(nameof(GetRegionById), new { id = finalResponse.Id}, finalResponse);
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteRegionAsync(Guid id)
        {
            var dbRegion = await _regionRepository.DeleteRegionAsync(id);
            if(dbRegion == null)
            {
                return NotFound();
            }
            var regionDTO = _mapper.Map<RegionDTO>(dbRegion);
            return Ok(regionDTO);
        }

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateRegionAsync([FromRoute]Guid id, [FromBody]AddRegionRequest region)
        {
            // convert dto to domain object
            var dbRegion = new Region()
            {
                Lat = region.Lat,
                Long = region.Long,
                Area = region.Area,
                Code = region.RegionCode,
                Name = region.RegionName,
                Population = region.TotalPopulation,
            };

            // update domain object using repository method
            var updatedRegion = await _regionRepository.UpdateRegionAsync(id, dbRegion);
            
            // if id is invalid, show notfound
            if(updatedRegion == null)
            {
                return NotFound();
            }

            // else, convert domain object to dto and send to client
            var regionDTO = _mapper.Map<RegionDTO>(updatedRegion);
            return Ok(regionDTO);
        }
    }
}
