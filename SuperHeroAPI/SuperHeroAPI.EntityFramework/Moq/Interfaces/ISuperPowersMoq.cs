using System.Collections.Generic;

namespace SuperHeroAPI.EntityFramework
{
    public interface ISuperPowersMoq
    {
        SuperPower RetornaSuperPowerById(int id);
        IList<SuperPower> RetornaSuperPowers();
        string Insert(SuperPower superpower);
        string Update(SuperPower superpower);
        string Delete(int id);
    }
}
