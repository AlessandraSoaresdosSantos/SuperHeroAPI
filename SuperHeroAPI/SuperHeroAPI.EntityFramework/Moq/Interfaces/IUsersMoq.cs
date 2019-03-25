using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperHeroAPI.EntityFramework
{
    public interface IUsersMoq
    {
        User RetornaUserById(int id);
        IList<User> RetornaUsers();
        string Insert(User User);
        string Update(User User);
        string Delete(int id);
    }
}
