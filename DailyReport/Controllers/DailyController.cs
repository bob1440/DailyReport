using DailyReport.App_Start.DataVerification;
using DailyReport.Models;
using DailyReport.Models.ViewModel;
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
           VMDailyReportMain rm = new VMDailyReportMain();
      
           rm.getData.MissionTypes=DVMissionType.Instance.GetAllMissionType();
           rm.getData.TodayMission = DVDailyMission.Instance.GetTodayMission();
           return View(rm);
        }

        [HttpPost]
        public ActionResult Index(string mission_tittle, int typeid, float spenttime)
        {

            DailyMissionStorage dm = new DailyMissionStorage();
            dm.UserID = 1;
            dm.MissionTitle = dm.MissionDes = mission_tittle;
            dm.TypeID = typeid;
            dm.SpendTime = (decimal) spenttime;
            dm.CreateTime = DateTime.Now;

            DVDailyMission.Instance.CreateDailyMission(dm);


            VMDailyReportMain rm = new VMDailyReportMain();
            rm.getData.MissionTypes = DVMissionType.Instance.GetAllMissionType();
            rm.getData.TodayMission = DVDailyMission.Instance.GetTodayMission();
                 

            return View(rm);
        }
    }
}