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
using System.Configuration;

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

        #region 隐患汇总查看明细视图
        public ActionResult YHSumViewList()
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

        #region 更新隐患汇总
         /// <summary>
        /// 更新隐患汇总
         /// </summary>
        /// <param name="yhId"></param>
         /// <returns></returns>
        [HttpPost]
        public void YHSumUpdate(string yhId)
        {
            //JsonRetModel Ret = new JsonRetModel { Ret = false };
            #region 验证
            try
            {
                using (TeamWorkDbContext et = new TeamWorkDbContext())
                {
                    T_YH_HiddenDanger_Entity yh = et.T_YH_HiddenDanger_Entity.FirstOrDefault(k=>k.HiddenDangerId==yhId);
                    if (yh != null)
                    {
                        string ym=yh.CheckTime.Value.ToString("yyyyMM");
                        T_YH_SumRecords_Entity sum = et.T_YH_SumRecords_Entity.FirstOrDefault(k => k.MonthDate == ym);
                        if (sum != null)
                        {
                           DateTime _monthFirst = Convert.ToDateTime(yh.CheckTime.Value.ToString("yyyy-MM") + "-01"),_nextFirst = _monthFirst.AddMonths(1);
                           var _list = et.T_YH_HiddenDanger_Entity.Where(k => k.CheckTime >= _monthFirst && k.CheckTime < _nextFirst && k.IsDeleted == false && k.OrgCode == yh.OrgCode);
                           sum.CommonlyCnt = _list.Where(k=>k.HiddenLevel=="一般隐患").Count();
                           sum.MajorCnt = _list.Where(k => k.HiddenLevel == "重大隐患").Count();
                           sum.CorrectCnt = _list.Where(k => k.Result == "已整改").Count();
                           sum.ScheduleCnt = _list.Where(k => k.CompleteTime<=k.TimeLimit).Count();
                           sum.TotalCnt = _list.Count();
                           et.SaveChanges();
                        }                        
                    }
                    
                }
            }
            #endregion
            #region 异常
            catch (Exception ex)
            {
            }
            #endregion
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