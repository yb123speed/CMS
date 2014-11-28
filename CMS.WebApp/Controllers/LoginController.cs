using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CMS.Common;

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

        public ActionResult ShowValidateCode()
        {
            Common.ValidateCode vc=new ValidateCode();
            string code = vc.CreateValidateCode(4);
         byte[] buffer=vc.CreateValidateGraphic(code);
            return File(buffer, "image/jpeg");
        }

    }
}
