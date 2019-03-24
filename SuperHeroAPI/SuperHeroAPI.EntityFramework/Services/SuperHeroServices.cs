using System.Collections.Generic;

namespace SuperHeroAPI.EntityFramework
{
    public class SuperHeroServices : BaseServices, ISuperHeroServices
    {
        public SuperHeroServices(SuperHeroAPIContext context)
        {
            UnityOfWork = new UnityOfWork(context);
        }

        public SuperHero Get(int id)
        {
            return UnityOfWork.SuperHeroRepository.Get(r => r.Id == id);
        }

        public List<SuperHero> GetAll()
        {
            return UnityOfWork.SuperHeroRepository.GetAll();
        }

        public List<SuperHero> GetAllByRadius(List<int> protectionAreas)
        {
            return UnityOfWork.SuperHeroRepository.GetAll(_ => protectionAreas.Contains(_.ProtectionArea.Id));
        }

        public SuperHero Create(SuperHero superHero)
        {
            UnityOfWork.SuperHeroRepository.Add(superHero);

            UnityOfWork.SaveAllChanges();

            return superHero;
        }

        public SuperHero Update(SuperHero superHero)
        { 
            var dbSuperHero = UnityOfWork.SuperHeroRepository.Update(superHero);

            UnityOfWork.SaveAllChanges();

            return dbSuperHero;
        }

        public SuperHero Remove(int id)
        {
            var superHero = UnityOfWork.SuperHeroRepository.Get(r => r.Id == id);

            if (superHero != null)
            {
                var dbSuperHero = UnityOfWork.SuperHeroRepository.Remove(superHero);

                UnityOfWork.SaveAllChanges();

                return dbSuperHero;
            }

            return null;
        }
    }
}