using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LayUI.Data.EntityModel
{
	/// <summary>
    /// 
    /// </summary>
	[Table("T_YH_Records")]
    public partial class T_YH_Records_Entity : IEntity, ICreationAudited, IModificationAudited, IDeleteAudited
	{
		#region 数据库属性字段
		
        /// <summary>
        /// 
        /// </summary>
		[Key]
        public string RecordId { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public string EmpCode { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public string EmpName { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public DateTime? WorkTime { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public string Detail { get; set; }
        
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
        public bool? IsDeleted { get; set; }
         
		#endregion
	}
}
