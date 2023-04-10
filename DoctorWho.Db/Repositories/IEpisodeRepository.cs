using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DoctorWho.Db.Entities;

namespace DoctorWho.Db.Repositories
{
    public interface IEpisodeRepository
    {
        Task<IEnumerable<Episode>> GetEpisodesAsync();
        Task<Episode> CreateEpisodeAsync(Episode episode);
        Task<bool> AddEnemyToEpisodeAsync(int episodeId, int enemyId);
        Task<bool> AddCompanionToEpisodeAsync(int episodeId, int companionId);
    }
}
