using Microsoft.EntityFrameworkCore;
using Rosneft.Domain;

namespace Rosneft.DAL
{
    public class RosneftDbContext : DbContext
    {
        public DbSet<RequestCard> RequestCards { get; set; }

        public RosneftDbContext()
        {
        }
        public RosneftDbContext(DbContextOptions<RosneftDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RequestCard>().ToTable("RequestCard");
            modelBuilder.Entity<RequestCard>().HasKey("RequestCardId");
            modelBuilder.Entity<RequestCard>().Property(it => it.RequestCardId).HasDefaultValueSql("NEXT VALUE FOR RequestCardIdSequence");
            modelBuilder.HasSequence<int>("RequestCardIdSequence").IncrementsBy(1).HasMin(1).HasMax(100000).StartsAt(1);
            base.OnModelCreating(modelBuilder);
        }
    }
}
