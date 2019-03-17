using System.Data.Entity; 

namespace SuperHeroAPI.EntityFramework
{
    public class SuperHeroAPIContext: DbContext
    {

        public SuperHeroAPIContext() : base("SuperHeroAPIContext")
        { }

        public DbSet<AuditEvent> AuditEvent { get; set; }
        public DbSet<ProtectionArea> ProtectionArea { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<SuperHero> SuperHero { get; set; }
        public DbSet<SuperPower> SuperPower { get; set; }
        public DbSet<User> User { get; set; }

        
    }
}