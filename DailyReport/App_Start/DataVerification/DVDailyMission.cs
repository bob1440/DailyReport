using DailyReport.Models;
using DailyReport.Models.Interface;
using DailyReport.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace DailyReport.App_Start.DataVerification
{
    public class DVDailyMission
    {
         private static DVDailyMission _Instance;
        public static DVDailyMission Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new DVDailyMission();
                }
                return _Instance;
            }
            set { _Instance = value; }
        }

        private IRepository<DailyMissionStorage> DailyMissionRepository;

        delegate string getTypeName(int i, List<FKMissionType> t);

        public DVDailyMission()
        {
            this.DailyMissionRepository = new GenericRepository<DailyMissionStorage>();           
        }

        public void CreateDailyMission(DailyMissionStorage DailyMissionRecord)
        {           
            this.DailyMissionRepository.Create(DailyMissionRecord);        
        }

        public List<DailyMissionStorage> GetTodayMission()
        {
         DateTime d2=new DateTime(DateTime.Now.AddDays(1).Year,DateTime.Now.AddDays(1).Month,DateTime.Now.AddDays(1).Day);
         DateTime d1 = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
         List<DailyMissionStorage> result = this.DailyMissionRepository.GetByParm(x => x.CreateTime > d1 && x.CreateTime < d2).ToList();
          List<FKMissionType> t = DVMissionType.Instance.GetAllMissionType();
         //取得標籤名稱的匿名函數
            getTypeName myDelegate = (x, h) =>
            {
                return h.Find(c => c.TypeID == x).Name; 
            };
          foreach (DailyMissionStorage dm in result)
            dm.MissionTypeName = myDelegate(dm.TypeID, t);
         return result;
        }

     

    }
}