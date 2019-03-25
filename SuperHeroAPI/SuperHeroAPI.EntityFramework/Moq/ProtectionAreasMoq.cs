using System.Collections.Generic;
using System.Linq;

namespace SuperHeroAPI.EntityFramework
{
    public class ProtectionAreasMoq: IProtectionAreasMoq
    {
        public ProtectionAreasMoq()
        { }

        public ProtectionArea RetornaProtectionAreaById(int id)
        {
            IEnumerable<ProtectionArea> protectionAreas = CargaProtectionAreas();

            ProtectionArea _protectionArea = (from p in protectionAreas
                                              where p.Id == id
                                              select p).FirstOrDefault();

            return _protectionArea;
        }

        public IList<ProtectionArea> RetornaProtectionAreas()
        {
            return CargaProtectionAreas().ToList();
        }

        public string Insert(ProtectionArea protectionArea)
        {

            var carga = CargaProtectionAreas();

            var query = carga.Where(x => x.Id == protectionArea.Id).FirstOrDefault();

            if (query != null)
            {
                return "Valor já cadastrado";
            }
            else
            {
                return "Cadastrado realizado com sucesso";
            }
        }

        public string Update(ProtectionArea protectionArea)
        {

            var carga = CargaProtectionAreas();

            var query = carga.Where(x => x.Id == protectionArea.Id).FirstOrDefault();

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

            var carga = CargaProtectionAreas();

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

        private IEnumerable<ProtectionArea> CargaProtectionAreas()
        {
            List<ProtectionArea> protectionAreas = new List<ProtectionArea>();
            protectionAreas.Add(new ProtectionArea()
            {
                Id = 1,
                Name = "Area A",
                Lat = 1.45f,
                Long = 3.45f,
                Radius = 6.3f
            });

            protectionAreas.Add(new ProtectionArea()
            {
                Id = 2,
                Name = "Area B",
                Lat = 3.12f,
                Long = 2.15f,
                Radius = 3.2f
            });

            return protectionAreas;
        }
    }
}