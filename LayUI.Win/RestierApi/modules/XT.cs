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

        #region T_XT_Data_Entity

        #region 新增
        protected void OnInsertingT_XT_Data_Entity(T_XT_Data_Entity entityset)
        {
            try
            {
                if (string.IsNullOrEmpty(entityset.DataId))
                {
                    entityset.DataId = Guid.NewGuid().ToString("N");
                }

                entityset.CreateTime = DateTime.Now;
                entityset.IsDeleted = false;
                entityset.SubItemAmount = 0;
                #region 更新子节点数量
                using (TeamWorkDbContext et = new TeamWorkDbContext())
                {
                    T_XT_Data_Entity _p = et.T_XT_Data_Entity.FirstOrDefault(k => k.DataId == entityset.ParentId);
                    if (_p != null)
                    {
                        _p.SubItemAmount = et.T_XT_Data_Entity.Where(k => k.ParentId == _p.DataId && k.IsDeleted == false).Count() + 1;
                        et.SaveChanges();
                    }
                }
                #endregion
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        #region 修改
        protected void OnUpdatingT_XT_Data_Entity(T_XT_Data_Entity entityset)
        {
            entityset.ModifyTime = DateTime.Now;
        }
        #endregion

        #region 删除
        protected void OnDeletingT_XT_Data_Entity(T_XT_Data_Entity entityset)
        {
            entityset.ModifyTime = DateTime.Now;
            entityset.IsDeleted = true;
            #region 更新子节点数量
            using (TeamWorkDbContext et = new TeamWorkDbContext())
            {
                T_XT_Data_Entity _p = et.T_XT_Data_Entity.FirstOrDefault(k => k.DataId == entityset.ParentId);
                if (_p != null)
                {
                    _p.SubItemAmount = et.T_XT_Data_Entity.Where(k => k.ParentId == _p.DataId && k.IsDeleted == false).Count()-1;
                    et.SaveChanges();
                }
            }
            #endregion
        }
        #endregion

        #region 不允许物理删除
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        protected bool CanDeleteT_XT_Data_Entity()
        {
            return false;
        }
        #endregion

        #endregion

    }
}