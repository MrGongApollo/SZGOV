using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LayUI.Data.EntityModel
{
	/// <summary>
    /// 
    /// </summary>
	[Table("T_WH_MajorHazardDossier")]
    public partial class T_WH_MajorHazardDossier_Entity : IEntity, ICreationAudited, IModificationAudited, IDeleteAudited
	{
		#region 数据库属性字段
		
        /// <summary>
        /// 主键
        /// </summary>
		[Key]
        public string DossierId { get; set; }
        
        /// <summary>
        /// 单位码
        /// </summary>
        public string OrgCode { get; set; }
        
        /// <summary>
        /// 单位名称
        /// </summary>
        public string OrgName { get; set; }
        
        /// <summary>
        /// 所在地址
        /// </summary>
        public string Address { get; set; }
        
        /// <summary>
        /// 主要负责人工号
        /// </summary>
        public string ResponseEmpCode { get; set; }
        
        /// <summary>
        /// 主要负责人姓名
        /// </summary>
        public string ResponseEmpName { get; set; }
        
        /// <summary>
        /// 联系电话
        /// </summary>
        public string ContactNum { get; set; }
        
        /// <summary>
        /// 政府备案部门
        /// </summary>
        public string RecordOrgName { get; set; }
        
        /// <summary>
        /// 最近评估日期
        /// </summary>
        public DateTime? EvaluationTime { get; set; }
        
        /// <summary>
        /// 评估机构
        /// </summary>
        public string EvaluationOrg { get; set; }
        
        /// <summary>
        /// 危险等级
        /// </summary>
        public string MajorHazardLevel { get; set; }
        
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
