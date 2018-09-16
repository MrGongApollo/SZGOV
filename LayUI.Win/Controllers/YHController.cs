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
    public class YHController : BaseController
    {
        #region 隐患汇总视图
        public ActionResult YHSumList()
        {
            return View();
        }
        #endregion

        #region 隐患记录视图
        public ActionResult YHList()
        {
            return View();
        }
        #endregion

        #region 隐患登记详情视图
        public ActionResult YHEdit()
        {
            return View();
        }
        #endregion

        #region 新增隐患
        /// <summary>
        /// 新增隐患
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public JsonResult HiddenDangerAdd(T_YH_HiddenDanger_Entity saveData)
        {
            JsonRetModel Ret = new JsonRetModel { Ret = false };
            #region 验证
            try
            {
                using (TeamWorkDbContext et = new TeamWorkDbContext())
                {

                    T_YH_HiddenDanger_Entity _u = et.T_YH_HiddenDanger_Entity.Find(saveData.HiddenDangerID);
                    if (_u != null)
                    {
                        _u = saveData;
                    }
                    else 
                    {
                        saveData.HiddenDangerID = System.Guid.NewGuid().ToString("N");
                        _u = et.T_YH_HiddenDanger_Entity.Add(saveData);
                    }
                    et.SaveChanges();
                    Ret.Data = saveData.HiddenDangerID;
                    Ret.Msg = "保存成功";
                    Ret.Ret = true;
                   
                }
            }
            #endregion
            #region 异常
            catch (Exception ex)
            {
                Ret.Ret = false;
                Ret.Msg = ex.Message;
            }
            #endregion
            return Json(Ret, JsonRequestBehavior.AllowGet);
        }
        #endregion
    }
}