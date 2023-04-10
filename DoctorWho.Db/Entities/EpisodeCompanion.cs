namespace DoctorWho.Db.Entities
{
    public class EpisodeCompanion
    {
        public int EpisodeCompanionId { get; set; }
        public int EpisodeId { get; set; }
        public int CompanionId { get; set; }
        public Episode Episode { get; set; }
        public Companion Companion { get; set; }
    }
}
