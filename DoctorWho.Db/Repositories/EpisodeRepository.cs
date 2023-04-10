using DoctorWho.Db.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorWho.Db.Repositories
{
    public class EpisodeRepository : IEpisodeRepository
    {
        private DoctorWhoCoreDbContext _context;
        public EpisodeRepository(DoctorWhoCoreDbContext context)
        {
            _context = context;
        }

        public async Task<Episode> CreateEpisodeAsync(Episode episode)
        {
            _context.Episodes.Add(episode);
            await _context.SaveChangesAsync();
            return episode;
        }

        public async Task DeleteEpisodeAsync(int episodeNumber, string episodeTitle)
        {
            var episode = await _context.Episodes.Where(e => e.EpisodeNumber == episodeNumber && e.Title == episodeTitle).FirstOrDefaultAsync();
            if (episode != null)
            {
                _context.Episodes.Remove(episode);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Episode>> GetEpisodesAsync()
        {
            return await _context.Episodes.ToListAsync();
        }

        public async Task UpdateEpisodeAsync(Episode episode)
        {
            _context.Episodes.Update(episode);
            await _context.SaveChangesAsync();
        }

        public async Task<List<ViewEpisodes>> ViewEpisodesAsync()
        {
            var episodes = await _context.ViewEpisodes.ToListAsync();
            return episodes;
        }
        public async Task<bool> AddEnemyToEpisodeAsync(int episodeId, int enemyId)
        {
            var episode = await _context.Episodes.FindAsync(episodeId);
            var enemy = await _context.Enemies.FindAsync(enemyId);
            if (episode != null && enemy != null)
            {
                episode.EpisodeEnemies.Add(new EpisodeEnemy { EnemyId = enemyId, EpisodeId = episodeId });
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<bool> AddCompanionToEpisodeAsync(int episodeId, int companionId)
        {
            var episode = await _context.Episodes.FindAsync(episodeId);
            var companion = await _context.Companions.FindAsync(companionId);
            if (episode != null && companion != null)
            {
                episode.EpisodeCompanions.Add(new EpisodeCompanion { CompanionId = companionId, EpisodeId = episodeId });
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
