using System.Collections.Generic;

namespace SuperHeroAPI.EntityFramework
{
    public interface ISuperHeroesMoq
    {
        SuperHero RetornaSuperHeroById(int id);
        IList<SuperHero> RetornaSuperHeroes();
        string Insert(SuperHero SuperHero);
        string Update(SuperHero SuperHero);
        string Delete(int id);
    }
}
