using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.CukCuk.Core.Interfaces.Repository
{
    /// <summary>
    /// Interface Base Repository
    /// </summary>
    /// <typeparam name="MISAEntity"></typeparam>
    /// CreatedBy: LMDuc (28/04/2021)
    public interface IBaseRepository<MISAEntity> where MISAEntity : class
    {
        /// <summary>
        /// Lấy toàn bộ dữ liệu trong bảng
        /// </summary>
        /// <returns>
        /// Danh sách các bản ghi
        /// </returns>
        /// CreatedBy: LMDuc (27/04/2021)
        public IEnumerable<MISAEntity> GetAll();
        /// <summary>
        /// Lấy theo id
        /// </summary>
        /// <param name="entityId"></param>
        /// <returns></returns>
        /// CreatedBy: LMDuc (27/04/2021)
        public MISAEntity GetById(Guid entityId);
        /// <summary>
        /// Thêm dữ liệu
        /// </summary>
        /// <param name="entity">object</param>
        /// <returns>Số bản ghi thêm thành công</returns>
        /// CreatedBy: LMDuc (27/04/2021)
        public int Insert(MISAEntity entity);
        /// <summary>
        /// Cập nhật dữ liệu
        /// </summary>
        /// <param name="entity">object</param>
        /// <returns>Số bản ghi cập nhật thành công</returns>
        /// CreatedBy: LMDuc (27/04/2021)
        public int Update(Guid entityId, MISAEntity entity);
        /// <summary>
        /// Xóa bảng ghi theo id
        /// </summary>
        /// <param name="entityId">id của bản ghi cần xóa</param>
        /// <returns></returns>
        /// CreatedBy: LMDuc (27/04/2021)
        public int Delete(Guid entityId);
    }
}
