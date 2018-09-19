using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LayUI.Data.EntityModel
{
	/// <summary>
    /// 
    /// </summary>
	[Table("T_WH_Isotope")]
    public partial class T_WH_Isotope_Entity : IEntity, ICreationAudited, IModificationAudited, IDeleteAudited
	{
		#region 数据库属性字段
		
        /// <summary>
        /// 主键
        /// </summary>
		[Key]
        public string IsotopeId { get; set; }
        
        /// <summary>
        /// 年
        /// </summary>
        public decimal? Year { get; set; }
        
        /// <summary>
        /// 月
        /// </summary>
        public decimal? Month { get; set; }
        
        /// <summary>
        /// 申报单位码
        /// </summary>
        public string ApplyOrgCode { get; set; }
        
        /// <summary>
        /// 申报单位名称
        /// </summary>
        public string ApplyOrgName { get; set; }
        
        /// <summary>
        /// 核素名称
        /// </summary>
        public string IsotopeName { get; set; }
        
        /// <summary>
        /// 上月库存量
        /// </summary>
        public decimal? StockLastMonth { get; set; }
        
        /// <summary>
        /// 本月入库量
        /// </summary>
        public decimal? StorageCurMonth { get; set; }
        
        /// <summary>
        /// 本月出库量
        /// </summary>
        public decimal? StorageOutCurMonth { get; set; }
        
        /// <summary>
        /// 本月库存量
        /// </summary>
        public decimal? StockCurMonth { get; set; }
        
        /// <summary>
        /// 存放点
        /// </summary>
        public string StoragePoint { get; set; }
        
        /// <summary>
        /// 保管员
        /// </summary>
        public string StoreMan { get; set; }
        
        /// <summary>
        /// 联系号码
        /// </summary>
        public string ContactNumber { get; set; }
        
        /// <summary>
        /// 从业人员是否变化
        /// </summary>
        public string IsPersonChange { get; set; }
        
        /// <summary>
        /// 检查人
        /// </summary>
        public string CheckEmpName { get; set; }
        
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
