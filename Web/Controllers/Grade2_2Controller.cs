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
    public class  Grade2_2Controller: Controller
    {
        public IActionResult Index()
        {
            return View();
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
                if (unit == "2.1")
                {
                    int chlimit = 0;
                    if (!string.IsNullOrEmpty(selectifMany))
                    {
                        chlimit = indx % 5;
                    }
                    var Chars = (chlimit == 3 || chlimit == 4) ? Help.Grade2.Make22.Make2_1_Sev(selectifKH) : Help.Grade2.Make22.Make2_1(out OutArray);
                    randomList.Add(Chars);
                }
                else if (unit == "4.1")
                {
                    int chlimit = 0;
                    if (!string.IsNullOrEmpty(selectifMany))
                    {
                        chlimit = indx % 5;
                    }
                    var Chars = (chlimit == 3 || chlimit == 4) ? Help.Grade2.Make22.Make4_1_Sev(selectifKH) : Help.Grade2.Make22.Make4_1(out OutArray);
                    randomList.Add(Chars);
                }
                else if (unit == "5.1.2")
                {
                    var Chars = Help.Grade2.Make22.Make4_1_Sev(selectifKH);
                    randomList.Add(Chars);
                }
            }
            Console.WriteLine($"2:IP:{clientIp} Make:{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")} Guid:{guid}");
            var ms = MakeFile.GetFileStream(Lessons,randomList,selectifMany);
            Console.WriteLine($"3:IP:{clientIp} OutPut:{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")} Guid:{guid}");
            return File(ms, "application/vnd.ms-excel","口算题.xls"); 
        }
    }
}