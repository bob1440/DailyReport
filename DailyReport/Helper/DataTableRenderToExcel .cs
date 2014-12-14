using DailyReport.App_Start.ExcelFunc;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;

namespace DailyReport.Helper
{
    public static class DataTableRenderToExcel
    {
        public static Stream ToExcel(this DataTable SourceTable)
        {
            HSSFWorkbook workbook = new HSSFWorkbook();

            ICellStyle style1 = ExcelStyleRender.Instance.GetCellStyles(workbook);

            MemoryStream ms = new MemoryStream();
            ISheet sheet = workbook.CreateSheet();
            IRow headerRow = sheet.CreateRow(0);

            //10000:38.81
            sheet.SetColumnWidth(2, 10000);

            // handling header.
            foreach (DataColumn column in SourceTable.Columns)
            {
                headerRow.CreateCell(column.Ordinal).SetCellValue(column.ColumnName);
                headerRow.GetCell(column.Ordinal).CellStyle = style1;
            }

            // handling value.
            int rowIndex = 1;

            foreach (DataRow row in SourceTable.Rows)
            {
                IRow dataRow = sheet.CreateRow(rowIndex);

                foreach (DataColumn column in SourceTable.Columns)
                {
                    dataRow.CreateCell(column.Ordinal).SetCellValue(row[column].ToString());
                    dataRow.GetCell(column.Ordinal).CellStyle = style1;
                }
                rowIndex++;
            }
           
            workbook.Write(ms);
            ms.Flush();
            ms.Position = 0;

            sheet = null;
            headerRow = null;
            workbook = null;

            return ms;
        }

