using AutoMapper;
using DoctorWho.Db.Entities;
using DoctorWho.Db.Repositories;
using DoctorWho.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DoctorWho.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EpisodeController : ControllerBase
    {
        private IEpisodeRepository _episodeRepository;
        private IMapper _mapper;

        public EpisodeController(IEpisodeRepository episodeRepository, IMapper mapper)
        {
            _episodeRepository = episodeRepository;
            _mapper = mapper;
        }

        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<EpisodeDto>>> GetAllEpisodes()
        //{
        //    var Episodes = await _episodeRepository.GetEpisodesAsync(); // this is entity not dto
        //    return Ok(_mapper.Map<IEnumerable<EpisodeDto>>(Episodes)); //here to convert from entity to dto
        //}
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Episode>>> GetEpisodes()
        {
            var episodes = await _episodeRepository.GetEpisodesAsync();
            return Ok(_mapper.Map<IEnumerable<EpisodeDto>>(episodes));
        }

        [HttpPost]
        public async Task<ActionResult> CreateEpisode(EpisodeDto episode)
        {
            var addedEpisode = await _episodeRepository.CreateEpisodeAsync(_mapper.Map<Episode>(episode));
            return Ok(_mapper.Map<EpisodeDto>(addedEpisode));
        }
        //make sure to apply the validation rules before you post any episode, if you don't do this you will got 400 error

        [HttpPost("/{episodeId}/enemy/{enemyId}")]
        public async Task<ActionResult> AddEnemyToEpisode(int episodeId, int enemyId)
        {
            var result = await _episodeRepository.AddEnemyToEpisodeAsync(episodeId, enemyId);
            if (result)
                return Ok();
            else
                return BadRequest();
        }

        [HttpPost("/{episodeId}/companion/{companionId}")]
        public async Task<ActionResult> AddCompanionToEpisode(int episodeId, int companionId)
        {
            var result = await _episodeRepository.AddCompanionToEpisodeAsync(episodeId, companionId);
            if (result)
                return Ok();
            else
                return BadRequest();
        }


    }
}
