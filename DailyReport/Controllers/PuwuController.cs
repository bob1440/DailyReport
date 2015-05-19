using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DailyReport.Helper;



namespace DailyReport.Controllers
{
    public class PuwuController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Blog()
        {

            return View();

        }


        public ActionResult test()
        {
            DataTable TB = new DataTable();

            for(int i=0;i<6;i++)
             TB.Columns.Add("A"+i.ToString());
            for (int i = 0; i < 10; i++)
               TB.Rows.Add("1111", "2222", "3333", "4444", "5555", "6666"); 
         
           


             return new FileStreamResult(TB.ToExcel(), "application/vnd.ms-excel");
        }

       
    }
    
}