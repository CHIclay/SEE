using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using IDAL;
using DALFactory;

namespace BLL
{
    public class AlbumManager:BaseManager<Album>
    {
        public override IBase<Album> GetDal()
        {
            return DataAccess.CreateAlbum();
        }
    }
}
