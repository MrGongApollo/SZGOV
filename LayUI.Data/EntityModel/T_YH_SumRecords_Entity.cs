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
        /// 隐患主键
        /// </summary>
		[Key]
        public string YHSumId { get; set; }
        
        /// <summary>
        /// 隐患机构码
        /// </summary>
        public string OrgCode { get; set; }
        
        /// <summary>
        /// 隐患机构名称
        /// </summary>
        public string OrgName { get; set; }
        
        /// <summary>
        /// 年月
        /// </summary>
        public string MonthDate { get; set; }
        
        /// <summary>
        /// 一般隐患
        /// </summary>
        public decimal? CommonlyCnt { get; set; }
        
        /// <summary>
        /// 监管部门查处
        /// </summary>
        public decimal? CheckedCnt { get; set; }
        
        /// <summary>
        /// 重大隐患
        /// </summary>
        public decimal? MajorCnt { get; set; }
        
        /// <summary>
        /// 已整改数
        /// </summary>
        public decimal? CorrectCnt { get; set; }
        
        /// <summary>
        /// 按期整改数
        /// </summary>
        public decimal? ScheduleCnt { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public decimal? TotalCnt { get; set; }
        
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
        /// 上报标志(0：未上报;1：已上报)
        /// </summary>
        public bool? IsSub { get; set; }
        
        /// <summary>
        /// 删除标志(0：未删除;1：已删除)
        /// </summary>
        public bool? IsDeleted { get; set; }
         
		#endregion
	}
}
