namespace SuperHeroAPI.EntityFramework
{
    public class SuperPowerRepository : RepositoryBase<SuperPower>, ISuperPowerRepository
    {
        public SuperPowerRepository(SuperHeroAPIContext Db) : base(Db)
        {
        }
    }
}