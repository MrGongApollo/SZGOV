using LayUI.Data;
using LayUI.Data.EntityModel;
using LayUI.Utility;
using Microsoft.Restier.Providers.EntityFramework;
using Microsoft.Restier.Publishers.OData.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Extensions.DependencyInjection;
using System.Web.OData.Query;
using Microsoft.Restier.Core.Query;
using Microsoft.Restier.Core;
using Microsoft.Restier.Core.Submit;
using System.Threading.Tasks;
using System.Threading;
using System.Reflection;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using LayUI.Utility.Models;
using LayUI.Win.Controllers;

namespace LayUI.RestierApi
{

    public partial class RestierExamApi : EntityFrameworkApi<TeamWorkDbContext>
    {

        //OnFilter[实体类型名称](IQueryable<T> entityset)
        #region 实体过滤集 

        //protected IQueryable<ModuleEntity> OnFilterModuleEntity(IQueryable<ModuleEntity> entitySet)
        //{
        //    return entitySet.Where(s => s.F_ParentId != "0").AsQueryable();
        //}

        #endregion

        //Can<Insert|Update|Delete|Execute><EntitySetName|ActionName>
        #region 授权 

        //protected bool CanDeleteTestEntity()
        //{
        //    return false;
        //}

        //// Can execute an action named ResetDataSource?
        //protected bool CanExecuteResetDataSource()
        //{
        //    return false;
        //}

        #endregion

        //On<Insert|Updat|Delet|Execut><ed|ing><EntitySetName|ActionName>其中ing的前提交，并ed于提交后。
        #region 插入用户逻辑

        //protected void OnUpdatingTestEntity(TestEntity entityset)
        //{
        //    //WriteLog(DateTime.Now.ToString() + entityset.ProductID + " ,is being updated");
        //}

        // Gets called after inserting an entity to the entity set Products.
        //protected void OnInsertedTestEntity(TestEntity product)
        //{
        //    //WriteLog(DateTime.Now.ToString() + product.ProductID + " has been inserted");
        //}

        #endregion

        #region 扩展模型
        //[Resource]
        //public TestEntity Me { get { return DbContext.TestEntity.Find(0); } }

        //[Resource]
        //public IQueryable<TestEntity> Tests
        //{
        //    get { return DbContext.TestEntity; }
        //}

        #endregion

        #region 操作

        //// Action import
        //[Operation(Namespace = "Microsoft.OData.Service.Sample.Trippin.Models", HasSideEffects = true)]
        //public void CleanUpExpiredTrips() { }

        //// Bound action
        //[Operation(Namespace = "Microsoft.OData.Service.Sample.Trippin.Models", IsBound = true, HasSideEffects = true)]
        //public TestEntity EndTestEntity(TestEntity bindingParameter) { return bindingParameter; }

        //// Function import
        //[Operation(Namespace = "Microsoft.OData.Service.Sample.Trippin.Models", EntitySet = "TestEntity")]
        //public IEnumerable<TestEntity> GetPeopleWithFriendsAtLeast(int n) { return null; }

        //// Bound function
        //[Operation(Namespace = "Exam.Data.EntityModel", IsBound = true, EntitySet = "EExamQuestionsEntity")]
        //public EExamQuestionsEntity GetPersonWithMostFriends(IEnumerable<EExamQuestionsEntity> bindingParameter)
        //{
        //    return null;
        //}

        #endregion

        public RestierExamApi(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }

        public static new IServiceCollection ConfigureApi(Type apiType, IServiceCollection services)
        {
            // Add customized OData validation settings  自定义查询设置
            Func<IServiceProvider, ODataValidationSettings> validationSettingFactory = sp => new ODataValidationSettings
            {
                MaxAnyAllExpressionDepth = 3,
                MaxExpansionDepth = 3
            };

            return EntityFrameworkApi<TeamWorkDbContext>.ConfigureApi(apiType, services)
                //自定义查询设置
                .AddSingleton<ODataValidationSettings>(validationSettingFactory)
                //定制查询授权逻辑，改为WebApi授权机制
                //.AddService<IQueryExpressionAuthorizer, QueryCustomizedAuthorizer>()
                //定制查询过程逻辑
                ////.AddService<IQueryExpressionProcessor, QueryCustomizedProcessor>()
                //定制提交授权逻辑
                //.AddService<IChangeSetItemAuthorizer, SubmitCustomizedAuthorizer>()
                //定制提交过程逻辑
                .AddService<IChangeSetItemFilter, SubmitCustomizedFilter>();
        }

