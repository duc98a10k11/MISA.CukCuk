using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.ApplicationCore.Entities
{

    /// <summary>
    /// Thông tin khách hàng
    /// </summary>
    /// CreatedBy: LMDuc (20/04/2021)
    public class Customer
    {
        /// <summary>
        /// Khóa chính
        /// </summary>
        public Guid CustomerId { get; set; }

        /// <summary>
        /// Mã khách hàng
        /// </summary>
        public String CustomerCode { get; set; }

        /// <summary>
        /// Họ và tên
        /// </summary>
        public String FullName { get; set; }

        /// <summary>
        /// Giới tính
        /// </summary>
        public int Gender { get; set; }

        /// <summary>
        /// Mã thẻ thành viên
        /// </summary>
        public String MemberCardCode { get; set; }

        /// <summary>
        /// Mã nhóm khách hàng
        /// </summary>
        public Guid? CustomerGroupId { get; set; }

        /// <summary>
        /// Số điện thoại
        /// </summary>
        public String PhoneNumber { get; set; }

        /// <summary>
        /// Ngày sinh
        /// </summary>
        public DateTime DateOfBirth { get; set; }

        /// <summary>
        /// Tên công ty
        /// </summary>
        public String CompanyName { get; set; }

        /// <summary>
        /// Mã số thuế công ty
        /// </summary>
        public String CompanyTaxCode { get; set; }

        /// <summary>
        /// Email
        /// </summary>
        public String Email { get; set; }

        /// <summary>
        /// Địa chỉ
        /// </summary>
        public String Address { get; set; }

        /// <summary>
        /// Ghi chú
        /// </summary>
        public String Note { get; set; }

        /// <summary>
        /// Ngày tạo
        /// </summary>
        //public String CreatedDate { get; set; }

        /// <summary>
        /// Người tạo
        /// </summary>
        public String CreatedBy { get; set; }

        /// <summary>
        /// Ngày sửa đổi
        /// </summary>
        //public String ModifiedDate { get; set; }

        /// <summary>
        /// Người sửa đổi
        /// </summary>
        public String ModifiedBy { get; set; }
    }
}
