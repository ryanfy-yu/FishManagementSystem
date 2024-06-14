using Autofac.Extras.DynamicProxy;
using FishManagementSystem.AOP;
using FishManagementSystem.DBModels.Utils;
using FishManagementSystem.IBussinessService;
using FishManagementSystem.IDBModels;
using Microsoft.Extensions.Configuration;
using SqlSugar;
using System.Linq.Expressions;

namespace FishManagementSystem.BusinessService
{
    public class DataService : IDisposable, IDataService
    {

        private readonly ISqlSugarClient db;

        public DataService()
        {

            var config = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json").Build();

            string dbConnectionString = config.GetConnectionString("FishDB") ?? string.Empty;

            db = new SqlSugarSetup(dbConnectionString).getDB();
        }

        public int GetCount<T>() where T : IModel, new()
        {
            return db.Queryable<T>().Where(o => o.IsDeleted != true).Count();
        }

        public int GetCount<T>(Expression<Func<T, bool>> exp) where T : IModel, new()
        {
            return db.Queryable<T>().Where(o => o.IsDeleted != true).Where(exp).Count();
        }

        public T Get<T>(string id) where T : IModel, new()
        {
            return db.Queryable<T>().Where(it => it.Id == id && it.IsDeleted != true).First();
        }

        public List<T> Get<T>() where T : IModel, new()
        {
            return db.Queryable<T>().Where(it => it.IsDeleted != true).ToList();
        }

        public List<T> Get<T>(Expression<Func<T, bool>> exp) where T : IModel, new()
        {
            return db.Queryable<T>().Where(it => it.IsDeleted != true).Where(exp).ToList();
        }


        public List<T> Get<T>(int pagenumber, int pageSize, ref int totalCount, ref int totalPage, Expression<Func<T, bool>>? exp, List<dynamic>? orderbyModerList) where T : IModel, new()
        {

            List<T>? resultList = null;

            if (exp != null)
            {

                if (orderbyModerList != null && orderbyModerList.Count > 0)
                {

                    List<OrderByModel> _orderbyModerList = orderbyModerList.OfType<OrderByModel>().ToList();

                    resultList = db.Queryable<T>().Where(it => it.IsDeleted != true).Where(exp).OrderBy(_orderbyModerList).ToPageList(pagenumber, pageSize, ref totalCount, ref totalPage);

                }
                else
                {
                    resultList = db.Queryable<T>().Where(it => it.IsDeleted != true).Where(exp).OrderBy(o => SqlFunc.Desc(o.CreateDate)).ToPageList(pagenumber, pageSize, ref totalCount, ref totalPage);
                }
            }
            else
            {
                if (orderbyModerList != null && orderbyModerList.Count > 0)
                {
                    List<OrderByModel> _orderbyModerList = orderbyModerList.OfType<OrderByModel>().ToList();

                    resultList = db.Queryable<T>().Where(it => it.IsDeleted != true).OrderBy(_orderbyModerList).ToPageList(pagenumber, pageSize, ref totalCount, ref totalPage);

                }
                else
                {
                    resultList = db.Queryable<T>().Where(it => it.IsDeleted != true).OrderBy(o => SqlFunc.Desc(o.CreateDate)).ToPageList(pagenumber, pageSize, ref totalCount, ref totalPage);
                }
            }

            return resultList;
        }


        public bool Add<T>(T model) where T : IModel, new()
        {
            model.CreateDate = DateTime.Now;
            return db.Insertable<T>(model).ExecuteCommand() > 0;
        }

        public int Add<T>(List<T> list) where T : IModel, new()
        {
            list.ForEach(o => o.CreateDate = DateTime.Now);
            return db.Insertable(list).ExecuteCommand();
        }


        public bool Delete<T>(string id) where T : IModel, new()
        {
            var model = this.Get<T>(id);
            model.IsDeleted = true;
            model.UpdateDate = DateTime.Now;

            return db.Updateable<T>(model).ExecuteCommand() > 0;

        }

        public int Delete<T>(List<T> list) where T : IModel, new()
        {
            foreach (var item in list)
            {
                item.IsDeleted = true;
                item.UpdateDate = DateTime.Now;
            }
            return db.Updateable<T>(list).ExecuteCommand();
        }

        public bool Update<T>(T model) where T : IModel, new()
        {
            model.UpdateDate = DateTime.Now;
            return db.Updateable<T>(model).ExecuteCommand() > 0;
        }

        public int Update<T>(List<T> list) where T : IModel, new()
        {
            list.ForEach(o => o.UpdateDate = DateTime.Now);
            return db.Updateable<T>(list).ExecuteCommand();
        }

        public void Dispose()
        {

            db.Dispose();

        }
    }
}
