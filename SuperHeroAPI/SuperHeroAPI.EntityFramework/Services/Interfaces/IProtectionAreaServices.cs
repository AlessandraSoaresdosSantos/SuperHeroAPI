using System.Collections.Generic;

namespace SuperHeroAPI.EntityFramework
{
    public interface IProtectionAreaServices : IServices<ProtectionArea>
    {
        List<ProtectionArea> GetRadiusSuperHero(float latitude, float longitude);
    }
}
