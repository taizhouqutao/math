using System;
using System.Collections.Generic;

namespace Web.Help
{
    public class Make1
    {
        public static string Make1_2(out List<string> res, int? part1 = null, Random farandom = null)//10以内的不退位减法
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
            int num1 = 0;
            if (part1 == null)
            {
                num1 = random.Next(1, 11);
            }
            else
            {
                num1 = (int)part1;
            }
            // 生成第一个2位数
            int num2 = random.Next(1, num1 + 1);
            res = new List<string>() { num1.ToString(), "-", num2.ToString() };
            // 输出结果
            return $"{num1} - {num2} = ";
        }

        public static string Make1_2_R(out List<string> res, int num2, Random farandom) //10以内的不退位减法,反向
        {
            //num2 必须大于等于1，小于等于10
            int num1 = farandom.Next(num2, 11);
            res = new List<string>() { num1.ToString(), "-", num2.ToString() };
            // 输出结果
            return $"{num1} - {num2} = ";
        }

        public static string Make1_1(out List<string> res, int? part1 = null, Random farandom = null)//10以内的不进位加法
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
            int num1 = 0;
            if (part1 == null)
            {
                num1 = random.Next(1, 10);
            }
            else
            {
                num1 = (int)part1;
            }
            // 生成第一个2位数
            int num2 = random.Next(1, 10 - num1 + 1);
            res = new List<string>() { num1.ToString(), "+", num2.ToString() };
            // 输出结果
            return $"{num1} + {num2} = ";
        }
    }
}
