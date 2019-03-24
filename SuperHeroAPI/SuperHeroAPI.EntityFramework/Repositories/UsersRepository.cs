namespace SuperHeroAPI.EntityFramework
{
    public class UsersRepository : RepositoryBase<User>, IUsersRepository
    {
        public UsersRepository(SuperHeroAPIContext Db) : base(Db)
        {
        }
    }
}