using System.Collections.Generic;

namespace SuperHeroAPI.EntityFramework
{
    public interface IRolesMoq
    {
        Role RetornaRoleById(int id);
        IList<Role> RetornaRoles();
        string Insert(Role role);
        string Update(Role role);
        string Delete(int id);
    }
}
