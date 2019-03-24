using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SuperHeroAPI.EntityFramework
{
    public class RoleServices : BaseServices, IRoleServices
    {
        public RoleServices(SuperHeroAPIContext context)
        {
            UnityOfWork = new UnityOfWork(context);
        }

        public Role Get(int id)
        {
            return UnityOfWork.RoleRepository.Get(r => r.Id == id);
        }

        public List<Role> GetAll()
        {
            return UnityOfWork.RoleRepository.GetAll();
        }

        public Role Create(Role role)
        {
            UnityOfWork.RoleRepository.Add(role);

            UnityOfWork.SaveAllChanges();

            return role;
        }

        public Role Update(Role role)
        {
            var dbRole = UnityOfWork.RoleRepository.Update(role);

            UnityOfWork.SaveAllChanges();

            return dbRole;
        }

        public Role Remove(int id)
        {
            var role = UnityOfWork.RoleRepository.Get(r => r.Id == id);

            if (role != null)
            {
                var dbRole = UnityOfWork.RoleRepository.Remove(role);

                UnityOfWork.SaveAllChanges();

                return dbRole;
            }

            return null;
        }

        
    }
}