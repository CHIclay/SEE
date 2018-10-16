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
        private IAlbum ialbum=DataAccess.CreateAlbum();
        public override IBase<Album> GetDal()
        {
            return DataAccess.CreateAlbum();
        }
        //获取全部相册信息
        public List<Album> List()
        {
            return ialbum.List();
        }
    }
}
