using System;
using LayUI.Utility.Models;

namespace LayUI.Data
{
    public class IEntity/*<TEntity>*/
    {
        public virtual void Create(KeyValModel LoginInfo)
        {
            var entity = this as ICreationAudited;
            if (entity == null) return;
            if (LoginInfo != null)
            {
                entity.CreateByEmpCode = LoginInfo.Key;
                entity.CreateByEmpName = LoginInfo.Val;
            }
            entity.CreateTime = DateTime.Now;
        }

        public virtual void Modify(KeyValModel LoginInfo)
        {
            var entity = this as IModificationAudited;
            if (entity == null) return;

            if (LoginInfo != null)
            {
                entity.ModifyEmpCode = LoginInfo.Key;
                entity.ModifyEmpName = LoginInfo.Val;
            }
            entity.ModifyTime = DateTime.Now;
        }

        public virtual void Remove(KeyValModel LoginInfo)
        {
            var entity = this as IDeleteAudited;
            if (entity == null) return;

            if (LoginInfo != null)
            {
                entity.ModifyEmpCode = LoginInfo.Key;
                entity.ModifyEmpName = LoginInfo.Val;
            }
            entity.ModifyTime = DateTime.Now;
            entity.IsDeleted = true;
        }
    }
}
