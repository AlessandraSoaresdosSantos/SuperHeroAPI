using System.Collections.Generic;

namespace SuperHeroAPI.EntityFramework
{
    public interface IProtectionAreasMoq
    {
        ProtectionArea RetornaProtectionAreaById(int id);
        IList<ProtectionArea> RetornaProtectionAreas();
        string Insert(ProtectionArea ProtectionArea);
        string Update(ProtectionArea ProtectionArea);
        string Delete(int id);
    }
}
