using System.Collections.Generic;
using System.Linq;

namespace SuperHeroAPI.EntityFramework.Moq
{
    public class SuperHeroesMoq : ISuperHeroesMoq
    {
        public SuperHeroesMoq()
        { }

        public SuperHero RetornaSuperHeroById(int id)
        {
            IEnumerable<SuperHero> SuperHeroes = CargaSuperHeroes();

            SuperHero SuperHero = (from _SuperHero in SuperHeroes where _SuperHero.Id == id select _SuperHero).FirstOrDefault();

            return SuperHero;
        }

        public IList<SuperHero> RetornaSuperHeroes()
        {
            return CargaSuperHeroes().ToList();
        }

        public string Insert(SuperHero SuperHero)
        {

            var carga = CargaSuperHeroes();

            var query = carga.Where(x => x.Id == SuperHero.Id).FirstOrDefault();

            if (query != null)
            {
                return "Valor já cadastrado";
            }
            else
            {
                return "Cadastrado realizado com sucesso";
            }
        }

        public string Update(SuperHero SuperHero)
        {

            var carga = CargaSuperHeroes();

            var query = carga.Where(x => x.Id == SuperHero.Id).FirstOrDefault();

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

            var carga = CargaSuperHeroes();

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

        private IEnumerable<SuperHero> CargaSuperHeroes()
        {
            List<SuperHero> SuperHeroes = new List<SuperHero>
            {
                new SuperHero()
                {
                    Id = 1,
                    Name = "Jordan",
                    Alias = "Bruce",
                    ProtectionArea_Id = 1,
                    SuperPower_Id = 1
                },

                new SuperHero()
                {
                    Id = 2,
                    Name = "Jordan",
                    Alias = "Kate",
                    ProtectionArea_Id = 2,
                    SuperPower_Id = 2
                }
            };

            return SuperHeroes;
        }
    }
}