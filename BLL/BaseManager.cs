using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IDAL;


namespace BLL
{
    public abstract class BaseManager<T> where T : class
    {
        private IBase<T> dal;
        public abstract IBase<T> GetDal();
        public BaseManager()
        {
            dal = GetDal();
        }
        //获得全部表数据
        public IQueryable<T> GetAll()
        {
            return dal.GetAll();
        }
        public IQueryable<T> GetList(int pageSize, int pageIndex)
        {
            return dal.GetList(pageSize, pageIndex);
        }
        public T GetById(int id)
        {
            return dal.GetById(id);
        }
        public bool Add(T t)
        {
            return dal.Add(t) > 0;
        }
        public bool Edit(T t)
        {
            return dal.Edit(t) > 0;
        }
        public bool Remove(int id)
        {
            return dal.Remove(id) > 0;
        }
        public int GetCount()
        {
            return dal.GetCount();
        }
    }
}
