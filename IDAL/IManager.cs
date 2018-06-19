using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;


namespace IDAL
{
    public interface IManager
    {
        void InsertManager(Manager manager);
        int Login(Manager manager);
        Manager GetManagerByID(int Manager_Id);
        Manager GetManagerByName(string Manager_Name);
    }
}
