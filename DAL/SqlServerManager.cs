using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IDAL;
using Model;
using System.Data.Entity;
using System.Linq.Expressions;


namespace DAL
{
    public class SqlServerManager:SqlServerBase<Manager>,IManager
    {
        public override Expression<Func<Manager, bool>> GetByIdKey(int id)
        {
            return u => u.Man_ID == id;
        }

        public override Expression<Func<Manager, string>> GetKey()
        {
            return u => u.Man_ID.ToString();
        }
        SEEEntities db = new SEEEntities();
        public void InsertManager(Manager manager)
        {
            db.Manager.Add(manager);
            db.SaveChanges();
        }
        public int Login(Manager manager)
        {
            var managers = from u in db.Manager
                           where u.Man_Name == manager.Man_Name && u.Man_Pas == manager.Man_Pas
                           select u;
            int result = managers.Count();
            return result;
        }
        public Manager GetManagerByName(string Man_Name)
        {
            Manager managers = (from u in db.Manager
                                where u.Man_Name == Man_Name
                                select u).FirstOrDefault();
            return managers;
        }
        public Manager GetManagerByID(int Man_ID)
        {
            Manager managers = (from u in db.Manager
                                where u.Man_ID == Man_ID
                                select u).FirstOrDefault();
            return managers;
        }
         
    }
}
