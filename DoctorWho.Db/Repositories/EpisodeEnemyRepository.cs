using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DoctorWho.Db.Entities;

namespace DoctorWho.Db.Repositories
{
    public class EpisodeEnemyRepository
    {
        private DoctorWhoCoreDbContext _context;
        public EpisodeEnemyRepository(DoctorWhoCoreDbContext context)
        {
            _context = context;
        }
        public async Task AddEnemyToEpisodeAsync(int episodeID, int enemyID)
        {
            var episode = await _context.Episodes.FindAsync(episodeID);
            var enemy = await _context.Enemies.FindAsync(enemyID);
            if (episode != null && enemy != null)
            {
                var episodeEnemy = new EpisodeEnemy { EpisodeId = episodeID, EnemyId = enemyID };
                _context.EpisodeEnemies.Add(episodeEnemy);
                await _context.SaveChangesAsync();
            }
        }
    }
}
