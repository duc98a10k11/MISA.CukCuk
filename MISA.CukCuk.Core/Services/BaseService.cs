using MISA.CukCuk.Core.Interfaces.Repository;
using MISA.CukCuk.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.CukCuk.Core.Services
{
    /// <summary>
    /// Base Service
    /// </summary>
    /// <typeparam name="MISAEntity"></typeparam>
    /// CreatedBY: LMDuc (27/04/2021)
    public class BaseService<MISAEntity> : IBaseService<MISAEntity> where MISAEntity : class
    {
        IBaseRepository<MISAEntity> _baseRepository;
        //Contructor
        public BaseService(IBaseRepository<MISAEntity> baseRepository)
        {
            _baseRepository = baseRepository;
        }
        /// <summary>
        /// Xóa bản ghi theo id trong DB
        /// </summary>
        /// <param name="entityId">id của bản ghi</param>
        /// <returns>số bản ghi được xóa</returns>
        /// CreatedBy: LMDuc(27/04/2021)
        public int Delete(Guid entityId)
        {
            return _baseRepository.Delete(entityId);
        }

        /// <summary>
        /// Lấy dữ liệu toàn bộ bản ghi trong DB
        /// </summary>
        /// <returns>danh sách dữ liệu các bản ghi</returns>
        /// CreatedBy: LMDuc (27/04/2021)
        public IEnumerable<MISAEntity> GetAll()
        {
            return _baseRepository.GetAll();
        }

        /// <summary>
        /// Lấy dữ liệu bản ghi theo id
        /// </summary>
        /// <param name="entityId">id của bản ghi</param>
        /// <returns>dữ liệu của bản ghi</returns>
        /// CreatedBy: LMDuc (27/04/2021)
        public MISAEntity GetById(Guid entityId)
        {
            return _baseRepository.GetById(entityId);
        }

        /// <summary>
        /// Thêm bản ghi
        /// </summary>
        /// <param name="entity">dữ liệu bản ghi cần thêm</param>
        /// <returns>số bản ghi được thêm vào DB</returns>
        /// CreatedBy: LMDuc (27/04/2021)
        public int Insert(MISAEntity entity)
        {
            //validate dữ liệu
            Validate(entity);
            return _baseRepository.Insert(entity);
        }

        /// <summary>
        /// validate dữ liệu
        /// </summary>
        /// <param name="entity">dữ liệu cần validate</param>
        /// CreatedBy: LMDuc (27/04/2021)
        protected virtual void Validate(MISAEntity entity)
        {

        }

        /// <summary>
        /// Cập nhật bản ghi
        /// </summary>
        /// <param name="entity">bản ghi cần cập nhật</param>
        /// <returns></returns>
        /// CreatedBy: LMDuc (27/04/2021)
        public int Update(Guid entityId, MISAEntity entity)
        {
            return _baseRepository.Update(entityId,entity);
        }
    }
}
