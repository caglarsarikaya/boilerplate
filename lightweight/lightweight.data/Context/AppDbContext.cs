using lightweight.data.Configuraitons;
using lightweight.data.Model;
using lightweight.data.Seed;
using Microsoft.EntityFrameworkCore;

namespace lightweight.data.Context
{
    public class AppDbContext:DbContext
    {
        public static string constr = @"Server=localhost\SQLEXPRESS;Database=mazakaDb;Trusted_Connection=True;";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                if (!optionsBuilder.IsConfigured) optionsBuilder.UseSqlServer(constr);
            }
        }

        public AppDbContext(DbContextOptions<AppDbContext> options): base (options)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Duty> Duties { get; set; }
        public DbSet<DutyStatuses> DutyStatuses { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
         {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new DutyConfiguration());
            modelBuilder.ApplyConfiguration(new DutyStatusesConfiguration());

            modelBuilder.ApplyConfiguration(new UserSeed(new int[] {0, 1,2,3,4,5,6,7,8,9}));
            modelBuilder.ApplyConfiguration(new DutySeed(new int[] {0, 1,2,3,4,5,6,7,8,9}));
            modelBuilder.ApplyConfiguration(new DutyStatusesSeed(new int[] {0, 1,2,3,4,5,6,7,8,9}));

        }
        
       
    }
}