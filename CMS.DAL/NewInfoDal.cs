using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CMS.Model;
using System.Data;
using System.Data.SqlClient;

namespace CMS.DAL
{
    public class NewInfoDal
    {
        public List<NewInfo> GetPageList(int start, int end)
        {
            string sql = "select * from (select row_number() over(order by id) as num,* from T_News) as t where t.num>=@start and t.num<=@end";
            SqlParameter[] pms = new SqlParameter[]
           {
               new SqlParameter("@start",start),
               new SqlParameter("@end",end) 
           };
            DataTable dt = SqlHelper.GetTable(sql, CommandType.Text, pms);
            List<NewInfo> list = null;
            if (dt.Rows.Count > 0)
            {
                list = new List<NewInfo>();
                NewInfo newInfo = null;
                foreach (DataRow row in dt.Rows)
                {
                    newInfo = new NewInfo();
                    LoadEntity(row,newInfo);
                    list.Add(newInfo);
                }
            }
            return list;
        }

        private void LoadEntity(DataRow row, NewInfo newInfo)
        {
            newInfo.Id = Convert.ToInt32(row["Id"]);
            newInfo.Msg = Convert.ToString(row["Msg"]);
            newInfo.Title = Convert.ToString(row["Title"]);
            newInfo.SubDateTime = Convert.ToDateTime(row["SubDateTime"]);
            newInfo.ImagePath = Convert.ToString(row["ImagePath"]);
            newInfo.Author = Convert.ToString(row["Author"]);
        }

        public static int GetRecordCount()
        {
            string sql = "select count(*) from T_News";
            return (int)SqlHelper.ExecuteScalar(sql, CommandType.Text, null);
        }

        public static NewInfo GetModel(int id)
        {
            string sql = "select * from T_News where Id=@id";
            NewInfo newInfo = null;
            DataTable dt = SqlHelper.GetTable(sql, CommandType.Text, new SqlParameter("@id", id));
            if(dt.Rows.Count>0)
            {
                DataRow row = dt.Rows[0];
                newInfo=new NewInfo();
                newInfo.Title = row["Title"].ToString();
                newInfo.Msg = row["Msg"].ToString();
                newInfo.Author = row["Author"].ToString();
                newInfo.SubDateTime = Convert.ToDateTime(row["SubDateTime"]);
            }
            return newInfo;
        }
    }
}
