using System;

namespace LayUI.Data
{
    public interface IModificationAudited
    {
        /// <summary>
        ///修改用户工号
        /// </summary>
        string ModifyEmpCode { get; set; }

        /// <summary>
        /// 修改用户姓名
        /// </summary>
        string ModifyEmpName { get; set; }

        /// <summary>
        /// 修改时间
        /// </summary>
        DateTime? ModifyTime { get; set; }
    }
}