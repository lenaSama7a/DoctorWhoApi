namespace DoctorWho.Db.Entities
{
    public class EpisodeEnemy
    {
        public int EpisodeEnemyId { get; set; }
        public int EpisodeId { get; set; }
        public int EnemyId { get; set; }
        public Episode Episode { get; set; }
        public Enemy Enemy { get; set; }
    }
}
