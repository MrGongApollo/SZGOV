using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LayUI.Data.EntityModel
{
	/// <summary>
    /// 
    /// </summary>
	[Table("T_XT_Doc")]
    public partial class T_XT_Doc_Entity : IEntity, ICreationAudited, IModificationAudited, IDeleteAudited
	{
		#region 数据库属性字段
		
        /// <summary>
        /// 文件存储编号
        /// </summary>
        public string StoreDirectoryId { get; set; }
        
        /// <summary>
        /// 主键
        /// </summary>
		[Key]
        public string DocId { get; set; }
        
        /// <summary>
        /// 文件名称
        /// </summary>
        public string DocName { get; set; }
        
        /// <summary>
        /// 文件类型
        /// </summary>
        public string DocType { get; set; }
        
        /// <summary>
        /// 文件大小
        /// </summary>
        public decimal? DocSize { get; set; }
        
        /// <summary>
        /// 子目录名称(按年月命名)
        /// </summary>
        public string SubDirectory { get; set; }
        
        /// <summary>
        /// 内部名称(转换后的GUID名称)
        /// </summary>
        public string InternalName { get; set; }
        
        /// <summary>
        /// 下载次数
        /// </summary>
        public decimal? DownloadCount { get; set; }
        
        /// <summary>
        /// 来自模块
        /// </summary>
        public string FromModuleName { get; set; }
        
        /// <summary>
        /// 来源表名
        /// </summary>
        public string FromTableName { get; set; }
        
        /// <summary>
        /// 关联主键
        /// </summary>
        public string RelevanceId { get; set; }
        
        /// <summary>
        /// 扩展字段
        /// </summary>
        public string ExpandOne { get; set; }
        
        /// <summary>
        /// 扩展字段
        /// </summary>
        public string ExpandTwo { get; set; }
        
        /// <summary>
        /// 扩展字段
        /// </summary>
        public string ExpandThree { get; set; }
        
        /// <summary>
        /// 扩展字段
        /// </summary>
        public string ExpandFour { get; set; }
        
        /// <summary>
        /// 扩展字段
        /// </summary>
        public string ExpandFive { get; set; }
        
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
