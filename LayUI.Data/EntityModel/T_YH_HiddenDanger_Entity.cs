using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LayUI.Data.EntityModel
{
	/// <summary>
    /// 
    /// </summary>
	[Table("T_YH_HiddenDanger")]
    public partial class T_YH_HiddenDanger_Entity : IEntity, ICreationAudited, IModificationAudited, IDeleteAudited
	{
		#region 数据库属性字段
		
        /// <summary>
        /// 隐患主键
        /// </summary>
		[Key]
        public string HiddenDangerId { get; set; }
        
        /// <summary>
        /// 隐患编号
        /// </summary>
        public decimal SerialNo { get; set; }
        
        /// <summary>
        /// 隐患机构码
        /// </summary>
        public string OrgCode { get; set; }
        
        /// <summary>
        /// 隐患机构名称
        /// </summary>
        public string OrgName { get; set; }
        
        /// <summary>
        /// 隐患部位
        /// </summary>
        public string HiddenPart { get; set; }
        
        /// <summary>
        /// 检查时间
        /// </summary>
        public DateTime? CheckTime { get; set; }
        
        /// <summary>
        /// 检查人员工号
        /// </summary>
        public string CheckEmpCode { get; set; }
        
        /// <summary>
        /// 检查人员姓名
        /// </summary>
        public string CheckEmpName { get; set; }
        
        /// <summary>
        /// 隐患大类
        /// </summary>
        public string HiddenTypeL { get; set; }
        
        /// <summary>
        /// 隐患小类
        /// </summary>
        public string HiddenTypeS { get; set; }
        
        /// <summary>
        /// 隐患级别
        /// </summary>
        public string HiddenLevel { get; set; }
        
        /// <summary>
        /// 隐患内容
        /// </summary>
        public string HiddenContent { get; set; }
        
        /// <summary>
        /// 整改责任部门机构码
        /// </summary>
        public string ResponseOrgCode { get; set; }
        
        /// <summary>
        /// 整改责任部门机构名称
        /// </summary>
        public string ResponseOrgName { get; set; }
        
        /// <summary>
        /// 整改期限
        /// </summary>
        public DateTime? TimeLimit { get; set; }
        
        /// <summary>
        /// 整改责任人工号
        /// </summary>
        public string ResponseEmpCode { get; set; }
        
        /// <summary>
        /// 整改责任人姓名
        /// </summary>
        public string ResponseEmpName { get; set; }
        
        /// <summary>
        /// 整改责任人电话
        /// </summary>
        public string ResponseNumer { get; set; }
        
        /// <summary>
        /// 整改措施
        /// </summary>
        public string Measure { get; set; }
        
        /// <summary>
        /// 整改结果
        /// </summary>
        public string Result { get; set; }
        
        /// <summary>
        /// 完成日期
        /// </summary>
        public DateTime? CompleteTime { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public string ValidateEmpName { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public string ValidateOrg { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public DateTime? ValidateDate { get; set; }
        
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
