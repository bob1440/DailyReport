using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DailyReport.App_Start.ExcelFunc
{
    public class ExcelStyleRender
    {
        private static ExcelStyleRender _Instance;

        public static ExcelStyleRender Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new ExcelStyleRender();
                }
                return _Instance;
            }
            set { _Instance = value; }
        }


        public  ICellStyle GetCellStyles(HSSFWorkbook Hs )
        {
             ICellStyle style1 = Hs.CreateCellStyle();

            style1.BorderTop = BorderStyle.THIN;
            style1.BorderRight = BorderStyle.THIN;
            style1.BorderBottom = BorderStyle.THIN;
            style1.BorderLeft = BorderStyle.THIN;

            style1.LeftBorderColor = 123;

            IFont font1 = Hs.CreateFont();
            //字體大小
            font1.FontHeightInPoints = 24;
            style1.SetFont(font1);

            return style1;
        }

       

    }
}