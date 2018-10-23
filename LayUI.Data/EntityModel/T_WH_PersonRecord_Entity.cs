using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LayUI.Data.EntityModel
{
	/// <summary>
    /// 
    /// </summary>
	[Table("T_WH_PersonRecord")]
    public partial class T_WH_PersonRecord_Entity : IEntity, ICreationAudited, IModificationAudited, IDeleteAudited
	{
		#region 数据库属性字段
		
        /// <summary>
        /// 主键
        /// </summary>
		[Key]
        public string RecordId { get; set; }
        
        /// <summary>
        /// 单位码
        /// </summary>
        public string OrgCode { get; set; }
        
        /// <summary>
        /// 单位名称
        /// </summary>
        public string OrgName { get; set; }
        
        /// <summary>
        /// 岗位
        /// </summary>
        public string Post { get; set; }
        
        /// <summary>
        /// 工号
        /// </summary>
        public string EmpCode { get; set; }
        
        /// <summary>
        /// 姓名
        /// </summary>
        public string EmpName { get; set; }
        
        /// <summary>
        /// 身份证
        /// </summary>
        public string IdcardNo { get; set; }
        
        /// <summary>
        /// 联系号码
        /// </summary>
        public string ContactNum { get; set; }
        
        /// <summary>
        /// 户籍地址
        /// </summary>
        public string PermanentAddress { get; set; }
        
        /// <summary>
        /// 现居住地地址
        /// </summary>
        public string CurAddress { get; set; }
        
        /// <summary>
        /// 持有证件
        /// </summary>
        public string Certificates { get; set; }
        
        /// <summary>
        /// 创建人工号
        /// </summary>
        public string CreateByEmpCode { get; set; }
        
        /// <summary>
        /// 创建人姓名
        /// </summary>
        public string CreateByEmpName { get; set; }
        
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? CreateTime { get; set; }
        
        /// <summary>
        /// 修改人工号
        /// </summary>
        public string ModifyEmpCode { get; set; }
        
        /// <summary>
        /// 修改人姓名
        /// </summary>
        public string ModifyEmpName { get; set; }
        
        /// <summary>
        /// 修改时间
        /// </summary>
        public DateTime? ModifyTime { get; set; }
        
        /// <summary>
        /// 删除标志(0：未删除;1：已删除)
        /// </summary>
        public bool? IsDeleted { get; set; }
         
		#endregion
	}
}
