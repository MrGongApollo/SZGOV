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

    }
}