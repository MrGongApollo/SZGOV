using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace LayUI.Win.Models
{
    #region 公共返回类型
    public class JsonRetModel
    {
        /// <summary>
        /// 返回类型
        /// </summary>
        public bool Ret { get; set; }
        /// <summary>
        /// 返回消息
        /// </summary>
        public string Msg { get; set; }

        /// <summary>
        /// 返回的数据
        /// </summary>
        public object Data { get; set; }
    }
    #endregion

    #region Excel导入导出
    public class CM_Excel_Model
    {
        public string ClassName { get; set; }
        public string paras { get; set; }
        /// <summary>
        /// 方法：（Imort、Export）
        /// </summary>
        public string Methed { get; set; }
    }

    #endregion 
}