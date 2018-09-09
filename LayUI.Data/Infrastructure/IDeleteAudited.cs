using System;

namespace LayUI.Data
{
    public interface IDeleteAudited 
    {
        /// <summary>
        /// 删除用户工号
        /// </summary>
        string ModifyEmpCode { get; set; }

        /// <summary>
        /// 删除用户姓名
        /// </summary>
        string ModifyEmpName { get; set; }

        /// <summary>
        /// 删除时间
        /// </summary>
        DateTime? ModifyTime { get; set; }

        /// <summary>
        /// 是否删除
        /// </summary>
        bool? IsDeleted { get; set; }
    }
}