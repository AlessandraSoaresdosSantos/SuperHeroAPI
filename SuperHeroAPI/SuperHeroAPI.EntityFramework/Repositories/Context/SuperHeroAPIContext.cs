using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using static SuperHeroAPI.EntityFramework.DataConfiguration;

namespace SuperHeroAPI.EntityFramework
{
    public class SuperHeroAPIContext : DbContext
    {


        public SuperHeroAPIContext() : base("SuperHeroAPIContext")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<SuperHeroAPIContext, Configuration>());
            base.Configuration.ProxyCreationEnabled = false;
            this.Configuration.LazyLoadingEnabled = false;
            //Database.SetInitializer(new DropCreateDatabaseIfModelChanges<SuperHeroAPIContext>());

        }



        public DbSet<AuditEvent> AuditEvent { get; set; }
        public DbSet<ProtectionArea> ProtectionArea { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<SuperHero> SuperHero { get; set; }
        public DbSet<SuperPower> SuperPower { get; set; }
        public DbSet<User> User { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        //    modelBuilder.Configurations.Add(new UserConfiguration());
     
        }
    }
}