using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Web.Help.Grade2
{
    public class Make6
    {
        public static string Make6_1(out List<string> res, int? part1 = null, Random farandom = null) 
        {
            Random random;
            if (farandom == null)
            {
                random = new Random();
            }
            else
            {
                random = farandom;
            }
            int num1 = 0,num2=0;
            if (part1 == null)
            {
                var ch1 = random.Next(2, 10);
                num2  = random.Next(2, 10);
                var yushu = random.Next(1, num2);
                num1 = ch1*num2+yushu;
            }
            else
            {
                num1 = (int)part1;
                do{
                    num2=random.Next(1, 10);
                }while(num1%num2==0||(num1/num2)>9);
            }
            res = new List<string>() { num1.ToString(), "÷", num2.ToString() };
            // 输出结果
            return $"{num1} ÷ {num2} = ";
        }
    }
}

