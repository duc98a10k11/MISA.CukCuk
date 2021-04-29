using MISA.CukCuk.Core.AttributeCustom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.CukCuk.Core.Entities
{
    /// <summary>
    /// Thông tin nhóm khách hàng
    /// </summary>
    /// CreatedBy: LMDuc(27/04/2021)
    public class CustomerGroup
    {
        /// <summary>
        /// Khóa chính
        /// </summary>
        public Guid? CustomerGroupId { get; set; }
        /// <summary>
        /// Tên nhóm khách hàng
        /// </summary>
        
        [MISARequired]
        public string CustomerGroupName { get; set; }
        /// <summary>
        /// id của cha (khóa ngoại)
        /// </summary>
        public Guid? ParentId { get; set; }
        /// <summary>
        /// Diễn giải
        /// </summary>
        public string  Description { get; set; }
        /// <summary>
        /// Ngày tạo bản ghi
        /// </summary>
        public DateTime CreateDate { get; set; }
        /// <summary>
        /// Người tạo
        /// </summary>
        public string CreateBy { get; set; }
        /// <summary>
        /// Ngày chỉnh sửa gần nhất
        /// </summary>
        public DateTime ModifiedDate { get; set; }
        /// <summary>
        /// Người chỉnh sửa gần nhất
        /// </summary>
        public string ModifiedBy { get; set; }

    }
}
