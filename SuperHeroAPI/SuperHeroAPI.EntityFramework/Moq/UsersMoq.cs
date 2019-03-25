using System.Collections.Generic;
using System.Linq;

namespace SuperHeroAPI.EntityFramework
{
    public class UsersMoq : IUsersMoq
    {
        public UsersMoq()
        { }

        public User RetornaUserById(int id)
        {
            IEnumerable<User> Users = CargaUsers();

            User User = (from _User in Users where _User.Id == id select _User).FirstOrDefault();

            return User;
        }

        public IList<User> RetornaUsers()
        {
            return CargaUsers().ToList();
        }

        public string Insert(User User)
        {

            var carga = CargaUsers();

            var query = carga.Where(x => x.Id == User.Id).FirstOrDefault();

            if (query != null)
            {
                return "Valor já cadastrado";
            }
            else
            {
                return "Cadastrado realizado com sucesso";
            }
        }

        public string Update(User User)
        {

            var carga = CargaUsers();

            var query = carga.Where(x => x.Id == User.Id).FirstOrDefault();

            if (query != null)
            {
                return "Atualização realizada com sucesso";
            }
            else
            {
                return "Valor não encontrado na base de dados";
            }
        }

        public string Delete(int id)
        {

            var carga = CargaUsers();

            var query = carga.Where(x => x.Id == id).FirstOrDefault();

            if (query != null)
            {
                return "Exclusão realizada com sucesso";
            }
            else
            {
                return "Valor não encontrado na base de dados";
            }
        }

        private IEnumerable<User> CargaUsers()
        {
            var criptografar = new PreparaHash.PreparaHash();

            List <User> Users = new List<User>();
            Users.Add(new User()
            {
                Id = 1,
                Username= "marta2019",
                Password =  criptografar.RetornaSenhaCriptografada("Brasil126")
            });

            Users.Add(new User()
            {
                Id = 2,
                Username = "joao2019",
                Password = criptografar.RetornaSenhaCriptografada("Vitoria19752019")
            });

            return Users;
        }
    }
}