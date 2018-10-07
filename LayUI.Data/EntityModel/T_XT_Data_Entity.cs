using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LayUI.Data.EntityModel
{
	/// <summary>
    /// 
    /// </summary>
	[Table("T_XT_Data")]
    public partial class T_XT_Data_Entity : IEntity, ICreationAudited, IModificationAudited, IDeleteAudited
	{
		#region 数据库属性字段
		
        /// <summary>
        /// 主键编号
        /// </summary>
		[Key]
        public string DataId { get; set; }
        
        /// <summary>
        /// 所属机构代码
        /// </summary>
        public string OrgCode { get; set; }
        
        /// <summary>
        /// 所属机构代码
        /// </summary>
        public string OrgName { get; set; }
        
        /// <summary>
        /// 父节点编号
        /// </summary>
        public string ParentId { get; set; }
        
        /// <summary>
        /// 父节点名称
        /// </summary>
        public string ParentName { get; set; }
        
        /// <summary>
        /// 节点自定义编号
        /// </summary>
        public string DataCode { get; set; }
        
        /// <summary>
        /// 节点名称
        /// </summary>
        public string DataName { get; set; }
        
        /// <summary>
        /// 节点值
        /// </summary>
        public string DataValue { get; set; }
        
        /// <summary>
        /// 所属组别/来源
        /// </summary>
        public string DataGroup { get; set; }
        
        /// <summary>
        /// 排序
        /// </summary>
        public decimal? SortIndex { get; set; }
        
        /// <summary>
        /// 子节点个数
        /// </summary>
        public decimal? SubItemAmount { get; set; }
        
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }
        
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
