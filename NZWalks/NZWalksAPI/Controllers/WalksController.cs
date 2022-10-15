using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NZWalksAPI.Models.Domain;
using NZWalksAPI.Models.DTO;
using NZWalksAPI.Repositories.Interfaces;

namespace NZWalksAPI.Controllers
{
    [ApiController]
    [Route("Walks")]
    public class WalksController : Controller
    {
        private readonly IWalkRepository _walkRepository;
        private readonly IMapper _mapper;

        public WalksController(IWalkRepository walkRepository, IMapper mapper)
        {
           _walkRepository = walkRepository;
           _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetWalksAsync()
        {
            var allWalks = await _walkRepository.GetAllWalks();
            var allWalksDTO = _mapper.Map<List<WalkDTO>>(allWalks);
            return Ok(allWalksDTO);
        }
    }
}
