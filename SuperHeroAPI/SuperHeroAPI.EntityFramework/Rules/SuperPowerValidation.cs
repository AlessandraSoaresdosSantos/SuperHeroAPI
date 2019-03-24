using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SuperHeroAPI.EntityFramework
{
    public class SuperPowerValidation
    {
        #region Declaração e inicialização de variáveis 

        private ISuperPowerServices SuperPowersServices;
        private readonly SuperHeroAPIContext context;

        public SuperPowerValidation()
        {
            context = new SuperHeroAPIContext();
            SuperPowersServices = new SuperPowerServices(context);
        }

        #endregion

        #region Métodos
        public bool SuperPowerComSuperHero(int SuperPowerId)
        {

            SuperHero superHero = context.SuperHero.Where(_ => _.SuperPower.Id == SuperPowerId).FirstOrDefault();

            if (superHero != null)
            {
                return true;
            }

            return false;
        }

        #endregion

    }
}