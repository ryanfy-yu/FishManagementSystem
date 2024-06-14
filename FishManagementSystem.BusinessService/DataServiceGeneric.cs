using FishManagementSystem.IBussinessService;
using FishManagementSystem.DBModels.Utils;
using FishManagementSystem.DBModels.Models;
using SqlSugar;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq.Expressions;
using FishManagementSystem.IDBModels;
using System.Linq;
using Newtonsoft.Json;

namespace FishManagementSystem.BusinessService
{
    public class DataServiceGeneric<T> : IDisposable, IDataServiceGeneric<T> where T : IModel, new()
    {

        private readonly ISqlSugarClient db;


        public DataServiceGeneric(string dbConnectionString)
        {
            db = new SqlSugarSetup(dbConnectionString).getDB();
        }

        public int GetCount()
        {
            return db.Queryable<T>().Where(o => o.IsDeleted != true).Count();
        }

        public int GetCount(Expression<Func<T, bool>> exp)
        {
            return db.Queryable<T>().Where(o => o.IsDeleted != true).Where(exp).Count();
        }

        public T Get(string id)
        {
            return db.Queryable<T>().Where(it => it.Id == id && it.IsDeleted != true).First();
        }

        public List<T> Get()
        {
            return db.Queryable<T>().Where(it => it.IsDeleted != true).ToList();
        }

        public List<T> Get(Expression<Func<T, bool>> exp)
        {
            return db.Queryable<T>().Where(it => it.IsDeleted != true).Where(exp).ToList();
        }


        public List<T> Get(int pagenumber, int pageSize, ref int totalCount, ref int totalPage, Expression<Func<T, bool>>? exp, List<dynamic>? orderbyModerList)
        {

            List<T>? resultList = null;

            if (exp != null)
            {

                if (orderbyModerList != null && orderbyModerList.Count > 0)
                {
                    string orderbyJson = JsonConvert.SerializeObject(orderbyModerList);

                    var _orderbyModerList = JsonConvert.DeserializeObject<List<OrderByModel>>(orderbyJson);

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
                    string orderbyJson = JsonConvert.SerializeObject(orderbyModerList);

                    var _orderbyModerList = JsonConvert.DeserializeObject<List<OrderByModel>>(orderbyJson);

                    resultList = db.Queryable<T>().Where(it => it.IsDeleted != true).OrderBy(_orderbyModerList).ToPageList(pagenumber, pageSize, ref totalCount, ref totalPage);

                }
                else
                {
                    resultList = db.Queryable<T>().Where(it => it.IsDeleted != true).OrderBy(o => SqlFunc.Desc(o.CreateDate)).ToPageList(pagenumber, pageSize, ref totalCount, ref totalPage);
                }
            }

            return resultList;
        }


        public bool Add(T model)
        {
            model.CreateDate = DateTime.Now;
            return db.Insertable<T>(model).ExecuteCommand() > 0;
        }

        public int Add(List<T> list)
        {
            list.ForEach(o => o.CreateDate = DateTime.Now);
            return db.Insertable(list).ExecuteCommand();
        }


        public bool Delete(string id)
        {
            var model = this.Get(id);
            model.IsDeleted = true;
            model.UpdateDate = DateTime.Now;

            return db.Updateable<T>(model).ExecuteCommand() > 0;

        }

        public int Delete(List<T> list)
        {
            foreach (var item in list)
            {
                item.IsDeleted = true;
                item.UpdateDate = DateTime.Now;
            }
            return db.Updateable<T>(list).ExecuteCommand();
        }

        public bool Update(T model)
        {
            model.UpdateDate = DateTime.Now;
            return db.Updateable<T>(model).ExecuteCommand() > 0;
        }

        public int Update(List<T> list)
        {
            list.ForEach(o => o.UpdateDate = DateTime.Now);
            return db.Updateable<T>(list).ExecuteCommand();
        }

        public void Dispose()
        {
            try { db.Dispose(); }
            catch (Exception ex)
            {

                //log
            }

        }
    }
}
