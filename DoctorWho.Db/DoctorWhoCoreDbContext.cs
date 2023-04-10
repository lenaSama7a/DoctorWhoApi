using DoctorWho.Db.Entities;
using Microsoft.EntityFrameworkCore;

namespace DoctorWho.Db
{
    public class DoctorWhoCoreDbContext : DbContext
    {
        public DbSet<Author> Authors { get; set; }
        public DbSet<Companion> Companions { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Enemy> Enemies { get; set; }
        public DbSet<Episode> Episodes { get; set; }
        public DbSet<EpisodeCompanion> EpisodeCompanions { get; set; }
        public DbSet<EpisodeEnemy> EpisodeEnemies { get; set; }
        public DbSet<ViewEpisodes> ViewEpisodes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
              "Data Source =DESKTOP-M189RU0;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False; Initial Catalog = DoctorWhoCore"
                );
        }

        public DoctorWhoCoreDbContext(DbContextOptions<DoctorWhoCoreDbContext> options)
           : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>().HasKey(a => a.AuthorId);
            modelBuilder.Entity<Author>().Property(a => a.AuthorName).IsRequired();
            var authorsList = new List<Author>{
                new Author {AuthorId=1, AuthorName="Edwidge Danticat" },
                new Author {AuthorId=2,AuthorName="Ernest Hemingway" },
                new Author {AuthorId=3,AuthorName="Saul Bellow" },
                new Author {AuthorId=4,AuthorName="Sidney Sheldon"  },
                new Author {AuthorId=5,AuthorName="Franz Kafka" }
            };
            modelBuilder.Entity<Author>().HasData(authorsList);


            modelBuilder.Entity<Companion>().HasKey(c => c.CompanionId);
            modelBuilder.Entity<Companion>().Property(c => c.CompanionName).IsRequired();
            var companionsList = new List<Companion>{
                new Companion {CompanionId=1, CompanionName="Ezra Pound", WhoPlayed="Agatha Christie" },
                new Companion {CompanionId=2,CompanionName="Tennessee Williams", WhoPlayed="Danielle Steel"  },
                new Companion {CompanionId=3,CompanionName="Willa Cather", WhoPlayed="Lord Byron"  },
                new Companion {CompanionId=4,CompanionName="Langston Hughes",WhoPlayed="Somerset Maugham"   },
                new Companion {CompanionId=5,CompanionName="Joan Didion",WhoPlayed="Djuna Barnes"  }
            };
            modelBuilder.Entity<Companion>().HasData(companionsList);


            modelBuilder.Entity<Doctor>().HasKey(d => d.DoctorId);
            modelBuilder.Entity<Doctor>().Property(d => d.DoctorName).IsRequired();
            modelBuilder.Entity<Doctor>().Property(d => d.BirthDate).HasDefaultValueSql("Null");
            modelBuilder.Entity<Doctor>().Property(d => d.FirstEpisodeDate).HasDefaultValueSql("Null");
            modelBuilder.Entity<Doctor>().Property(d => d.LastEpisodeDate).HasDefaultValueSql("Null");
            var doctorsList = new List<Doctor>
            {
                new Doctor{DoctorId=1, DoctorNumber=1, DoctorName="Smith" },
                new Doctor{DoctorId=2, DoctorNumber=2, DoctorName="Taylor" },
                new Doctor{DoctorId=3, DoctorNumber=3, DoctorName="Brown" },
                new Doctor{DoctorId=4, DoctorNumber=4, DoctorName="Williams" },
                new Doctor{DoctorId=5, DoctorNumber=5, DoctorName="Barker" }
            };
            modelBuilder.Entity<Doctor>().HasData(doctorsList);


            modelBuilder.Entity<Enemy>().HasKey(e => e.EnemyId);
            modelBuilder.Entity<Enemy>().Property(e => e.EnemyName).IsRequired();
            modelBuilder.Entity<Enemy>().Property(e => e.Description).HasDefaultValueSql("Null");
            var enemiesList = new List<Enemy>
            {
                new Enemy{EnemyId=1, EnemyName="Kingsley Amis", Description="the killer"},
                new Enemy{EnemyId=2, EnemyName="Fannie Flagg", Description="the suspect"},
                new Enemy{EnemyId=3, EnemyName="Iceberg Slim", Description="turns into a monster"},
                new Enemy{EnemyId=4, EnemyName="Camille Paglia", Description="the thief"},
                new Enemy{EnemyId=5, EnemyName="Maria Orczy", Description="The bully"}
            };
            modelBuilder.Entity<Enemy>().HasData(enemiesList);


