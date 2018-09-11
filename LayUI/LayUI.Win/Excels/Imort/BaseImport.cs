using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using NPOI.SS.UserModel;
using System.IO;
using NPOI.XSSF.UserModel;
using NPOI.HSSF.UserModel;
using LayUI.Data;
using LayUI.Data.EntityModel;
using LayUI.Win.Models;

namespace LayUI.Win.Excels.Imort
{
    public class BaseImport
    {
        public virtual JsonRetModel ImportExcel(string paras) 
        {
            JsonRetModel ret = new JsonRetModel();
            return ret;
        }

        #region 模板版本号
        /// <summary>
        /// 获取Excel模板版本号
        /// </summary>
        /// <param name="dataId"></param>
        /// <returns></returns>
        public string getExcelVersion(string dataId) 
        {
            string ret = "";
            try
            {
                using (TeamWorkDbContext et = new TeamWorkDbContext())
                {
                    T_XT_Data_Entity _data = et.T_XT_Data_Entity.FirstOrDefault(k => k.DataId == dataId);
                    if (_data != null)
                    {
                        ret = _data.DataName;
                    }
                }
            }
            catch (Exception)
            {
                
            }
            return ret;
        }
        #endregion

    }
}