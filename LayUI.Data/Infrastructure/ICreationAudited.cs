using System;

namespace LayUI.Data
{
    public interface ICreationAudited
    {
        /// <summary>
        /// 创建用户工号
        /// </summary>
        string CreateByEmpCode { get; set; }

        /// <summary>
        /// 创建用户姓名
        /// </summary>
        string CreateByEmpName { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        DateTime? CreateTime { get; set; }


    }
}