            modelBuilder.Entity<Episode>().HasKey(e => e.EpisodeId);
            modelBuilder.Entity<Episode>().Property(e => e.EpisodeType).IsRequired();
            modelBuilder.Entity<Episode>().Property(e => e.Notes).IsRequired(false);
            modelBuilder.Entity<Episode>().Property(e => e.EpisodeDate).HasDefaultValueSql("Null");
            modelBuilder.Entity<Episode>().Property(e => e.Notes).HasDefaultValueSql("Null");
            modelBuilder.Entity<Episode>().Property(e => e.Notes).HasColumnType("varchar(600)");
            var episodesList = new List<Episode>
            {
                new Episode{EpisodeId=1,SeriesNumber=1, EpisodeNumber=1, EpisodeType="special", Title="Wednesdays Child Is Full of Woe", EpisodeDate=new DateTime(2000,5,29), AuthorId=1,DoctorId=2 },
                new Episode{EpisodeId=2,SeriesNumber=1, EpisodeNumber=2, EpisodeType="Filler", Title="Woe Is the Loneliest Number", EpisodeDate=new DateTime(2002,6,2), AuthorId=2,DoctorId=2 },
                new Episode{EpisodeId=3,SeriesNumber=2, EpisodeNumber=3, EpisodeType="Classic", Title="Friend or Woe", EpisodeDate=new DateTime(2007,7,1), AuthorId=2,DoctorId=1 },
                new Episode{EpisodeId=4,SeriesNumber=2, EpisodeNumber=3, EpisodeType="Filler", Title="Quid Pro Woe", EpisodeDate=new DateTime(2010,8,2), AuthorId=2,DoctorId=3 },
                new Episode{EpisodeId=5,SeriesNumber=3, EpisodeNumber=1, EpisodeType="Classic", Title="A Murder of Woes", EpisodeDate=new DateTime(2020,9,3), AuthorId=3,DoctorId=4 }
            };
            modelBuilder.Entity<Episode>().HasData(episodesList);


            var episodeCompanionsList = new List<EpisodeCompanion>
            {
            new EpisodeCompanion{ EpisodeCompanionId=1, EpisodeId=1, CompanionId=2 },
            new EpisodeCompanion{ EpisodeCompanionId=2,EpisodeId=2, CompanionId=3 },
            new EpisodeCompanion{ EpisodeCompanionId=3,EpisodeId=2, CompanionId=5 },
            new EpisodeCompanion{ EpisodeCompanionId=4,EpisodeId=3, CompanionId=4 },
            new EpisodeCompanion{ EpisodeCompanionId=5,EpisodeId=4, CompanionId=1 },
            new EpisodeCompanion{ EpisodeCompanionId=6,EpisodeId=5, CompanionId=3 },
            new EpisodeCompanion{ EpisodeCompanionId=7,EpisodeId=5, CompanionId=2 },
            new EpisodeCompanion{ EpisodeCompanionId=8,EpisodeId=3, CompanionId=3 }
            };
            modelBuilder.Entity<EpisodeCompanion>().HasData(episodeCompanionsList);


            var episodeEnemiesList = new List<EpisodeEnemy>
            {
            new EpisodeEnemy{ EpisodeEnemyId=1, EpisodeId=1, EnemyId=3 },
            new EpisodeEnemy{ EpisodeEnemyId=2, EpisodeId=1, EnemyId=4 },
            new EpisodeEnemy{ EpisodeEnemyId=3, EpisodeId=2, EnemyId=1 },
            new EpisodeEnemy{ EpisodeEnemyId=4, EpisodeId=2, EnemyId=3 },
            new EpisodeEnemy{ EpisodeEnemyId=5, EpisodeId=2, EnemyId=5 },
            new EpisodeEnemy{ EpisodeEnemyId=6, EpisodeId=4, EnemyId=4 },
            new EpisodeEnemy{ EpisodeEnemyId=7, EpisodeId=4, EnemyId=3 },
            new EpisodeEnemy{ EpisodeEnemyId=8, EpisodeId=4, EnemyId=2 }

            };
            modelBuilder.Entity<EpisodeEnemy>().HasData(episodeEnemiesList);

            modelBuilder.Entity<ViewEpisodes>().HasNoKey().ToView("ViewEpisodes");

            modelBuilder.HasDbFunction(typeof(DoctorWhoCoreDbContext).GetMethod(nameof(fnCompanions), new[] { typeof(int) }))
            .HasName("fnCompanions");

            modelBuilder.HasDbFunction(typeof(DoctorWhoCoreDbContext).GetMethod(nameof(fnEnemies), new[] { typeof(int) }))
            .HasName("fnEnemies");
        }

        public string fnEnemies(int EpisodeId) => throw new NotSupportedException();
        public string fnCompanions(int EpisodeId) => throw new NotSupportedException();
    }
}
