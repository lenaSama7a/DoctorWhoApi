using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DoctorWho.Db.Entities;

namespace DoctorWho.Db.Repositories
{
    public class EpisodeCompanionRepository
    {
        private DoctorWhoCoreDbContext _context;
        public EpisodeCompanionRepository(DoctorWhoCoreDbContext context)
        {
            _context = context;
        }

        public async Task AddCompanionToEpisodeAsync(int episodeID, int companionID)
        {
            var episode = await _context.Episodes.FindAsync(episodeID);
            var companion = await _context.Companions.FindAsync(companionID);
            if (episode != null && companion != null)
            {
                var episodeCompanion = new EpisodeCompanion { EpisodeId = episodeID, CompanionId = companionID };
                _context.EpisodeCompanions.Add(episodeCompanion);
                await _context.SaveChangesAsync();
            }
        }
        //public async Task<string> GetCompanionsForEpisodeAsync(int id)
        //{
        //    var companions = await _context.Companions.Select(c => _context.fnCompanions(id)).FirstOrDefaultAsync();
        //    return companions;
        //}
    }
}
