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
using System.Data.Entity;

namespace LayUI.Win.Controllers
{
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

                    T_YH_HiddenDanger_Entity u = et.T_YH_HiddenDanger_Entity.Find(saveData.HiddenDangerID);
                    if (u != null)
                    {
                        CommonHelper.RemoveHoldingEntityInContext<T_YH_HiddenDanger_Entity>(u, et);
                        u = saveData;
                        et.Entry<T_YH_HiddenDanger_Entity>(u).State = System.Data.Entity.EntityState.Modified;
                    }
                    else 
                    {
                        saveData.HiddenDangerID = System.Guid.NewGuid().ToString("N");
                        u = et.T_YH_HiddenDanger_Entity.Add(saveData);
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

        #region 查询列表
        /// <summary>
        /// 查询列表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult getHiddenDangerLsit(int page, int limit)
        {
            Dictionary<String, Object> Ret = new Dictionary<String, Object>();
            #region 验证
            try
            {
                TeamWorkDbContext et = new TeamWorkDbContext();

                //var list = et.T_YH_HiddenDanger_Entity.OrderBy(u => u.SerialNo).Skip((page - 1) * limit).Take(limit);
                var list = et.T_YH_HiddenDanger_Entity; 
                int total = et.T_YH_HiddenDanger_Entity.Count<T_YH_HiddenDanger_Entity>();
                var dic = new Dictionary<string, object>
                {
                    {"data",list },
                    {"count", total},
                    {"msg","查询成功" },
                    {"code", 0}
                };
                return Json(dic, JsonRequestBehavior.AllowGet);

                
            }
            #endregion
            #region 异常
            catch (Exception ex)
            {
                var dic = new Dictionary<string, object>
                    {
                    {"msg",ex.Message },
                    {"code", 1}
                    };
                return Json(dic, JsonRequestBehavior.AllowGet);
            }
            #endregion
            finally{
               
            }
        }
        #endregion
    }
}