        /// <summary>
        /// 定制查询授权逻辑
        /// </summary>
        public class QueryCustomizedAuthorizer : IQueryExpressionAuthorizer
        {
            private IQueryExpressionAuthorizer InnerAuthorizer { get; set; }

            public bool Authorize(QueryExpressionContext context)
            {
                return true;
            }
        }

        /// <summary>
        /// 定制提交授权逻辑
        /// </summary>
        public class SubmitCustomizedAuthorizer : IChangeSetItemAuthorizer
        {

            // The inner Authorizer will call CanUpdate/Insert/Delete<EntitySet> method
            private IChangeSetItemAuthorizer InnerAuthorizer { get; set; }

            public Task<bool> AuthorizeAsync(SubmitContext context, ChangeSetItem item
                , CancellationToken cancellationToken)
            {
                // Add any customized logic here

                return InnerAuthorizer.AuthorizeAsync(context, item, cancellationToken);
                //return new Task<bool>(() => { return false; });
            }
        }

        /// <summary>
        /// 定制提交过程逻辑
        /// </summary>
        public class SubmitCustomizedFilter : IChangeSetItemFilter
        {
            private IChangeSetItemFilter InnerProcessor { get; set; }

            // Any customized logic needed before persist called can be added here.
            // InnerProcessor call related OnUpdating|Inseting|Deleting<EntitySet> methods
            public Task OnChangeSetItemProcessingAsync(SubmitContext context, ChangeSetItem item
                , CancellationToken cancellationToken)
            {
                return InnerProcessor.OnChangeSetItemProcessingAsync(context, item, cancellationToken);
            }

            // Any customized logic needed after persist called can be added here.
            // InnerProcessor call related OnUpdated|Inseted|Deleted<EntitySet> methods
            public Task OnChangeSetItemProcessedAsync(SubmitContext context, ChangeSetItem item
                , CancellationToken cancellationToken)
            {
                var dataModificationItem = item as DataModificationItem;
                if (dataModificationItem != null)
                {
                    object myEntity = dataModificationItem.Resource;
                    string entitySetName = dataModificationItem.ResourceSetName;
                    DataModificationItemAction operation = dataModificationItem.DataModificationItemAction;

                    // In case of insert, the request URL has no key, and request body may not have key neither as the key may be generated by database
                    var keyAttrbiutes = new Dictionary<string, object>();
                    var keyConvention = new Dictionary<string, object>();

                   //var entityTypeName = myEntity.GetType().Name;
                   // PropertyInfo[] properties = myEntity.GetType().GetProperties();

                    var et = myEntity as IEntity;
                    KeyValModel _user = null;
                    var C_user=new BaseController().getCurUser();
                    if (C_user!=null) 
                    {
                        _user=new KeyValModel
                        {
                            Key = C_user.EmpCode,
                            Val = C_user.EmpName
                        };
                    }

                    switch (operation)
                    {
                        case DataModificationItemAction.Insert:
                            et.Create(_user);
                            break;
                        case DataModificationItemAction.Remove:
                            et.Remove(_user);
                            break;
                        case DataModificationItemAction.Undefined:
                            break;
                        case DataModificationItemAction.Update:
                            et.Modify(_user);
                            break;
                        default:
                            break;
                    }
                    

                }

                return InnerProcessor.OnChangeSetItemProcessedAsync(context, item, cancellationToken);
            }
        }

        /// <summary>
        /// 定制查询过程逻辑
        /// </summary>
        public class QueryCustomizedProcessor : IQueryExpressionProcessor
        {
            private IQueryExpressionProcessor InnerProcessor { get; set; }

            public Expression Process(QueryExpressionContext context)
            {
                return InnerProcessor.Process(context);
            }
        }


    }
}