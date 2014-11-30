using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CMS.BLL;
using CMS.Model;

namespace CMS.WebApp.Controllers
{
    public class AdminNewListController : Controller
    {
        //
        // GET: /AdminNewList/
        NewInfoService newInfoService = new NewInfoService();
        #region 分页列表
        public ActionResult Index()
        {
            int pageIndex = Request["pageIndex"] == null ? 1 : int.Parse(Request["pageIndex"]);
            int pageSize = 10;
            int pageCount = newInfoService.GetPageCount(pageSize);
            pageIndex = pageIndex < 1 ? 1 : pageIndex;
            pageIndex = pageIndex > pageCount ? pageCount : pageIndex;
            List<NewInfo> list = newInfoService.GetPageList(pageIndex, pageSize);//获取分页数据
            ViewData["list"] = list;
            ViewData["pageIndex"] = pageIndex;
            ViewData["pageCount"] = pageCount;
            return View();
        }
        #endregion

        #region 获取详细信息
        public ActionResult GetNewInfoModel()
        {
            int id = int.Parse(Request["Id"]);
            NewInfo newInfo = NewInfoService.GetModel(id);
            return Json(newInfo,JsonRequestBehavior.AllowGet);
        }
        #endregion
    }
}
