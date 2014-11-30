using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CMS.BLL;
using CMS.Common;
using CMS.Model;

namespace CMS.WebApp.Controllers
{
    public class LoginController : Controller
    {
        //
        // GET: /Login/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult UserLogin()
        {
            string validateCode = Session["code"] != null ? Session["code"].ToString() : string.Empty;
            if (string.IsNullOrEmpty(validateCode))
            {
                return Content("no:验证码不能为空！");
            }
            Session["code"] = null;
            string txtCode = Request["vCode"];
            if (!validateCode.Equals(txtCode, StringComparison.InvariantCultureIgnoreCase))
            {
                return Content("no:验证码错误！");
            }
            string userName = Request["LoginCode"];
            string userPwd = Request["LoginPwd"];
            UserInfoService userInSe=new UserInfoService();
            UserInfo userInfo=userInSe.GetUserInfo(userName,userPwd);
            if (userInfo != null)
            {
                //nginx服务器和memcache分布式session实现
                Session["userInfo"] = userInfo;
                return Content("ok:登录成功！");
            }
            else
            {
                return Content("no:登录失败！");
            }

        }

        public ActionResult ShowValidateCode()
        {
            ValidateCode vc = new ValidateCode();
            string code = vc.CreateValidateCode(4);
            Session["code"] = code;
            byte[] buffer = vc.CreateValidateGraphic(code);
            return File(buffer,"image/jpeg");
        }

    }
}
