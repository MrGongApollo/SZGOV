using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LayUI.Data.EntityModel
{
	/// <summary>
    /// 
    /// </summary>
	[Table("T_WH_DangerChemPro")]
    public partial class T_WH_DangerChemPro_Entity : IEntity, ICreationAudited, IModificationAudited, IDeleteAudited
	{
		#region 数据库属性字段
		
        /// <summary>
        /// 主键
        /// </summary>
		[Key]
        public string DangerChemId { get; set; }
        
        /// <summary>
        /// 单位码
        /// </summary>
        public string OrgCode { get; set; }
        
        /// <summary>
        /// 单位名称
        /// </summary>
        public string OrgName { get; set; }
        
        /// <summary>
        /// 危险化学品名称
        /// </summary>
        public string ToxicName { get; set; }
        
        /// <summary>
        /// 危规号
        /// </summary>
        public string DangerChemCode { get; set; }
        
        /// <summary>
        /// 年产量
        /// </summary>
        public decimal? YearYield { get; set; }
        
        /// <summary>
        /// 年销售量
        /// </summary>
        public decimal? YearSales { get; set; }
        
        /// <summary>
        /// 最大储存量
        /// </summary>
        public decimal? StockMax { get; set; }
        
        /// <summary>
        /// 贮存地点
        /// </summary>
        public string StoragePoint { get; set; }
        
        /// <summary>
        /// 包装方式
        /// </summary>
        public string PackWay { get; set; }
        
        /// <summary>
        /// 安全许可证
        /// </summary>
        public string SecurityLicense { get; set; }
        
        /// <summary>
        /// 销售许可证
        /// </summary>
        public string SaleLicense { get; set; }
        
        /// <summary>
        /// 是否重点监管化学品
        /// </summary>
        public string IsKeySupervise { get; set; }
        
        /// <summary>
        /// 是否易制毒化学品
        /// </summary>
        public string IsEasyDrugPro { get; set; }
        
        /// <summary>
        /// 是否易制爆化学品
        /// </summary>
        public string IsEasybBastPro { get; set; }
        
        /// <summary>
        /// 是否剧毒化学品
        /// </summary>
        public string IsHighlyToxic { get; set; }
        
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
