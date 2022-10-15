using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NZWalksAPI.Models.Domain;
using NZWalksAPI.Models.DTO;
using NZWalksAPI.Repositories.Interfaces;

namespace NZWalksAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WalkDifficultyController : Controller
    {
        private readonly IWalkDifficultyRepository _walkRepository;
        private readonly IMapper _mapper;

        public WalkDifficultyController(IWalkDifficultyRepository walkRepository, IMapper mapper)
        {
            _walkRepository = walkRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetWalksAsync()
        {
            var allWalks = await _walkRepository.GetAllWalkDifficulties();
            var allWalksDTO = _mapper.Map<List<WalkDifficultyDTO>>(allWalks);
            return Ok(allWalksDTO);
        }


        [HttpGet]
        [Route("{id:guid}")]
        [ActionName("GetWalkById")]
        public async Task<IActionResult> GetWalkById([FromRoute]Guid id)
        {
            var domainWalk = await _walkRepository.GetWalkDifficultyById(id);
            if (domainWalk == null)
            {
                return NotFound();
            }
            var walkDTO = _mapper.Map<WalkDifficultyDTO>(domainWalk);
            return Ok(walkDTO);
        }

        [HttpPost]
        public async Task<IActionResult> InsertWalk([FromBody] AddWalkDifficultyRequest addWalkRequest)
        {
            // 1) Convert DTO to domain object
            var walkDomain = new WalkDifficulty
            {
                Code = addWalkRequest.Code
            };

            // 2) Add domain object to db
            var result = await _walkRepository.InsertWalkDifficulty(walkDomain);

            // 3) convert domain object to DTO again
            var walkDTO = _mapper.Map<WalkDifficultyDTO>(result);

            // 4) Send it to client
            return CreatedAtAction(nameof(GetWalkById), new { id = walkDTO.Id }, walkDTO);
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteWalkAsync(Guid id)
        {
            var dbWalk = await _walkRepository.DeleteWalkDifficulty(id);
            if (dbWalk == null)
            {
                return NotFound();
            }
            var walkDTO = _mapper.Map<WalkDifficultyDTO>(dbWalk);
            return Ok(walkDTO);
        }

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateWalkAsync([FromRoute] Guid id, [FromBody]AddWalkDifficultyRequest walkRequest)
        {
            // convert dto to domain object
            var dbWalk = new WalkDifficulty()
            {
                Code = walkRequest.Code
            };

            // update domain object using repository method
            var updatedWalk = await _walkRepository.UpdateWalkDifficulty(id, dbWalk);

            // if id is invalid, show notfound
            if (updatedWalk == null)
            {
                return NotFound();
            }

            // else, convert domain object to dto and send to client
            var walkDTO = _mapper.Map<WalkDifficultyDTO>(updatedWalk);
            return Ok(walkDTO);
        }

    }
}
