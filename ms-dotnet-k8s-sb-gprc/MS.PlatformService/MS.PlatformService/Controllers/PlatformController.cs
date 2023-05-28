using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MS.PlatformService.Data.Interfaces;
using MS.PlatformService.Dtos;
using MS.PlatformService.Models;

namespace MS.PlatformService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PlatformController : ControllerBase
    {

        private readonly IPlatformRepository _platformRepository;
        private readonly IMapper _mapper;
        public PlatformController(IPlatformRepository platformRepository, IMapper mapper)
        {
            _platformRepository = platformRepository;
            _mapper = mapper;
        }

        [HttpGet()]
        public ActionResult<IEnumerable<PlatformReadDto>> GetAll()
        {
            var platforms = _platformRepository.GetPlatforms();

            IEnumerable<PlatformReadDto> platformDtos = _mapper.Map<IEnumerable<PlatformReadDto>>(platforms);
            return Ok(platformDtos);
        }

        [HttpGet("{id}",Name = "GetPlatformById")]
        public ActionResult<IEnumerable<PlatformReadDto>> GetPlatformById(Guid id)
        {
            var platform = _platformRepository.GetPlatformById(id);
            if (platform == null) return NotFound();

            PlatformReadDto platformDto = _mapper.Map<PlatformReadDto>(platform);
            return Ok(platformDto);
        }
        [HttpPost()]
        public ActionResult<PlatformReadDto> CreatePlatform(PlatformCreateDto platformCreate)
        {
            var platfomModel = _mapper.Map<Platform>(platformCreate);

            _platformRepository.CreatePlatform(platfomModel);
            _platformRepository.SaveChanges();

            var createdPlatform = _mapper.Map<PlatformReadDto>(platfomModel);

            return CreatedAtRoute(nameof(GetPlatformById), new { Id = createdPlatform.Id }, createdPlatform);
        }
    }
}