using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.CukCuk.Core.AttributeCustom
{
    /// <summary>
    /// Validate chuỗi rỗng
    /// </summary>
    /// CreatedBy: LMDuc (29/04/2021)
    [AttributeUsage(AttributeTargets.Property)]
    public class MISARequired: Attribute
    {
        /// <summary>
        /// câu thông báo lỗi
        /// </summary>
        public string MsgError = string.Empty;
        public MISARequired(string msgError ="")
        {
            MsgError = msgError;
        }
    }

    /// <summary>
    /// validate độ dài tối đa của trường nhập
    /// </summary>
    /// CreatedBy: LMDuc (29/04/2021)
    [AttributeUsage(AttributeTargets.Property)]
    public class MISAMaxLength : Attribute
    {
        /// <summary>
        /// Độ dài tối đa của chuỗi
        /// </summary>
        public int MaxLength = 0;

        /// <summary>
        /// Câu thông báo lỗi
        /// </summary>
        public string MsgError = string.Empty;
        public MISAMaxLength(int maxLength = 0, string msg = "")
        {
            MaxLength = maxLength;
            MsgError = msg;
        }
    }
}
