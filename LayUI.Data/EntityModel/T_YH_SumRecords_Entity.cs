using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LayUI.Data.EntityModel
{
	/// <summary>
    /// 
    /// </summary>
	[Table("T_YH_SumRecords")]
    public partial class T_YH_SumRecords_Entity : IEntity, ICreationAudited, IModificationAudited, IDeleteAudited
	{
		#region 数据库属性字段
		
        /// <summary>
        /// 
        /// </summary>
		[Key]
        public string YHSumId { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public string OrgCode { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public string MonthDate { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public decimal? CommonlyCnt { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public decimal? MajorCnt { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public decimal? CheckedCnt { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public decimal? CorrectCnt { get; set; }
        
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
