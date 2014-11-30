using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CMS.Model;

namespace CMS.DAL
{
    public class UserInfoDal
    {
        public UserInfo GetUserInfo(string userName, string userPwd)
       {
           string sql = "select * from T_UserInfo where UserName=@userName and UserPwd=@userPwd";
           SqlParameter[] pms=new SqlParameter[]
           {new SqlParameter("@userName",SqlDbType.NVarChar,32), 
               new SqlParameter("@userPwd",SqlDbType.NVarChar,32) 
           };
            pms[0].Value = userName;
            pms[1].Value = userPwd;
            DataTable dt = SqlHelper.GetTable(sql, CommandType.Text, pms);
            UserInfo userInfo=null;
            if (dt.Rows.Count > 0)
            {
              userInfo=new UserInfo();
              LoadEntity(userInfo,dt.Rows[0]);
            }
            return userInfo;
       }

        private void LoadEntity(UserInfo userInfo, DataRow dataRow)
        {
            userInfo.Id = Convert.ToInt32(dataRow["Id"]);
            userInfo.UserName = Convert.ToString(dataRow["UserName"]);
            userInfo.UserPwd = Convert.ToString(dataRow["UserPwd"]);
            userInfo.UserMail = Convert.ToString(dataRow["UserMail"]);
            userInfo.RegTime = Convert.ToDateTime(dataRow["RegTime"]);
        }
    }
}
