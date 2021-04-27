using MISA.CukCuk.Core.Interfaces.Repository;
using MISA.CukCuk.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.CukCuk.Core.Services
{
    public class BaseService<MISAEntity> : IBaseService<MISAEntity> where MISAEntity : class
    {
        IBaseRepository<MISAEntity> _baseRepository;
        public BaseService(IBaseRepository<MISAEntity> baseRepository)
        {
            _baseRepository = baseRepository;
        }
        public int Delete(Guid entityId)
        {
            return _baseRepository.Delete(entityId);
        }

        public IEnumerable<MISAEntity> GetAll()
        {
            return _baseRepository.GetAll();
        }

        public MISAEntity GetById(Guid entityId)
        {
            return _baseRepository.GetById(entityId);
        }

        public int Insert(MISAEntity entity)
        {
            //validate dữ liệu
            Validate(entity);
            return _baseRepository.Insert(entity);
        }
        protected virtual void Validate(MISAEntity entity)
        {

        }
        public int Update(MISAEntity entity)
        {
            return _baseRepository.Update(entity);
        }
    }
}
