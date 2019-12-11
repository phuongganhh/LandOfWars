using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace PA.Ultilities
{
    public static class ExcelManager
    {
        public static IWorkbook CreateWorkbook()
        {
            return new XSSFWorkbook();
        }


        public static ISheet CreateSheet(IWorkbook wb, string sheetName, IList<string> columnNames)
        {
            return wb.CreateSheet(sheetName);
        }

        public static void ProcessSheet(ISheet sheet, IDataReader reader, Func<IDictionary<string, string>> getColumnHeaders, Action<IDictionary<string, object>> action)
        {
            var columnHeaders = getColumnHeaders();
            if (sheet.PhysicalNumberOfRows < 1)
            {
                var cellIndex = 0;
                IRow rowHeader = sheet.CreateRow(sheet.PhysicalNumberOfRows);
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    try
                    {
                        var ColumnName = columnHeaders[reader.GetName(i).ToString()];
                        rowHeader.CreateCell(cellIndex).SetCellValue(ColumnName);
                        cellIndex++;
                    }
                    catch (Exception)
                    {
                        //there isn't any table column match with header column
                    }
                }
            } 
            Dictionary<string, object> dict = new Dictionary<string, object>();
            for (int i = 0; i < reader.FieldCount; i++)
            {
                try
                {
                    var ColumnName = columnHeaders[reader.GetName(i).ToString()];
                    dict.Add(reader.GetName(i), reader.GetValue(i));
                }
                catch (Exception)
                {
                    //there isn't any table column match with header column
                }
            }
            action(dict);
            IRow row = sheet.CreateRow(sheet.PhysicalNumberOfRows);
            var index = 0;
            foreach (var key in dict.Keys)
            {
                row.CreateCell(index).SetCellValue(dict[key].ToString());
                sheet.AutoSizeColumn(index);
                index++;
            }
        }

        public static ActionResult DownloadWorkbook(IWorkbook wb, string fileName, Func<byte[], string, string, FileResult> file)
        {
            fileName += ".xlsx";
            using (var ms = new MemoryStream())
            {
                wb.Write(ms);
                return file(ms.ToArray(), System.Net.Mime.MediaTypeNames.Application.Octet, fileName);
            }
        }
    }
}
