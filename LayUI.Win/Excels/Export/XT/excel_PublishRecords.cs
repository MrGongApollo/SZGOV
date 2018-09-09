using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LayUI.Data;
using LayUI.Data.EntityModel;
using LayUI.Win.Models;

namespace LayUI.Win.Excels.Export.XT
{
    public class excel_PublishRecords:BaseExport
    {
        public override JsonRetModel ExportExcel(string paras)
        {
            JsonRetModel Ret = new JsonRetModel();
            string strPath = string.Format("发布记录{0:yyyyMMddHHmmss}",DateTime.Now);
            #region 
            try
            {
                using (TeamWorkDbContext et=new TeamWorkDbContext())
                {
                   //var list=et.T_XT_PublishRecords_Entity.Where(k => true).ToList();
                }
            }
            catch (Exception ex)
            {
                
            }
            #endregion
            return Ret;
        }
    }
}