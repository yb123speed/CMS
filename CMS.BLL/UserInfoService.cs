using CMS.DAL;
using CMS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.BLL
{
    public class UserInfoService
    {
        public UserInfo GetUserInfo(string userName, string userPwd)
        {
            UserInfoDal uId=new UserInfoDal();
            return uId.GetUserInfo(userName,userPwd);
        }
    }
}
