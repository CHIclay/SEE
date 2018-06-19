using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data;
using System.Linq.Expressions;
using Model;

namespace DAL
{
    public abstract class SqlServerBase<T> where T : class
    {
        SEEEntities db = new SEEEntities();
        //获取全部数据
        public IQueryable<T> GetAll()
        {
            return db.Set<T>();
        }
        //设置分页
        public IQueryable<T> GetList(int pageSize, int pageIndex)
        {
            return db.Set<T>().OrderBy(GetKey()).Skip((pageIndex - 1) * pageSize).Take(pageSize);
        }
        //获取详情
        public T GetById(int id)
        {
            return db.Set<T>().Where(GetByIdKey(id)).FirstOrDefault();
        }
        //添加
        public int Add(T model)
        {
            db.Set<T>().Add(model);
            return db.SaveChanges();
        }
        //修改
        public int Edit(T model)
        {
            db.Set<T>().Attach(model);
            db.Entry(model).State = EntityState.Modified;
            return db.SaveChanges();
        }
        //删除
        public int Remove(int id)
        {
            T model = db.Set<T>().Where(GetByIdKey(id)).FirstOrDefault();
            db.Set<T>().Remove(model);
            return db.SaveChanges();
        }
        public abstract Expression<Func<T, string>> GetKey();
        public abstract Expression<Func<T, bool>> GetByIdKey(int id);
        //获取总数
        public int GetCount()
        {
            return db.Set<T>().Count();
        }

    }
}
