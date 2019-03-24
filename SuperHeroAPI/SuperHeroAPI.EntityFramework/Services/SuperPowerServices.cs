using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SuperHeroAPI.EntityFramework
{
    public class SuperPowerServices : BaseServices, ISuperPowerServices
    {
        public SuperPowerServices(SuperHeroAPIContext context)
        {
            UnityOfWork = new UnityOfWork(context);
        }

        public SuperPower Get(int id)
        {
            return UnityOfWork.SuperPowerRepository.Get(r => r.Id == id);
        }

        public List<SuperPower> GetAll()
        {
            return UnityOfWork.SuperPowerRepository.GetAll();
        }

        public SuperPower Create(SuperPower superPower)
        {
            UnityOfWork.SuperPowerRepository.Add(superPower);

            UnityOfWork.SaveAllChanges();

            var user = HttpContext.Current.User;

            return superPower;
        }

        public SuperPower Update(SuperPower superPower)
        {
            var dbSuperPower = UnityOfWork.SuperPowerRepository.Update(superPower);

            UnityOfWork.SaveAllChanges();

            return dbSuperPower;
        }

        public SuperPower Remove(int id)
        {
            var superPower = UnityOfWork.SuperPowerRepository.Get(r => r.Id == id);

            if (superPower != null)
            {
                var dbSuperPower = UnityOfWork.SuperPowerRepository.Remove(superPower);

                UnityOfWork.SaveAllChanges();

                return dbSuperPower;
            }

            return null;
        }
    }
}