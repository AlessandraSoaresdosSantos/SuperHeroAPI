namespace SuperHeroAPI.EntityFramework
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddClassesReferences : DbMigration
    {
        public override void Up()
        {
            Sql("Update dbo.SuperHeroes set ProtectionArea_Id = 1 , SuperPower_Id = 1 Where Id = 1");
            Sql("Update dbo.SuperHeroes set ProtectionArea_Id = 2  Where Id = 2");
            Sql("Update dbo.SuperHeroes set ProtectionArea_Id = 3 , SuperPower_Id = 2 Where Id = 3");
            Sql("Update dbo.SuperHeroes set ProtectionArea_Id = 4 , SuperPower_Id = 2 Where Id = 4");
            Sql("Update dbo.SuperHeroes set ProtectionArea_Id = 5 , SuperPower_Id = 1 Where Id = 5");
            Sql("Update dbo.SuperHeroes set ProtectionArea_Id = 5 , SuperPower_Id = 2 Where Id = 6");
            Sql("Update dbo.SuperHeroes set ProtectionArea_Id = 4 , SuperPower_Id = 1 Where Id = 7");
            Sql("Update dbo.SuperHeroes set ProtectionArea_Id = 5 , SuperPower_Id = 2 Where Id = 8");
            Sql("Update dbo.SuperHeroes set ProtectionArea_Id = 1 , SuperPower_Id = 2 Where Id = 9");
            Sql("Update dbo.SuperPowers set SuperHero_Id = 1  Where Id = 1");
            Sql("Update dbo.SuperPowers set SuperHero_Id = 1  Where Id = 2");
            Sql("Update dbo.Roles set User_Id = 1  Where Id = 1");
            Sql("Update dbo.Roles set User_Id = 2  Where Id = 2");
            Sql("Update dbo.AuditEvents set Username_Id=1  Where Id = 1");
            Sql("Update dbo.AuditEvents set Username_Id=2  Where Id = 2");
        }
        
        public override void Down()
        {
        }
    }
}
