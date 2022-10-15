using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NZWalksAPI.Models.Domain;
using NZWalksAPI.Models.DTO;
using NZWalksAPI.Repositories;
using NZWalksAPI.Repositories.Interfaces;

namespace NZWalksAPI.Controllers
{
    [ApiController]
    [Route("Walks")]
    public class WalksController : Controller
    {
        private readonly IWalkRepository _walkRepository;
        private readonly IRegionRepository regionRepository;
        private readonly IWalkDifficultyRepository walkDifficultyRepository;
        private readonly IMapper _mapper;

        public WalksController(IWalkRepository walkRepository, IRegionRepository regionRepository, IWalkDifficultyRepository walkDifficultyRepository, IMapper mapper)
        {
           _walkRepository = walkRepository;
            this.regionRepository = regionRepository;
            this.walkDifficultyRepository = walkDifficultyRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetWalksAsync()
        {
            var allWalks = await _walkRepository.GetAllWalks();
            var allWalksDTO = _mapper.Map<List<WalkDTO>>(allWalks);
            return Ok(allWalksDTO);
        }


        [HttpGet]
        [Route("{id:guid}")]
        [ActionName("GetWalkById")]
        public async Task<IActionResult> GetWalkById([FromRoute]Guid id)
        {
            var domainWalk = await _walkRepository.GetWalkById(id);
            if(domainWalk == null)
            {
                return NotFound();
            }
            var walkDTO =_mapper.Map<WalkDTO>(domainWalk);
            return Ok(walkDTO);
        }

        [HttpPost]
        public async Task<IActionResult> InsertWalk([FromBody]AddWalkRequest addWalkRequest)
        {
            if (!await IsValidWalkRequest(addWalkRequest))
            {
                return BadRequest(ModelState);
            }

            // 1) Convert DTO to domain object
            var walkDomain = new Walk
            {
                Length = addWalkRequest.Length,
                Name = addWalkRequest.Name,
                RegionId = addWalkRequest.RegionId,
                WalkDifficultyId = addWalkRequest.WalkDifficultyId,
            };

            // 2) Add domain object to db
            var result = await _walkRepository.InsertWalk(walkDomain);

            // 3) convert domain object to DTO again
            var walkDTO = _mapper.Map<WalkDTO>(result);

            // 4) Send it to client
            return CreatedAtAction(nameof(GetWalkById), new { id = walkDTO.Id }, walkDTO);
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteWalkAsync(Guid id)
        {
            var dbWalk = await _walkRepository.DeleteWalk(id);
            if (dbWalk == null)
            {
                return NotFound();
            }
            var walkDTO = _mapper.Map<WalkDTO>(dbWalk);
            return Ok(walkDTO);
        }

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateWalkAsync([FromRoute] Guid id, [FromBody] AddWalkRequest walkRequest)
        {
            // convert dto to domain object
            var dbWalk = new Walk()
            {
                Length = walkRequest.Length,
                Name = walkRequest.Name,
                RegionId = walkRequest.RegionId,
                WalkDifficultyId = walkRequest.WalkDifficultyId,
            };

            // update domain object using repository method
            var updatedWalk = await _walkRepository.UpdateWalk(id, dbWalk);

            // if id is invalid, show notfound
            if (updatedWalk == null)
            {
                return NotFound();
            }

            // else, convert domain object to dto and send to client
            var walkDTO = _mapper.Map<WalkDTO>(updatedWalk);
            return Ok(walkDTO);
        }

        private async Task<bool> IsValidWalkRequest(AddWalkRequest addWalkRequest)
        {
            if(addWalkRequest == null)
            {
                ModelState.AddModelError(nameof(addWalkRequest), $"{nameof(addWalkRequest)} object should not be null");
                return false;
            }

            var region = await this.regionRepository.GetRegionAsync(addWalkRequest.RegionId);
            if(region == null)
            {
                ModelState.AddModelError(nameof(addWalkRequest.RegionId), $"{nameof(addWalkRequest.RegionId)} is not existing in DB");
            }

            var walkDifficulty = await this.walkDifficultyRepository.GetWalkDifficultyById(addWalkRequest.WalkDifficultyId);
            if (walkDifficulty == null)
            {
                ModelState.AddModelError(nameof(addWalkRequest.WalkDifficultyId), $"{nameof(addWalkRequest.WalkDifficultyId)} is not existing in DB");
            }

            if(ModelState.ErrorCount > 0)
            {
                return false;
            }
            return true;

        }
    }
}
