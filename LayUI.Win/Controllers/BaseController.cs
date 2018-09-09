using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LayUI.Data;
using LayUI.Data.EntityModel;

namespace LayUI.Win.Controllers
{
    public class BaseController : Controller
    {

        #region 获取当前用户信息
        /// <summary>
        /// 获取当前用户信息
        /// </summary>
        /// <returns></returns>
        public T_XT_User_Entity getCurUser() 
        {
            T_XT_User_Entity _u = null;

                try
                {
                    using (TeamWorkDbContext et = new TeamWorkDbContext())
                    {
                        string _empcode = getCurUserEmpCode();
                        if (!string.IsNullOrEmpty(_empcode)) {_u = et.T_XT_User_Entity.FirstOrDefault(u => u.EmpCode == _empcode); }
                        
                    }
                }
                catch (Exception)
                {
                    
                }
            
            return _u;
        }
        #endregion

        #region 获取当前用户工号
        /// <summary>
        /// 获取当前用户工号
        /// </summary>
        /// <returns></returns>
        public string getCurUserEmpCode() 
        {
            string ret = null;
            try
            {
                if (Session["User"] != null)
                {
                    ret = Session["User"].ToString();
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