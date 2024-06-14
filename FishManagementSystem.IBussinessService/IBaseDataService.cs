using FishManagementSystem.IDBModels;
using System.Linq.Expressions;

namespace FishManagementSystem.IBussinessService
{
    public interface IBaseDataService
    {

        public int GetCount<T>() where T : IModel, new();


        public int GetCount<T>(Expression<Func<T, bool>> exp) where T : IModel, new();


        public T Get<T>(string id) where T : IModel, new();

        public List<T> Get<T>(int pagenumber, int pageSize, ref int totalCount, ref int totalPage, Expression<Func<T, bool>>? exp, List<dynamic>? orderbymoderList) where T : IModel, new();

        public List<T> Get<T>() where T : IModel, new();


        public List<T> Get<T>(Expression<Func<T, bool>> exp) where T : IModel, new();


        public bool Add<T>(T model) where T : IModel, new();


        public int Add<T>(List<T> list) where T : IModel, new();



        public bool Delete<T>(string id) where T : IModel, new();


        public int Delete<T>(List<T> list) where T : IModel, new();


        public bool Update<T>(T model) where T : IModel, new();


        public int Update<T>(List<T> list) where T : IModel, new();


    }
}
