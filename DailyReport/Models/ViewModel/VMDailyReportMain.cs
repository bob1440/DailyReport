using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DailyReport.Models.ViewModel
{
    public class VMDailyReportMain : VMBase
    {
        private GetData _GetC;
         public  GetData getData
         { 
             get
             {
                 if (_GetC == null) _GetC = new GetData();
                 return _GetC;
             }
             set 
             {
                 _GetC = value;
             }         
         }

         private  PostData _PostC;
         public PostData postData
         {
             get
             {
                 if (_PostC == null)  _PostC = new PostData();
                 return _PostC;
             }
             set
             {
                 _PostC = value;
             }

         }

        public class GetData 
        {
              public List<FKMissionType> MissionTypes { get; set; }
              public List<DailyMissionStorage> TodayMission { get; set; }
        
        }
        public class PostData 
        {
           
        }

        
        
    }
}