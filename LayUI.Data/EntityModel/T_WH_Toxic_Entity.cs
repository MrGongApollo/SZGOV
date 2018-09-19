using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LayUI.Data.EntityModel
{
	/// <summary>
    /// 
    /// </summary>
	[Table("T_WH_Toxic")]
    public partial class T_WH_Toxic_Entity : IEntity, ICreationAudited, IModificationAudited, IDeleteAudited
	{
		#region 数据库属性字段
		
        /// <summary>
        /// 主键
        /// </summary>
		[Key]
        public string ToxicId { get; set; }
        
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
        /// 化学品名称
        /// </summary>
        public string ToxicName { get; set; }
        
        /// <summary>
        /// 用途
        /// </summary>
        public string Useage { get; set; }
        
        /// <summary>
        /// 当月进货量
   
        /// </summary>
        public decimal? StorageCurMonth { get; set; }
        
        /// <summary>
        /// 当月使用量
   
        /// </summary>
        public decimal? StorageOutCurMonth { get; set; }
        
        /// <summary>
        /// 现库存量
        /// </summary>
        public decimal? StockCur { get; set; }
        
        /// <summary>
        /// 存放点
        /// </summary>
        public string StoragePoint { get; set; }
        
        /// <summary>
        /// 保管员
        /// </summary>
        public string StoreMan { get; set; }
        
        /// <summary>
        /// 保管员号码
        /// </summary>
        public string StoreManNumber { get; set; }
        
        /// <summary>
        /// 责任人工号
        /// </summary>
        public string ResponseEmpCode { get; set; }
        
        /// <summary>
        /// 责任人姓名
        /// </summary>
        public string ResponseEmpName { get; set; }
        
        /// <summary>
        /// 责任人号码
        /// </summary>
        public string ResponseNumber { get; set; }
        
        /// <summary>
        /// 使用单位码
        /// </summary>
        public string UseOrgCode { get; set; }
        
        /// <summary>
        /// 使用单位名称
        /// </summary>
        public string UseOrgName { get; set; }
        
        /// <summary>
        /// 从业人员是否变化
        /// </summary>
        public string IsPersonChange { get; set; }
        
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
