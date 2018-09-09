using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LayUI.Data;
using LayUI.Data.EntityModel;
using LayUI.Win.Models;
using LayUI.Win.Help;
using System.Security.Claims;
using Microsoft.Owin.Security;
using System.Net;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Threading.Tasks;

namespace LayUI.Win.Controllers
{
    [LoginChecked]
    public class HomeController : BaseController
    {
        public HomeController()
        {
        }

        #region 首页
        public ActionResult Index()
        {
            return View();
        }
        #endregion

        #region 登录

        #region 视图
        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }
        #endregion

        #region 登录验证
        /// <summary>
        /// 登录验证
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <param name="password">密码</param>
        /// <returns></returns>
        [AllowAnonymous]
        //[ValidateAntiForgeryToken]
        [HttpGet]
        public JsonResult SignIn(string userName, string password)
        {
            JsonRetModel Ret = new JsonRetModel { Ret=false};
            #region 验证
            try
            {
                using (TeamWorkDbContext et = new TeamWorkDbContext())
                {
                    T_XT_User_Entity _u = et.T_XT_User_Entity.FirstOrDefault(u => u.EmpCode == userName);
                    #region 存在用户
                    if (_u != null)
                    {
                        #region 验证成功
                        if (_u.LoginPassword.ToUpper() == CommonHelper.StringToMD5(password))
                        {
                            _u.LastLoginTime = _u.TheLoginTime;
                            _u.TheLoginTime = DateTime.Now;

                            T_XT_LogRecords_Entity _log = new T_XT_LogRecords_Entity { 
                                LogRecordId=Guid.NewGuid().ToString("N"),
                                EmpCode=_u.EmpCode,
                                EmpName=_u.EmpName,
                                CreateByEmpCode="system",
                                CreateByEmpName="系统",
                                CreateTime=DateTime.Now,
                                IsDeleted=false
                            };

                            et.T_XT_LogRecords_Entity.Add(_log);
                            et.SaveChanges();

                            #region 记录Session

                            Session["User"] = userName;
                            #endregion

                            Ret.Msg = "登录成功";
                            Ret.Ret = true;
                        }
                        #endregion
                        #region 密码错误
                        else
                        {
                            Ret.Msg = "密码错误";
                        }
                        #endregion
                    }
                    #endregion
                    #region 用户不存在
                    else 
                    {
                        Ret.Msg = "用户不存在";
                    }
                    #endregion
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

        #endregion

        #region 注销
        /// <summary>
        /// 注销当前用户
        /// </summary>
        [HttpGet]
        public void SignOut() 
        {
            Session["User"] = null;
        }
        #endregion
    }
}