using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Exam.Data.EntityModel
{
	/// <summary>
    /// 用户信息
    /// </summary>
    public partial class ESysUserEntity 
	{
        ///// <summary>
        ///// 系统分组信息
        ///// </summary>
        //[ForeignKey("E_OrganizeID")]
        //public virtual ESysOrganizeEntity ESysOrganizeEntity { get; set; }
    }
}
