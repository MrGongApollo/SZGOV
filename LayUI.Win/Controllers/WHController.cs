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
    public class WHController : BaseController
    {
        #region 默认视图
        public ActionResult WHIndex()
        {
            return View();
        }
        #endregion

        #region 危化品生产列表视图
        public ActionResult WHSCList()
        {
            return View();
        }

        public ActionResult WHSCEdit()
        {
            return View();
        }
        #endregion

        #region 危化品使用列表视图
        public ActionResult WHSYList()
        {
            return View();
        }

        public ActionResult WHSYEdit()
        {
            return View();
        }
        #endregion

        #region 重大危险源备案
        public ActionResult ZDWXList()
        {
            return View();
        }

        public ActionResult ZDWXEdit()
        {
            return View();
        }
        #endregion

        #region 剧毒化学品月度申报
        public ActionResult JDList()
        {
            return View();
        }

        public ActionResult JDEdit()
        {
            return View();
        }
        #endregion

        #region 同位素放射源备案
        public ActionResult TWSList()
        {
            return View();
        }

        public ActionResult TWSEdit()
        {
            return View();
        }
        #endregion

        #region 危化品/剧毒品/同位素从业人员备案
        public ActionResult WHRYList()
        {
            return View();
        }

        public ActionResult WHRYEdit()
        {
            return View();
        }
        #endregion

        #region 监测管理
        public ActionResult WHJCList()
        {
            return View();
        }
        #endregion

        #region 监测管理
        public ActionResult SafeEvaluationList()
        {
            return View();
        }
        #endregion

        #region 新增剧毒品
        /// <summary>
        /// 新增剧毒品
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public JsonResult ToxicAdd(T_WH_Toxic_Entity saveData)
        {
            JsonRetModel Ret = new JsonRetModel { Ret = false };
            #region 验证
            try
            {
                using (TeamWorkDbContext et = new TeamWorkDbContext())
                {

                    T_WH_Toxic_Entity u = et.T_WH_Toxic_Entity.Find(saveData.ToxicId);
                    if (u != null)
                    {
                        CommonHelper.RemoveHoldingEntityInContext<T_WH_Toxic_Entity>(u, et);
                        u = saveData;
                        et.Entry<T_WH_Toxic_Entity>(u).State = System.Data.Entity.EntityState.Modified;
                    }
                    else
                    {
                        saveData.ToxicId = System.Guid.NewGuid().ToString("N");
                        u = et.T_WH_Toxic_Entity.Add(saveData);
                    }
                    et.SaveChanges();
                    Ret.Data = saveData.ToxicId;
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

        #region 新增同位素放射源
        /// <summary>
        /// 新增同位素放射源
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public JsonResult IsotopeAdd(T_WH_Isotope_Entity saveData)
        {
            JsonRetModel Ret = new JsonRetModel { Ret = false };
            #region 验证
            try
            {
                using (TeamWorkDbContext et = new TeamWorkDbContext())
                {

                    T_WH_Isotope_Entity u = et.T_WH_Isotope_Entity.Find(saveData.IsotopeId);
                    if (u != null)
                    {
                        CommonHelper.RemoveHoldingEntityInContext<T_WH_Isotope_Entity>(u, et);
                        u = saveData;
                        et.Entry<T_WH_Isotope_Entity>(u).State = System.Data.Entity.EntityState.Modified;
                    }
                    else
                    {
                        saveData.IsotopeId = System.Guid.NewGuid().ToString("N");
                        u = et.T_WH_Isotope_Entity.Add(saveData);
                    }
                    et.SaveChanges();
                    Ret.Data = saveData.IsotopeId;
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

        #region 新增危化品使用
        /// <summary>
        /// 新增危化品使用
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public JsonResult DangerChemUseAdd(T_WH_DangerChemUse_Entity saveData)
        {
            JsonRetModel Ret = new JsonRetModel { Ret = false };
            #region 验证
            try
            {
                using (TeamWorkDbContext et = new TeamWorkDbContext())
                {

                    T_WH_DangerChemUse_Entity u = et.T_WH_DangerChemUse_Entity.Find(saveData.DangerChemId);
                    if (u != null)
                    {
                        CommonHelper.RemoveHoldingEntityInContext<T_WH_DangerChemUse_Entity>(u, et);
                        u = saveData;
                        et.Entry<T_WH_DangerChemUse_Entity>(u).State = System.Data.Entity.EntityState.Modified;
                    }
                    else
                    {
                        saveData.DangerChemId = System.Guid.NewGuid().ToString("N");
                        u = et.T_WH_DangerChemUse_Entity.Add(saveData);
                    }
                    et.SaveChanges();
                    Ret.Data = saveData.DangerChemId;
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

        #region 新增危化品生产
        /// <summary>
        /// 新增危化品生产
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public JsonResult DangerChemProAdd(T_WH_DangerChemPro_Entity saveData)
        {
            JsonRetModel Ret = new JsonRetModel { Ret = false };
            #region 验证
            try
            {
                using (TeamWorkDbContext et = new TeamWorkDbContext())
                {

                    T_WH_DangerChemPro_Entity u = et.T_WH_DangerChemPro_Entity.Find(saveData.DangerChemId);
                    if (u != null)
                    {
                        CommonHelper.RemoveHoldingEntityInContext<T_WH_DangerChemPro_Entity>(u, et);
                        u = saveData;
                        et.Entry<T_WH_DangerChemPro_Entity>(u).State = System.Data.Entity.EntityState.Modified;
                    }
                    else
                    {
                        saveData.DangerChemId = System.Guid.NewGuid().ToString("N");
                        u = et.T_WH_DangerChemPro_Entity.Add(saveData);
                    }
                    et.SaveChanges();
                    Ret.Data = saveData.DangerChemId;
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

        #region 新增重大危险源
        /// <summary>
        /// 新增重大危险源
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public JsonResult MajorHazardDossierAdd(T_WH_MajorHazardDossier_Entity saveData)
        {
            JsonRetModel Ret = new JsonRetModel { Ret = false };
            #region 验证
            try
            {
                using (TeamWorkDbContext et = new TeamWorkDbContext())
                {

                    T_WH_MajorHazardDossier_Entity u = et.T_WH_MajorHazardDossier_Entity.Find(saveData.DossierId);
                    if (u != null)
                    {
                        CommonHelper.RemoveHoldingEntityInContext<T_WH_MajorHazardDossier_Entity>(u, et);
                        u = saveData;
                        et.Entry<T_WH_MajorHazardDossier_Entity>(u).State = System.Data.Entity.EntityState.Modified;
                    }
                    else
                    {
                        saveData.DossierId = System.Guid.NewGuid().ToString("N");
                        u = et.T_WH_MajorHazardDossier_Entity.Add(saveData);
                    }
                    et.SaveChanges();
                    Ret.Data = saveData.DossierId;
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

        #region 新增从业人员
        /// <summary>
        /// 新增从业人员
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public JsonResult PersonRecordAdd(T_WH_PersonRecord_Entity saveData)
        {
            JsonRetModel Ret = new JsonRetModel { Ret = false };
            #region 验证
            try
            {
                using (TeamWorkDbContext et = new TeamWorkDbContext())
                {

                    T_WH_PersonRecord_Entity u = et.T_WH_PersonRecord_Entity.Find(saveData.RecordId);
                    if (u != null)
                    {
                        CommonHelper.RemoveHoldingEntityInContext<T_WH_PersonRecord_Entity>(u, et);
                        u = saveData;
                        et.Entry<T_WH_PersonRecord_Entity>(u).State = System.Data.Entity.EntityState.Modified;
                    }
                    else
                    {
                        saveData.RecordId = System.Guid.NewGuid().ToString("N");
                        u = et.T_WH_PersonRecord_Entity.Add(saveData);
                    }
                    et.SaveChanges();
                    Ret.Data = saveData.RecordId;
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