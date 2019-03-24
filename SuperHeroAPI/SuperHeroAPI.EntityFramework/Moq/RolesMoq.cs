using System.Collections.Generic;
using System.Linq;

namespace SuperHeroAPI.EntityFramework
{
    public class RolesMoq : IRolesMoq
    {
        public RolesMoq()
        { }

        public Role RetornaRoleById(int id)
        {
            IEnumerable<Role> roles = CargaRoles();

            Role role = (from _role in roles where _role.Id == id select _role).FirstOrDefault();

            return role;
        }

        public IList<Role> RetornaRoles()
        {
            return CargaRoles().ToList();
        }

        public string Insert(Role role) {

            var carga = CargaRoles();

            var query = carga.Where(x => x.Id == role.Id).FirstOrDefault();

            if (query != null)
            {
                return "Valor já cadastrado";
            }
            else {
                return "Cadastrado realizado com sucesso";
            }
        }

        public string Update(Role role)
        {

            var carga = CargaRoles();

            var query = carga.Where(x => x.Id == role.Id).FirstOrDefault();

            if (query != null)
            {
                return "Atualização realizada com sucesso";
            }
            else
            {
                return "Valor não encontrado na base de dados";
            }
        }

        public string Delete(Role role)
        {

            var carga = CargaRoles();

            var query = carga.Where(x => x.Id == role.Id).FirstOrDefault();

            if (query != null)
            {
                return "Exclusão realizada com sucesso";
            }
            else
            {
                return "Valor não encontrado na base de dados";
            }
        }

        private IEnumerable<Role> CargaRoles()
        {
            List<Role> roles = new List<Role>();
            roles.Add(new Role()
            {
                Id = 1,
                Name = "Admin",
                User_Id = 1
            });

            roles.Add(new Role()
            {
                Id = 2,
                Name = "Standard ",
                User_Id = 2
            });

            return roles;
        }
    }
}