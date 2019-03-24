using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
