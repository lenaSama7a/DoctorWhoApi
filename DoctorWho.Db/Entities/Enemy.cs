namespace DoctorWho.Db.Entities
{
    public class Enemy
    {
        public Enemy()
        {
            EpisodeEnemies = new List<EpisodeEnemy>();
        }
        public int EnemyId { get; set; }
        public string EnemyName { get; set; }
        public string Description { get; set; }
        public List<EpisodeEnemy> EpisodeEnemies { get; set; }
    }
}

