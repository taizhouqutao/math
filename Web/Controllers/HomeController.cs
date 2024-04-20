using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Web.Models;
using System.IO;
using NPOI.XSSF.Streaming;
using NPOI.SS.UserModel;
using Web.Help;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public ActionResult ExportExcel(string selectItem,string itemcount,string selectifMany)
        {
            var Lessons = selectItem.Split(",");
            decimal.TryParse(itemcount, out decimal totalst);
            if (totalst == 0) totalst = 100;
            int total = Convert.ToInt32(Math.Floor(totalst));
            List<string> randomList = new List<string>();
            Random rd = new Random();
            for (int indx = 0; indx < total; indx++)
            {
                List<string> OutArray = new List<string>();
                var indexKey = rd.Next(0, Lessons.Count());
                var unit = Lessons[indexKey];
                if (unit == "6.1")
                {
                    int chlimit = 0;
                    if (!string.IsNullOrEmpty(selectifMany))
                    {
                        chlimit = indx % 5;
                    }
                    var Chars = (chlimit == 3 || chlimit == 4) ? Make6.Make6_1_Sev() : Make6.Make6_1(out OutArray);
                    randomList.Add(Chars);
                }
                else if (unit == "6.2")
                {
                    int chlimit = 0;
                    if (!string.IsNullOrEmpty(selectifMany))
                    {
                        chlimit = indx % 5;
                    }
                    var Chars = (chlimit == 3 || chlimit == 4) ? Make6.Make6_2_Sev() : Make6.Make6_2(out OutArray);
                    randomList.Add(Chars);
                }
                else if (unit == "6.3")
                {
                    int chlimit = 0;
                    if (!string.IsNullOrEmpty(selectifMany))
                    {
                        chlimit = indx % 5;
                    }
                    var Chars = (chlimit == 3 || chlimit == 4) ? Make6.Make6_3_Sev() : Make6.Make6_3(out OutArray);
                    randomList.Add(Chars);
                }
                else if (unit == "2.2")
                {
                    int chlimit = 0;
                    if (!string.IsNullOrEmpty(selectifMany))
                    {
                        chlimit = indx % 5;
                    }
                    var Chars = (chlimit == 3 || chlimit == 4) ? Make2.Make2_2_Sev() : Make2.Make2_2(out OutArray);
                    randomList.Add(Chars);
                }
                else if (unit == "2.1")
                {
                    int chlimit = 0;
                    if (!string.IsNullOrEmpty(selectifMany))
                    {
                        chlimit = indx % 5;
                    }
                    var Chars = (chlimit == 3 || chlimit == 4) ? Make2.Make2_1_Sev() : Make2.Make2_1(out OutArray);
                    randomList.Add(Chars);
                }
            }
            SXSSFWorkbook book = new SXSSFWorkbook();
            ISheet sheet1 = book.CreateSheet("Sheet1");
            int i = 0;int rowIdx = 0;
            do
            {
                IRow row;
                if (i==0)
                {
                    row = sheet1.CreateRow(rowIdx);
                }
                else
                {
                    row = sheet1.GetRow(rowIdx);
                }
                ICellStyle cellStyle = book.CreateCellStyle();
                IFont font = book.CreateFont();
                font.FontHeightInPoints = 14; // 设置字体大小，单位为点
                cellStyle.SetFont(font);

                row.Height = 600;

                var cell = row.CreateCell(i * 2);
                var cellValue = randomList[0];
                if (!string.IsNullOrEmpty(selectifMany))
                {
                    cellValue = cellValue.Replace(" ", "");
                }
                cell.SetCellValue(cellValue);
                cell.CellStyle = cellStyle;
                var cellAns = row.CreateCell(i * 2+1);
                int Width = 2400;
                if (!string.IsNullOrEmpty(selectifMany))
                {
                    if(i==3||i==4)
                    {
                        Width = 2850;
                    }
                    else
                    {
                        Width = 2100;
                    }
                }
                sheet1.SetColumnWidth(i * 2 + 1, Width);
                cellAns.CellStyle = cellStyle;
                i = i + 1;
                if(i==5)
                {
                    i = 0;
                    rowIdx = rowIdx + 1;
                }
                randomList.RemoveAt(0);
            } while (randomList.Count > 0);

            var ms = new NpoiMemoryStream();
            ms.AllowClose = false;
            book.Write(ms);
            ms.Seek(0, SeekOrigin.Begin);
            ms.AllowClose = true;
            return File(ms, "application/vnd.ms-excel","口算题.xls"); 
        }

        public static List<T> GetRandomSubset<T>(List<T> source, int n)
        {
            if (n > source.Count)
                throw new ArgumentException("n must be less than or equal to the length of the source list.");

            Random random = new Random();
            return source.OrderBy(x => random.Next()).Take(n).ToList();
        }

        public class NpoiMemoryStream: MemoryStream
        {
            public NpoiMemoryStream()
            {
                AllowClose = true;
            }

            public bool AllowClose { get; set; }

            public override void Close()
            {
                if(AllowClose)
                {
                    base.Close();
                }
            }
        }
    }
}
