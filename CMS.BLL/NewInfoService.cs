using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CMS.DAL;
using CMS.Model;

namespace CMS.BLL
{
    public class NewInfoService
    {
        public List<NewInfo> GetPageList(int pageIndex,int pageSize)
        {
            int start = (pageIndex - 1)*pageSize + 1;
            int end = pageIndex*pageSize;
            NewInfoDal newInfoDal=new NewInfoDal();
            List<NewInfo> list = newInfoDal.GetPageList(start, end);
            return list;
        }
        /// <summary>
        /// 获取页面的总页数
        /// </summary>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public int GetPageCount(int pageSize)
        {
            int record = NewInfoDal.GetRecordCount();
            int pageCount =Convert.ToInt32(Math.Ceiling((double)record/pageSize));
            return pageCount;
        }

        public static NewInfo GetModel(int id)
        {
            return NewInfoDal.GetModel(id);
        }
    }
}
