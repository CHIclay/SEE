using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using DALFactory;
using IDAL;


namespace BLL
{
    public class ManagerManager
    {
        private IManager imanager = DataAccess.CreateManager();
        public void InsertManager(Manager manager)
        {
            imanager.InsertManager(manager);
        }
        public int Login(Manager manager)
        {
            return imanager.Login(manager);
        }
        public Manager GetManagerByID(int Man_ID)
        {
            return imanager.GetManagerByID(Man_ID);
        }
        public Manager GetManagerByName(string Man_Name)
        {
            return imanager.GetManagerByName(Man_Name);
        }
    }
}
