using System.Collections.Generic;
using System.Linq;

namespace SuperHeroAPI.EntityFramework
{
    public class SuperPowersMoq : ISuperPowersMoq
    {
        public SuperPowersMoq()
        { }

        public SuperPower RetornaSuperPowerById(int id)
        {
            IEnumerable<SuperPower> SuperPowers = CargaSuperPowers();

            SuperPower SuperPower = (from _SuperPower in SuperPowers where _SuperPower.Id == id select _SuperPower).FirstOrDefault();

            return SuperPower;
        }

        public IList<SuperPower> RetornaSuperPowers()
        {
            return CargaSuperPowers().ToList();
        }

        public string Insert(SuperPower SuperPower)
        {

            var carga = CargaSuperPowers();

            var query = carga.Where(x => x.Id == SuperPower.Id).FirstOrDefault();

            if (query != null)
            {
                return "Valor já cadastrado";
            }
            else
            {
                return "Cadastrado realizado com sucesso";
            }
        }

        public string Update(SuperPower SuperPower)
        {

            var carga = CargaSuperPowers();

            var query = carga.Where(x => x.Id == SuperPower.Id).FirstOrDefault();

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

            var carga = CargaSuperPowers();

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

        private IEnumerable<SuperPower> CargaSuperPowers()
        {
            List<SuperPower> SuperPowers = new List<SuperPower>();
            SuperPowers.Add(new SuperPower()
            {
                Id = 1,
                Name = "America",
                Description = "SuperPower America" 
            });

            SuperPowers.Add(new SuperPower()
            {
                Id = 2,
                Name = "Batman",
                Description = "SuperPower Batman"
            });

            return SuperPowers;
        }
    }
}