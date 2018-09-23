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
using LayUI.Utility.Models;
using System.Data;
using System.Drawing;
using System.IO;

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
            if (U != null) { 
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
            else
            {
                return Json(null);
            }
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

        #region 文件上传
        //[HttpPost]
        //public JsonResult FileUpload()
        //{
           
        //    string RelevanceIdS = Request["RelevanceId"];
        //    string FromModuleNameS = Request["FromModuleName"];
        //    string FromTableNameS = "";
        //    string DocTypeS = Request["DocType"];
        //    string CreateByEmpCodeS = Request["CreateByEmpCode"];
        //    string CreateByEmpNameS = Request["CreateByEmpName"];
        //    JsonRetModel Ret = new JsonRetModel { Ret = false };
        //    HttpPostedFileBase files = Request.Files["file"];
        //    try
        //    {
        //        TeamWorkDbContext et = new TeamWorkDbContext();
        //        if (files == null)
        //        {
        //            Ret.Ret = false;
        //            Ret.Msg = "请选择文件!!";
        //            return Json(Ret, JsonRequestBehavior.AllowGet);
        //        }
        //        if (RelevanceIdS == null)
        //        {
        //            Ret.Ret = false;
        //            Ret.Msg = "请重新打开上传页面!!";
        //            return Json(Ret, JsonRequestBehavior.AllowGet);
        //        }
        //        if (FromModuleNameS == "ZDWX")
        //        {
        //            FromTableNameS = "T_WH_MajorHazardDossier";
        //        }
        //        string filePath = string.Empty;
        //        decimal size = files.ContentLength / 1024;
        //        Guid gid = Guid.NewGuid();
        //        string datePath = DateTime.Now.ToString("yyyy-MM") + "";
        //        filePath = Path.Combine("D:/anbao/Uploads/" + datePath + "/");//地址换成常量
        //        if (!Directory.Exists(filePath))
        //        {
        //            Directory.CreateDirectory(filePath);

        //        }
        //        filePath = Path.Combine(filePath + gid.ToString() + Path.GetExtension(files.FileName));
        //        files.SaveAs(filePath);
        //        et.T_XT_Doc_Entity.Add(new T_XT_Doc_Entity
        //        {
        //            StoreDirectoryId = "",
        //            DocId = System.Guid.NewGuid().ToString("N"),
        //            DocName = files.FileName,
        //            DocType = DocTypeS,
        //            DocSize = size,
        //            SubDirectory = datePath,
        //            InternalName = gid.ToString(),
        //            DownloadCount = 0,
        //            FromModuleName = FromModuleNameS,
        //            FromTableName = FromTableNameS,
        //            RelevanceId = RelevanceIdS,
        //            CreateByEmpCode = CreateByEmpCodeS,
        //            CreateByEmpName = CreateByEmpNameS,
        //            CreateTime = DateTime.Now,
        //            IsDeleted = false
        //        });
        //        et.SaveChanges();
        //        Ret.Ret = true;
        //    }
        //    catch (Exception ex)
        //    {
        //        Ret.Ret = false;
        //        Ret.Msg = ex.Message;
        //    }
        //    return Json(Ret, JsonRequestBehavior.AllowGet);
        //}

        public ActionResult FileList() 
        {
            return View();
        
        }
        #endregion

        #region 文件上传
        /// <summary>
        /// 文件上传
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public JsonResult FileUpload()
        {
            JsonRetModel ret = new JsonRetModel();

            try
            {
                Response.ContentType = "text/plain";
                Response.ContentEncoding = System.Text.Encoding.GetEncoding("UTF-8");
                Response.Charset = "utf-8";

                string _RelevanceId = Request["RelevanceId"],
                       _FromModuleName = Request["FromModuleName"],
                       _FromTableName = Request["FromTableName"],
                       _ExpandOne = Request["ExpandOne"],
                       _ExpandTwo = Request["ExpandTwo"],
                       _ExpandThree = Request["ExpandThree"],
                       _ExpandFour = Request["ExpandFour"],
                       _ExpandFive = Request["ExpandFive"];

                HttpPostedFileBase file = Request.Files["file"];

                KeyValModel kv = GetCurrentStoreDirectory();//获取存储物理路径
                if (kv != null)
                {
                    using (TeamWorkDbContext et=new TeamWorkDbContext())
                    {
                        string storeDirectoryId = kv.Key,
                               storeDirectory = kv.Val,
                               subDirectory = DateTime.Now.ToString("yyyyMM"),
                               uploadPath = storeDirectory + @"\" + subDirectory + @"\";

                        if (file != null)
                        {
                            if (!Directory.Exists(uploadPath))
                            {
                                Directory.CreateDirectory(uploadPath);
                            }
                            string[] array = file.FileName.Split('.');
                            string suffix = "." + array[array.Length - 1],
                                   internalName = Guid.NewGuid().ToString("N"),
                                   realPath = uploadPath + internalName,
                                   fullPath = realPath + suffix;

                            if (CheckImageExt(suffix))
                            {
                                MakeSmallImg(file.InputStream, realPath + "_s" + suffix, 100, 100);
                                MakeSmallImg(file.InputStream, fullPath, 800, 800);
                            }
                            else
                            {
                                file.SaveAs(fullPath);
                            }

                            T_XT_Doc_Entity _doc = new T_XT_Doc_Entity
                            {
                                DocId=Guid.NewGuid().ToString("N"),
                                StoreDirectoryId = storeDirectoryId,
                                DocName = file.FileName,
                                DocType = suffix,
                                DocSize = file.ContentLength,
                                SubDirectory = subDirectory,
                                InternalName = internalName,
                                DownloadCount = 0,
                                FromModuleName = _FromModuleName,
                                FromTableName = _FromTableName,
                                RelevanceId = _RelevanceId,
                                ExpandOne = _ExpandOne,
                                ExpandTwo = _ExpandTwo,
                                ExpandThree = _ExpandThree,
                                ExpandFour = _ExpandFour,
                                ExpandFive = _ExpandFive,
                                //CreateByEmpCode = CreateByEmpCodeS,
                                //CreateByEmpName = CreateByEmpNameS,
                                CreateTime = DateTime.Now,
                                IsDeleted = false
                            };
                            et.T_XT_Doc_Entity.Add(_doc);
                            et.SaveChanges();

                            ret.Ret = true;
                            ret.Msg = "上传成功";

                            ret.Data = new
                            {
                                StoreDirectoryId = storeDirectoryId,
                                SubDirectory = subDirectory,
                                InternalName = internalName,
                                RealPath = fullPath
                            };

                        }
                        else
                        {
                            ret.Ret = false;
                            ret.Msg = "未检测到文件";
                        }
                    }

                    

                }
            }
            catch (Exception ex)
            {
                ret.Ret = false;
                ret.Msg = ex.Message;
            }

            return Json(ret);
        }

        #endregion

        #region 获取文件储存地址
        /// <summary>
        /// 获取文件储存地址
        /// </summary>
        /// <returns></returns>
        protected KeyValModel GetCurrentStoreDirectory()
        {
            KeyValModel ret = null;
            try
            {
                using (TeamWorkDbContext et=new TeamWorkDbContext())
                {
                    T_XT_StoreDirectory_Entity st = et.T_XT_StoreDirectory_Entity.FirstOrDefault(k=>k.IsDeleted==false);
                    if (st != null) 
                    {
                        ret = new KeyValModel
                        {
                            Key = st.StoreDirectoryId,
                            Val = st.StoreDirectoryPath
                        };
                    }
                }
            }
            catch (Exception)
            {

            }
            return ret;
        } 
        #endregion

        #region 生成缩略图
        // 按模版比例生成缩略图（以流的方式获取源文件）
        //生成缩略图函数
        //顺序参数：源图文件流、缩略图存放地址、模版宽、模版高
        //注：缩略图大小控制在模版区域内
        public void MakeSmallImg(System.IO.Stream fromFileStream, string fileSaveUrl, System.Double templateWidth, System.Double templateHeight)
        {
            try
            {
                #region 图片处理
                using (Image myImage = Image.FromStream(fromFileStream, true))
                {
                    //缩略图宽、高
                    System.Double newWidth = myImage.Width, newHeight = myImage.Height;
                    //宽大于模版的横图
                    if (myImage.Width > myImage.Height || myImage.Width == myImage.Height)
                    {
                        if (myImage.Width > templateWidth)
                        {
                            //宽按模版，高按比例缩放
                            newWidth = templateWidth;
                            newHeight = myImage.Height * (newWidth / myImage.Width);
                        }
                    }
                    //高大于模版的竖图
                    else
                    {
                        if (myImage.Height > templateHeight)
                        {
                            //高按模版，宽按比例缩放
                            newHeight = templateHeight;
                            newWidth = myImage.Width * (newHeight / myImage.Height);
                        }
                    }

                    //取得图片大小
                    System.Drawing.Size mySize = new Size((int)newWidth, (int)newHeight);
                    //新建一个bmp图片

                    using (Image bitmap = new Bitmap(mySize.Width, mySize.Height))
                    {
                        //新建一个画板
                        using (Graphics g = Graphics.FromImage(bitmap))
                        {
                            //设置高质量插值法
                            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;
                            //设置高质量,低速度呈现平滑程度
                            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                            //清空一下画布
                            g.Clear(Color.White);

                            //在指定位置画图
                            g.DrawImage(myImage, new System.Drawing.Rectangle(0, 0, bitmap.Width, bitmap.Height),
                            new System.Drawing.Rectangle(0, 0, myImage.Width, myImage.Height),
                            System.Drawing.GraphicsUnit.Pixel);

                            #region
                            ///文字水印
                            //System.Drawing.Graphics G = System.Drawing.Graphics.FromImage(bitmap);
                            //System.Drawing.Font f = new Font("宋体", 10);
                            //System.Drawing.Brush b = new SolidBrush(Color.Black);
                            //G.DrawString("张赵君", f, b, 150, 350);
                            //G.Dispose(); 

                            ///图片水印
                            //System.Drawing.Image copyImage = System.Drawing.Image.FromFile(System.Web.HttpContext.Current.Server.MapPath("pic/1.gif"));
                            //Graphics a = Graphics.FromImage(bitmap);
                            //a.DrawImage(copyImage, new Rectangle(bitmap.Width-copyImage.Width,bitmap.Height-copyImage.Height,copyImage.Width, copyImage.Height),0,0, copyImage.Width, copyImage.Height, GraphicsUnit.Pixel); 

                            //copyImage.Dispose();
                            //a.Dispose();
                            //copyImage.Dispose(); 
                            #endregion

                            //保存缩略图
                            bitmap.Save(fileSaveUrl, System.Drawing.Imaging.ImageFormat.Jpeg);
                        }
                    }



                }
                #endregion
            }
            catch (Exception ex)
            {

            }
        }

        #endregion

        #region 检查是否为合法的上传图片
                /// <summary>
        /// 检查是否为合法的上传图片
        /// </summary>
        /// <param name="_fileExt"></param>
        /// <returns></returns>
        private bool CheckImageExt(string _ImageExt)
        {
            string[] allowExt = new string[] { ".gif", ".jpg", ".jpeg", ".bmp", ".png",".ico" };
            for (int i = 0; i < allowExt.Length; i++)
            {
                if (allowExt[i] == _ImageExt.ToLower()) { return true; }
            }
            return false;

        }
        #endregion

        #endregion
    }
}