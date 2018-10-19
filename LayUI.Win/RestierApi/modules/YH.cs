using LayUI.Data;
using Microsoft.Restier.Providers.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LayUI.Data.EntityModel;

namespace LayUI.RestierApi
{
    public partial class RestierFilterApi 
    {
        //On<Insert|Updat|Delet|Execut><ed|ing><EntitySetName|ActionName>其中ing的前提交，并ed于提交后。

        #region T_YH_HiddenDanger_Entity

        #region 新增
        protected void OnInsertingT_YH_HiddenDanger_Entity(T_YH_HiddenDanger_Entity entityset)
        {
            try
            {
                if (string.IsNullOrEmpty(entityset.HiddenDangerId))
                {
                    entityset.HiddenDangerId = Guid.NewGuid().ToString("N");
                }

                entityset.OrgCode="test";
                entityset.CreateTime = DateTime.Now;
                entityset.IsDeleted = false;
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        #region 修改
        protected void OnUpdatingT_YH_HiddenDanger_Entity(T_YH_HiddenDanger_Entity entityset)
        {
            try
            {
                entityset.ModifyTime = DateTime.Now;
            }
            catch (Exception)
            {

            }

        }
        #endregion

        #region 不允许物理删除
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        protected bool CanDeleteT_YH_HiddenDanger_Entity()
        {
            return false;
        }
        #endregion

        #endregion

    }
}