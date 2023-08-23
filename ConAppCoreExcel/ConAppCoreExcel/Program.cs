
using NPOI.HSSF.Util;
using NPOI.SS.UserModel;
using NPOI.SS.Util;
using NPOI.XSSF.UserModel;
using System.Collections.Generic;
using System.Reflection;

namespace ConAppCoreExcel
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, Start!");
            WriteExcel("Book1.xlsx");
            Console.WriteLine("Hello, End!");
        }

        static void WriteExcel(String strFileName)
        {
            using (var fs = new FileStream(strFileName, FileMode.Create, FileAccess.Write))
            {
                IWorkbook workbook = new XSSFWorkbook();
                ISheet sheet1 = workbook.CreateSheet("Sheet1");
                int rowIndex = 4;
                IRow row = sheet1.CreateRow(rowIndex);
                row.CreateCell(4).SetCellValue("6");
                sheet1.AutoSizeColumn(0);
                rowIndex++;
                workbook.Write(fs);
            }
        }
    }
}