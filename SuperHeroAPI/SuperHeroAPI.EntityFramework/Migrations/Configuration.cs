namespace SuperHeroAPI.EntityFramework
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Security.Cryptography;
    using System.Security.Policy;
    using System.Text;

    internal sealed class Configuration : DbMigrationsConfiguration<SuperHeroAPIContext> 
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "SuperHeroAPIContext";
        }

        protected override void Seed(SuperHeroAPI.EntityFramework.SuperHeroAPIContext context)
        {
            var protectionAreas = new List<ProtectionArea> {
                new ProtectionArea{ Name= "Area A", Lat= 1.45f, Long= 3.45f, Radius= 6.3f },
                new ProtectionArea{ Name= "Area B", Lat= 3.12f, Long= 2.15f, Radius= 3.2f },
                new ProtectionArea{ Name= "Area C", Lat= 4.15f, Long= 3f, Radius= 10.3f },
                new ProtectionArea{ Name= "Area D", Lat= 4.05f, Long= 1f, Radius= 9.3f },
                new ProtectionArea{ Name= "Area E", Lat= 2.05f, Long= 2f, Radius= 9.9f }
             };
            protectionAreas.ForEach(s => context.ProtectionArea.AddOrUpdate(p => p.Name, s));
            context.SaveChanges();


            var superHeros = new List<SuperHero> {
                new SuperHero{ Name= "Jordan",  Alias = "Bruce", ProtectionArea_Id=1, SuperPower_Id = 1 },
                new SuperHero{ Name= "Wonder Woman",  Alias = "Kate",  ProtectionArea_Id=2 , SuperPower_Id = 1},
                new SuperHero{ Name= "Michael",  Alias = "Ana",  ProtectionArea_Id=1, SuperPower_Id = 2 },
                new SuperHero{ Name= "Rafa",  Alias = "Bruce",  ProtectionArea_Id=2, SuperPower_Id = 1},
                new SuperHero{ Name= "Woman",  Alias = "Kate",  ProtectionArea_Id=1, SuperPower_Id = 1},
                new SuperHero{ Name= "Marrie",  Alias = "Anne",  ProtectionArea_Id=2, SuperPower_Id = 2},
                new SuperHero{ Name= "Thor",  Alias = "Anne",  ProtectionArea_Id=1, SuperPower_Id = 1},
                new SuperHero{ Name= "Marta",  Alias = "Bruce",  ProtectionArea_Id=2, SuperPower_Id = 1},
                new SuperHero{ Name= "Kate",  Alias = "Bruce",  ProtectionArea_Id=1, SuperPower_Id = 1},
             };


            var superPowers = new List<SuperPower>
            {
                new SuperPower{ Name = "America",   Description = "SuperPower America"},
                new SuperPower{ Name = "Batman",   Description = "SuperPower Batman"}
            };
            superPowers.ForEach(s => context.SuperPower.AddOrUpdate(p => p.Name, s));
            context.SaveChanges();

            superHeros.ForEach(s => context.SuperHero.AddOrUpdate(p => p.Name, s));
            context.SaveChanges();

            var users = new List<User> {
                new User{ Username= "marta2019", Password = new PreparaHash.PreparaHash().RetornaSenhaCriptografada("Brasil126") },
                new User{ Username= "joao2019",  Password = new PreparaHash.PreparaHash().RetornaSenhaCriptografada("Vitoria19752019") }
             };
            users.ForEach(s => context.User.AddOrUpdate(p => p.Username, s));
            context.SaveChanges();


            var roles = new List<Role> {
                new Role{  Name = "Admin" , User_Id = 1 },
                new Role{  Name = "Standard ", User_Id = 2 }
             };
            roles.ForEach(s => context.Role.AddOrUpdate(p => p.Name, s));
            context.SaveChanges();



            var auditEvents = new List<AuditEvent> {
                new AuditEvent{ Entity = "SuperHero", EntityId = 1, Action= "Get", Datetime= DateTime.Now, Username_Id=1 },
                new AuditEvent{ Entity = "SuperPower", EntityId = 2, Action= "Post", Datetime= DateTime.Now, Username_Id=2 }
                };
            auditEvents.ForEach(s => context.AuditEvent.AddOrUpdate(p => p.Entity, s));
            context.SaveChanges();
        }
    }
}
