using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DailyReport.Controllers
{
    public class DailyController : Controller
    {
        //
        // GET: /Daily/
        public ActionResult Index()
        {
            Response.Write("Get:");
            return View();
        }

        [HttpPost]
        public ActionResult Index(string mission_tittle)
        {
            Response.Write("Post:");
            Response.Write("P1:" + mission_tittle + "<br>");
            Response.Write("P[0]:" + Request.Form[0] + "<br>");
            Response.Write("P[1]:" + Request.Form[1] + "<br>");

            Response.Write("sum:" + Request.Form.Count);

            return View();
        }
    }
}