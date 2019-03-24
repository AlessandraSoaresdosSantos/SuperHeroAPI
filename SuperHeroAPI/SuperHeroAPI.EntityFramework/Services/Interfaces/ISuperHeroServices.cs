using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperHeroAPI.EntityFramework
{
    public interface ISuperHeroServices : IServices<SuperHero>
    {
        List<SuperHero> GetAllByRadius(List<int> protectionAreas);
    }
}
