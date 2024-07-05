using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Web.Help.Grade2
{
    public class Make7
    {
        public static string Make7_1(out List<string> res) 
        {
            Random random=new Random();
            int num1 = 0,num2=0;
            List<string> MathTypes=new List<string>(){"-","+"};
            var MathType =MathTypes[random.Next(0,2)];
            List<string> ZeroTypes=new List<string>(){"00","000"};
            var ZeroType =ZeroTypes[random.Next(0,2)];
            if(MathType=="-")
            {
              if(ZeroType=="00")
              {
                num1=random.Next(2,100);
                num2=random.Next(1,num1);
                num1=num1*100;
                num2=num2*100;
              }
              else
              {
                num1=random.Next(2,10);
                num2=random.Next(1,num1);
                num1=num1*1000;
                num2=num2*1000;
              }
            }
            else
            {
              if(ZeroType=="00")
              {
                num1=random.Next(1,100);
                num2=random.Next(1,100-num1+1);
                num1=num1*100;
                num2=num2*100;
              }
              else
              {
                num1=random.Next(1,10);
                num2=random.Next(1,10-num1+1);
                num1=num1*1000;
                num2=num2*1000;
              }
            }
            res = new List<string>() { num1.ToString(), MathType, num2.ToString() };
            // 输出结果
            return $"{num1} {MathType} {num2} = ";
        }
    }
}