namespace SuperHeroAPI.EntityFramework.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Security.Cryptography;
    using System.Security.Policy;
    using System.Text;

    internal sealed class Configuration : DbMigrationsConfiguration<SuperHeroAPI.EntityFramework.SuperHeroAPIContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(SuperHeroAPI.EntityFramework.SuperHeroAPIContext context)
        {
            var protectionAreas = new List<ProtectionArea> {
                new ProtectionArea{ Name= "Area A", Lat= 1.45f, Long= 3.45f, Radius= 6.3f },
                new ProtectionArea{ Name= "Area B", Lat= 3.12f, Long= 2.15f, Radius= 3.2f },
             };
            protectionAreas.ForEach(s => context.ProtectionArea.AddOrUpdate(p => p.Name, s));
            context.SaveChanges();
             
            var superPowers = new List<SuperPower>
            {
                new SuperPower{ Name = "America",   Description = "SuperPower America"},
                new SuperPower{ Name = "Batman",   Description = "SuperPower Batman"}
            };
            superPowers.ForEach(s => context.SuperPower.AddOrUpdate(p => p.Name, s));
            context.SaveChanges();

            var superHeros = new List<SuperHero> {
                new SuperHero{ Name= "Jordan",  Alias = "Bruce", ProtectionArea = new ProtectionArea{ Id = 1 } },
                new SuperHero{ Name= "Wonder Woman",  Alias = "Kate", ProtectionArea = new ProtectionArea{ Id = 2 } },
             };
            superHeros.ForEach(s => context.SuperHero.AddOrUpdate(p => p.Name, s));
            context.SaveChanges();
             
       
        }
    }
}
