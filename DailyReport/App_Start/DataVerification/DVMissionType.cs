using DailyReport.Models;
using DailyReport.Models.Interface;
using DailyReport.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DailyReport.App_Start.DataVerification
{
    public class DVMissionType
    {

        private static DVMissionType _Instance;
        public static DVMissionType Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new DVMissionType();
                }
                return _Instance;
            }
            set { _Instance = value; }
        }

        private IRepository<FKMissionType> MissiontypeRepository;     

         public DVMissionType()
        {
            this.MissiontypeRepository = new GenericRepository<FKMissionType>();           
        }


        public List<FKMissionType> GetAllMissionType()
         {
             return this.MissiontypeRepository.GetAll().ToList();         
         }


    }
}