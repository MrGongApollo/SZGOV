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
        /// 
        /// </summary>
		[Key]
        public string DataId { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public string DataCode { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public string DataName { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public string DataValue { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public string DataType { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public string DataGroup { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public string ParentId { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public int? SortIndex { get; set; }
        
        /// <summary>
        /// 包含子项数量
        /// </summary>
        public decimal? SubItemAmount { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public string Remark { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public string ModuleName { get; set; }
        
        /// <summary>
        /// 创建人员
        /// </summary>
        public string CreateByEmpCode { get; set; }
        
        /// <summary>
        /// 创建人员
        /// </summary>
        public string CreateByEmpName { get; set; }
        
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? CreateTime { get; set; }
        
        /// <summary>
        /// 修改时间
        /// </summary>
        public string ModifyEmpCode { get; set; }
        
        /// <summary>
        /// 修改时间
        /// </summary>
        public string ModifyEmpName { get; set; }
        
        /// <summary>
        /// 修改时间
        /// </summary>
        public DateTime? ModifyTime { get; set; }
        
        /// <summary>
        /// 修改时间
        /// </summary>
        public bool? IsDeleted { get; set; }
         
		#endregion
	}
}
