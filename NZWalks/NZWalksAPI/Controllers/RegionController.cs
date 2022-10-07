using Microsoft.AspNetCore.Mvc;
using NZWalksAPI.Models.Domain;
using NZWalksAPI.Models.DTO;
using NZWalksAPI.Repositories;

namespace NZWalksAPI.Controllers
{
    [ApiController]
    [Route("Regions")]
    public class RegionController : Controller
    {
        private readonly IRegionRepository _regionRepository;
        public RegionController(IRegionRepository regionRepository)
        {
            _regionRepository = regionRepository;
        }

        [HttpGet]
        public IActionResult GetAllRegions()
        {
            var regions = _regionRepository.GetAllRegions();
            List<RegionDTO> regionDTOs = new List<RegionDTO>();
            regions.ToList().ForEach(t => regionDTOs.Add(new RegionDTO
            {
                RegionCode = t.Code,
                RegionId = t.Id,
                RegionName = t.Name,
                Area = t.Area,
                Lat = t.Lat,
                Long = t.Long,
                TotalPopulation = t.Population,
            }));

            return Ok(regionDTOs);
        }
       
    }
}
