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

        public ActionResult ExportExcel(string selectItem,string itemcount)
        {
            var Lessons = selectItem.Split(",");
            decimal.TryParse(itemcount, out decimal totalst);
            if (totalst == 0) totalst = 100;
            int total = Convert.ToInt32(Math.Floor(totalst));
            List<string> randomList = new List<string>();
            Random rd = new Random();
            for (int indx = 0; indx < total; indx++)
            {
                var indexKey = rd.Next(0, Lessons.Count());
                var unit = Lessons[indexKey];
                if (unit == "6.1")
                {
                    var Chars = Make6_1();
                    randomList.Add(Chars);
                }
                else if (unit == "6.2")
                {
                    var Chars = Make6_2();
                    randomList.Add(Chars);
                }
                else if (unit == "6.3")
                {
                    var Chars = Make6_3();
                    randomList.Add(Chars);
                }
                else if (unit == "2.2")
                {
                    var Chars = Make2_2();
                    randomList.Add(Chars);
                }
                else if (unit == "2.1")
                {
                    var Chars = Make2_1();
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
                cell.SetCellValue(randomList[0]);
                cell.CellStyle = cellStyle;
                var cellAns = row.CreateCell(i * 2+1);
                sheet1.SetColumnWidth(i * 2 + 1, 2400);
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

        public string Make6_1() //整十数加减整十数
        {
            Random random = new Random();

            // 随机选择加法或减法
            int operation = random.Next(0, 2);
            string operationString = operation == 0 ? "+" : "-";

            // 生成第一个随机整十数
            int num1 = random.Next(1, 10);

            // 生成第二个随机整十数，确保它不等于第一个数
            int num2;
            int next = 0;
            if (operationString == "-")
            {
                next = num1 + 1;
            }
            else
            {
                next = 10 - num1 + 1;
            }
            num2 = random.Next(1, next);

            // 输出结果
            return $"{num1 * 10} {operationString} {num2 * 10} = ";
        }

        public string Make6_2() //两位数加一位数、整十数
        {
            Random random = new Random();

            // 两位数加一位数、整十数
            int operation = random.Next(0, 2);

            // 生成第一个2位数
            int num1 = 0;

            int num2;
            int next = 0;
            if (operation == 0) //两位数加一位数
            {
                // 生成第一个2位数
                num1 = random.Next(10, 100);
                next = 100 - num1 + 1;
                if (next > 10) { next = 10; }
                num2 = random.Next(1, next);

                var opt = random.Next(0, 2);
                if (opt == 1)
                {
                    var temp = num1;
                    num1 = num2;
                    num2 = temp;
                }
            }
            else //两位数加整十数
            {
                num1 = random.Next(10, 91);
                var num1_ten = Convert.ToInt32(Math.Ceiling(num1 * 1.0 / 10));
                next = 10 - num1_ten + 1;
                num2 = random.Next(1, next) * 10;

                var opt = random.Next(0, 2);
                if (opt == 1)
                {
                    var temp = num1;
                    num1 = num2;
                    num2 = temp;
                }
            }
            // 输出结果
            return $"{num1} + {num2} = ";
        }

        public string Make6_3() //两位数减一位数、整十数
        {
            Random random = new Random();
            // 随机选择加法或减法
            int operation = random.Next(0, 2);

            // 生成第一个2位数
            int num1 = random.Next(10, 100);

            int num2;
            int next = 0;
            if (operation == 0) //两位数减一位数
            {
                next = num1 + 1;
                if (next > 10) { next = 10; }
                num2 = random.Next(1, next);
            }
            else //两位数减整十数
            {
                var num1_ten = num1 / 10;
                next = num1_ten + 1;
                num2 = random.Next(1, next) * 10;
            }

            // 输出结果
            return $"{num1} - {num2} = ";
        }

        public string Make2_2() //20以内的退位减法
        {
            Random random = new Random();

            int num1 = random.Next(11, 19);

            int num1Last = num1 - 10;

            // 生成第一个2位数
            int num2 = random.Next(num1Last + 1, 10);

            // 输出结果
            return $"{num1} - {num2} = ";
        }

        public string Make2_1() //20以内的进位加法
        {
            Random random = new Random();

            int total = random.Next(11, 19);

            int num1Last = total - 10;

            // 生成第一个2位数
            int num2 = random.Next(num1Last + 1, 10);

            var num1 = total - num2;

            var opt = random.Next(0, 2);
            if (opt == 1)
            {
                var temp = num1;
                num1 = num2;
                num2 = temp;
            }

            // 输出结果
            return $"{num1} + {num2} = ";
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
