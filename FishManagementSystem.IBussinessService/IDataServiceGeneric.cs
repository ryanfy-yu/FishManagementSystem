using FishManagementSystem.IDBModels;
using System.Linq.Expressions;

namespace FishManagementSystem.IBussinessService
{
    public interface IDataServiceGeneric<T> where T : IModel,new()
    {

        public int GetCount();


        public int GetCount(Expression<Func<T, bool>> exp);


        public T Get(string id);

        public List<T> Get(int pagenumber, int pageSize, ref int totalCount, ref int totalPage, Expression<Func<T, bool>>? exp, List<dynamic>? orderbymoderList);

        public List<T> Get();


        public List<T> Get(Expression<Func<T, bool>> exp);


        public bool Add(T model);


        public int Add(List<T> list);



        public bool Delete(string id);


        public int Delete(List<T> list);


        public bool Update(T model);


        public int Update(List<T> list);

    }
}
