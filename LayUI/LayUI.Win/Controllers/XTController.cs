using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LayUI.Win.Help;
using LayUI.Data;
using LayUI.Data.EntityModel;
using LayUI.Win.Models;
using LayUI.Utility.Helper;
using System.Data;

namespace LayUI.Win.Controllers
{
    [LoginChecked]
    public class XTController : BaseController
    {

        #region 前台公共方法

        #region 获取当前用户
        /// <summary>
        /// 获取当前用户
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public JsonResult getCurentUserInfo()
        {
            T_XT_User_Entity U = getCurUser();
            return Json(new 
            {
                EmpCode = U.EmpCode,
                EmpName=U.EmpName,
                Birthday = U.Birthday,
                Sex = U.Sex,
                PhoneNum = U.PhoneNum,
                TheLoginTime = U.TheLoginTime
            }, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region 获取GUID
        /// <summary>
        /// GUID
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public JsonResult getGUID() 
        {
            return Json(Guid.NewGuid().ToString("N"),JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region 公共导入导出入口

        #region 导入
        /// <summary>
        /// 导入
        /// </summary>
        /// <param name="exl"></param>
        /// <returns></returns>
        [HttpGet]
        public JsonRetModel CM_ExcelImport(CM_Excel_Model exl) {
            exl.Methed = "Imort";
            return CM_ExcelOperate(exl);
        }
        #endregion

        #region 导出
        /// <summary>
        /// 导入
        /// </summary>
        /// <param name="exl"></param>
        /// <returns></returns>
        [HttpGet]
        public JsonRetModel CM_ExcelExport(CM_Excel_Model exl)
        {
            exl.Methed = "Export";
            return CM_ExcelOperate(exl);
        }
        #endregion

        #region 导入导出
        private JsonRetModel CM_ExcelOperate(CM_Excel_Model exl)
        {
            JsonRetModel ret = new JsonRetModel { Ret = false };
            try
            {
                if (exl != null)
                {
                    Type type = Type.GetType(string.Format("LayUI.Win.Excels.{0}.{1}", exl.Methed, exl.ClassName));
                    object obj = Activator.CreateInstance(type);
                    switch (exl.Methed)
                    {
                        case "Imort":
                            ret = (obj as LayUI.Win.Excels.Imort.BaseImport).ImportExcel(exl.paras);
                            break;
                        case "Export":
                            ret = (obj as LayUI.Win.Excels.Export.BaseExport).ExportExcel(exl.paras);
                            break;
                        default:
                            break;
                    }

                }
            }
            catch (Exception ex)
            {
                ret.Data = ex.Message;
            }

            return ret;
        }
        #endregion

        #endregion

        #endregion
    }
}