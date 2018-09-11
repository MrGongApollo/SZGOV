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
    }
}