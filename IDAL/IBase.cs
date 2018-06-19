using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace IDAL
{
    public interface IBase<T> where T:class
    {
        IQueryable<T> GetAll();
        IQueryable<T> GetList(int pageSize, int pageIndex);
        T GetById(int id);
        int Add(T emp);
        int Edit(T emp);
        int Remove(int id);
        Expression<Func<T, string>> GetKey();
        Expression<Func<T, bool>> GetByIdKey(int id);
        int GetCount();
    }
}
