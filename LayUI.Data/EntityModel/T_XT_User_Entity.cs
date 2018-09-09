using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LayUI.Data.EntityModel
{
	/// <summary>
    /// 
    /// </summary>
	[Table("T_XT_User")]
    public partial class T_XT_User_Entity : IEntity, ICreationAudited, IModificationAudited, IDeleteAudited
	{
		#region 数据库属性字段
		
        /// <summary>
        /// 工号
        /// </summary>
		[Key]
        public string EmpCode { get; set; }
        
        /// <summary>
        /// 姓名
        /// </summary>
        public string EmpName { get; set; }
        
        /// <summary>
        /// 性别 [true:男，false:女]
        /// </summary>
        public bool? Sex { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public DateTime? Birthday { get; set; }
        
        /// <summary>
        /// 工作状态 [-1:离职,1:在职]
        /// </summary>
        public string WorkStatus { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public string LoginPassword { get; set; }
        
        /// <summary>
        /// 最后登录日期
        /// </summary>
        public DateTime? TheLoginTime { get; set; }
        
        /// <summary>
        /// 上次登录日期
        /// </summary>
        public DateTime? LastLoginTime { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public DateTime? CreateTime { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public string CreateByEmpCode { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public string CreateByEmpName { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public DateTime? ModifyTime { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public string ModifyEmpCode { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public string ModifyEmpName { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public string PhoneNum { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public string Email { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public bool? IsDeleted { get; set; }
         
		#endregion
	}
}
