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

namespace LayUI.Win.Excels.Export
{
    public class BaseExport
    {
        public virtual JsonRetModel ExportExcel(string paras) 
        {
            JsonRetModel ret = new JsonRetModel();
            return ret;
        }
    }
}