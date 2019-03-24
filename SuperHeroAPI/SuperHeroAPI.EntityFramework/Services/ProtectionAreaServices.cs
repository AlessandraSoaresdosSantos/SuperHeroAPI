using System.Collections.Generic;

namespace SuperHeroAPI.EntityFramework
{
    public class ProtectionAreaServices : BaseServices, IProtectionAreaServices
    {
        public ProtectionAreaServices(SuperHeroAPIContext context)
        {
            UnityOfWork = new UnityOfWork(context);
        }

        public ProtectionArea Get(int id)
        {
            return UnityOfWork.ProtectionAreaRepository.Get(r => r.Id == id);
        }

        public List<ProtectionArea> GetAll()
        {
            return UnityOfWork.ProtectionAreaRepository.GetAll();
        }

        public ProtectionArea Create(ProtectionArea protectionArea)
        {
            UnityOfWork.ProtectionAreaRepository.Add(protectionArea);

            UnityOfWork.SaveAllChanges();

            return protectionArea;
        }

        public ProtectionArea Update(ProtectionArea protectionArea)
        {
            var dbprotectionArea = UnityOfWork.ProtectionAreaRepository.Update(protectionArea);

            UnityOfWork.SaveAllChanges();

            return dbprotectionArea;
        }

        public ProtectionArea Remove(int id)
        {
            var protectionArea = UnityOfWork.ProtectionAreaRepository.Get(r => r.Id == id);

            if (protectionArea != null)
            {
                var dbProtectionArea = UnityOfWork.ProtectionAreaRepository.Remove(protectionArea);

                UnityOfWork.SaveAllChanges();

                return dbProtectionArea;
            }

            return null;
        }
        public List<ProtectionArea> GetRadiusSuperHero(float latitude, float longitude)
        {
            List<ProtectionArea> _values = UnityOfWork.ProtectionAreaRepository.GetAll(_ => _.Lat == latitude && _.Long == longitude && _.Radius <= 10f);

            if (_values.Count > 8) {
                return _values.GetRange(0, 7);
            }

            return _values;
        }
    }
}