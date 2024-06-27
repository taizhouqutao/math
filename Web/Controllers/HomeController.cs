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

        public ActionResult ExportExcel(string selectItem,string itemcount,string selectifMany,string selectifKH)
        {
            if(string.IsNullOrEmpty(selectItem)){
                return RedirectToAction("Index");
            }
            var Lessons = selectItem.Split(",");
            var clientIp = HttpContext.Connection.RemoteIpAddress.ToString();
            var guid = Guid.NewGuid().ToString();
            Console.WriteLine($"1:IP:{clientIp} Request:{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")} Guid:{guid}");
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
                    var Chars = (chlimit == 3 || chlimit == 4) ? Help.Grade1.Make6.Make6_1_Sev(selectifKH) : Help.Grade1.Make6.Make6_1(out OutArray);
                    randomList.Add(Chars);
                }
                else if (unit == "6.2")
                {
                    int chlimit = 0;
                    if (!string.IsNullOrEmpty(selectifMany))
                    {
                        chlimit = indx % 5;
                    }
                    var Chars = (chlimit == 3 || chlimit == 4) ? Help.Grade1.Make6.Make6_2_Sev(selectifKH) : Help.Grade1.Make6.Make6_2(out OutArray);
                    randomList.Add(Chars);
                }
                else if (unit == "6.3")
                {
                    int chlimit = 0;
                    if (!string.IsNullOrEmpty(selectifMany))
                    {
                        chlimit = indx % 5;
                    }
                    var Chars = (chlimit == 3 || chlimit == 4) ? Help.Grade1.Make6.Make6_3_Sev(selectifKH) : Help.Grade1.Make6.Make6_3(out OutArray);
                    randomList.Add(Chars);
                }
                else if (unit == "2.2")
                {
                    int chlimit = 0;
                    if (!string.IsNullOrEmpty(selectifMany))
                    {
                        chlimit = indx % 5;
                    }
                    var Chars = (chlimit == 3 || chlimit == 4) ? Help.Grade1.Make2.Make2_2_Sev(selectifKH) : Help.Grade1.Make2.Make2_2(out OutArray);
                    randomList.Add(Chars);
                }
                else if (unit == "2.1")
                {
                    int chlimit = 0;
                    if (!string.IsNullOrEmpty(selectifMany))
                    {
                        chlimit = indx % 5;
                    }
                    var Chars = (chlimit == 3 || chlimit == 4) ? Help.Grade1.Make2.Make2_1_Sev(selectifKH) : Help.Grade1.Make2.Make2_1(out OutArray);
                    randomList.Add(Chars);
                }
                else if(unit=="5.1")
                {
                    var Chars = Help.Grade1.Make5.Make5_1();
                    randomList.Add(Chars);
                }
            }
            Console.WriteLine($"2:IP:{clientIp} Make:{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")} Guid:{guid}");
            var ms = MakeFile.GetFileStream(Lessons,randomList,selectifMany);
            Console.WriteLine($"3:IP:{clientIp} OutPut:{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")} Guid:{guid}");
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