        static string Quoted(string v)
        {
            return "\"" + v.Replace(@"""", @"""""") + "\"";
        }

        public static Stream ToCSV(this DataTable SourceTable)
        {
            StringBuilder sb = new StringBuilder();
            List<string> l = new List<string>();
            foreach (DataColumn c in SourceTable.Columns)
                l.Add(Quoted(c.ColumnName));
            sb.AppendLine(string.Join(",", l.ToArray()));

            foreach (DataRow row in SourceTable.Rows)
            {
                l.Clear();
                for (int i = 0; i < SourceTable.Columns.Count; i++)
                    l.Add(Quoted(row[i].ToString()));
                sb.AppendLine(string.Join(",=", l.ToArray()));
            }

            MemoryStream ms = new MemoryStream(System.Text.Encoding.UTF8.GetBytes(sb.ToString()));

            return ms;
        }

        public static FileStream ToExcel(this DataTable SourceTable, string FileName)
        {
            MemoryStream ms = ToExcel(SourceTable) as MemoryStream;
            FileStream fs = new FileStream(FileName, FileMode.Create, FileAccess.Write);
            byte[] data = ms.ToArray();

            fs.Write(data, 0, data.Length);
            fs.Flush();
            //fs.Close();
            
            data = null;
            ms = null;
          //  fs = null;
            return fs; 
        }

        public static DataTable RenderDataTableFromExcel(Stream ExcelFileStream, string SheetName, int HeaderRowIndex)
        {
            HSSFWorkbook workbook = new HSSFWorkbook(ExcelFileStream);
            ISheet sheet = workbook.GetSheet(SheetName);

            DataTable table = new DataTable();

            IRow headerRow = sheet.GetRow(HeaderRowIndex);
            int cellCount = headerRow.LastCellNum;

            for (int i = headerRow.FirstCellNum; i < cellCount; i++)
            {
                DataColumn column = new DataColumn(headerRow.GetCell(i).StringCellValue);
                table.Columns.Add(column);
            }

            int rowCount = sheet.LastRowNum;

            for (int i = (sheet.FirstRowNum + 1); i < sheet.LastRowNum; i++)
            {
                IRow row = sheet.GetRow(i);
                DataRow dataRow = table.NewRow();

                for (int j = row.FirstCellNum; j < cellCount; j++)
                    dataRow[j] = row.GetCell(j).ToString();
            }

            ExcelFileStream.Close();
            workbook = null;
            sheet = null;
            return table;
        }

        public static DataTable RenderDataTableFromExcel(Stream ExcelFileStream, int SheetIndex, int HeaderRowIndex)
        {
            HSSFWorkbook workbook = new HSSFWorkbook(ExcelFileStream);
            ISheet sheet = workbook.GetSheetAt(SheetIndex);

            DataTable table = new DataTable();

            IRow headerRow = sheet.GetRow(HeaderRowIndex);
            int cellCount = headerRow.LastCellNum;

            for (int i = headerRow.FirstCellNum; i < cellCount; i++)
            {
                DataColumn column = new DataColumn(headerRow.GetCell(i).StringCellValue);
                table.Columns.Add(column);
            }

            int rowCount = sheet.LastRowNum;

            for (int i = (sheet.FirstRowNum + 1); i <= sheet.LastRowNum; i++)
            {
                IRow row = sheet.GetRow(i);
                DataRow dataRow = table.NewRow();

                for (int j = row.FirstCellNum; j < cellCount; j++)
                {
                    if (row.GetCell(j) != null)
                        dataRow[j] = row.GetCell(j).ToString();
                }

                table.Rows.Add(dataRow);
            }

            ExcelFileStream.Close();
            workbook = null;
            sheet = null;
            return table;
        }

        public static Stream ReWriteDataFromExcel(Stream ExcelFileStream, int SheetIndex, int HeaderRowIndex)
        {
            HSSFWorkbook workbook = new HSSFWorkbook(ExcelFileStream);
            MemoryStream ms = new MemoryStream();
            ISheet sheet = workbook.GetSheetAt(SheetIndex);


            IRow headerRow = sheet.GetRow(HeaderRowIndex);
            int cellCount = headerRow.LastCellNum;


            IRow row = sheet.GetRow(5);
            row.CreateCell(3).SetCellValue(32145);

            workbook.Write(ms);
            ms.Flush();
            ms.Position = 0;

            sheet = null;
            headerRow = null;
            workbook = null;

            return ms;

        }

        //public static Stream ToExcelCus1(this DataTable SourceTable, Dictionary<string, string> ccc, SupRpExcelTittle Tittle)
        //{
        //    HSSFWorkbook workbook = new HSSFWorkbook();
        //    MemoryStream ms = new MemoryStream();
        //    ISheet sheet = workbook.CreateSheet();


        //    //表頭

        //    IRow TittleRow = sheet.CreateRow(1);
        //    TittleRow.CreateCell(1).SetCellValue(Tittle.FirstRow);
        //    TittleRow = sheet.CreateRow(2);
        //    TittleRow.CreateCell(1).SetCellValue(Tittle.SecondRow);
        //    TittleRow = sheet.CreateRow(3);
        //    TittleRow.CreateCell(1).SetCellValue(Tittle.ThirdRow);
        //    TittleRow = sheet.CreateRow(4);
        //    TittleRow.CreateCell(1).SetCellValue(Tittle.FourRow);
        //    TittleRow = sheet.CreateRow(5);
        //    TittleRow.CreateCell(1).SetCellValue(Tittle.FiveRow);

        //    CellRangeAddress region;
        //    for (int i = 0; i < 5; i++)
        //    {
        //        region = new CellRangeAddress(i, i, 1, 6);
        //        sheet.AddMergedRegion(region);
        //    }


        //    // handling value.




        //    //資料表資料
        //    IRow headerRow = sheet.CreateRow(6);

        //    //自己加的欄位  
        //    headerRow.CreateCell(SourceTable.Columns[0].Ordinal).SetCellValue(SourceTable.Columns[0].ColumnName);
        //    headerRow.CreateCell(SourceTable.Columns[1].Ordinal).SetCellValue(SourceTable.Columns[1].ColumnName);


        //    // i起始值為實際產品起始欄位
        //    for (int i = 2; i < SourceTable.Columns.Count; i++)
        //    {
        //        headerRow.CreateCell(SourceTable.Columns[i].Ordinal).SetCellValue(ccc[SourceTable.Columns[i].ColumnName]);
        //        sheet.AutoSizeColumn(i);
        //    }// handling value.
        //    int rowIndex = 7;

        //    foreach (DataRow row in SourceTable.Rows)
        //    {
        //        IRow dataRow = sheet.CreateRow(rowIndex);

        //        foreach (DataColumn column in SourceTable.Columns)
        //        {
        //            dataRow.CreateCell(column.Ordinal).SetCellValue(row[column].ToString());
        //        }

        //        rowIndex++;
        //    }

        //    workbook.Write(ms);
        //    ms.Flush();
        //    ms.Position = 0;

        //    sheet = null;
        //    headerRow = null;
        //    workbook = null;

        //    return ms;
        //}

     
    }
}