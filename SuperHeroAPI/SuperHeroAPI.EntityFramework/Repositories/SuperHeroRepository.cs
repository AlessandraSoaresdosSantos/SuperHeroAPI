namespace SuperHeroAPI.EntityFramework
{
    public class SuperHeroRepository : RepositoryBase<SuperHero>, ISuperHeroRepository
    {
        public SuperHeroRepository(SuperHeroAPIContext Db) : base(Db)
        {
        }
    }
}