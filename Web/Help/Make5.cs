using System;
using System.Collections.Generic;

namespace Web.Help
{
    public class Make5
    {
        public static string Make5_1()
        {
            Random random= new Random();

            string[] typeArrays = new[] {"元角","角" };
            var typeIdx = random.Next(0, 2);
            var type = typeArrays[typeIdx];
            int num1 = 0,num2 = 0;
            string operationString = string.Empty;
            if (type == "元角")
            {
                do
                {
                    num1 = random.Next(1, 100);
                    num2 = 0;
                    // 随机选择加法或减法
                    int operation = random.Next(0, 2);
                    operationString = operation == 0 ? "+" : "-";

                    if (operationString == "+")
                    {
                        num2 = random.Next(1, 100 - num1 + 1);
                    }
                    else
                    {
                        num2 = random.Next(1, num1 + 1);
                    }
                } while (num1 == num2);
                string strNum1 = string.Empty, strNum2= string.Empty, Ans=string.Empty;
                if (num1 >= 10)
                {
                    strNum1 += $"{num1 / 10}元";
                }
                if(num1 % 10>0)
                {
                    strNum1 += $"{num1 % 10}角";
                }

                if (num2 >= 10)
                {
                    strNum2 += $"{num2 / 10}元";
                }
                if (num2 % 10 > 0)
                {
                    strNum2 += $"{num2 % 10}角";
                }

                var ansNum = 0;
                if(operationString=="+")
                {
                    ansNum = num1 + num2;
                }
                else
                {
                    ansNum = num1 - num2;
                }

                if (ansNum >= 10)
                {
                    Ans += $"____元";
                }
                if (ansNum % 10 > 0)
                {
                    Ans += $"____角";
                }
                return $"{strNum1}{operationString}{strNum2}={Ans}";
            }
            else
            {
                string[] Maths = new[] { "Make2_2", "Make2_1" };
                var MathsIdx = random.Next(0, 2);
                var Math = Maths[MathsIdx];
                var ansNum = 0;
                string strNum1 = string.Empty, strNum2 = string.Empty, Ans = string.Empty;
                if (Math== "Make2_2")
                {
                    List<string> res = new List<string>();
                    Make2.Make2_2(out res,null, random);
                    num1 = Convert.ToInt32(res[0]);
                    num2 = Convert.ToInt32(res[2]);
                    ansNum = num1 - num2;
                    operationString = res[1];
                }
                else if (Math == "Make2_1")
                {
                    List<string> res = new List<string>();
                    Make2.Make2_1(out res, null, random);
                    num1 = Convert.ToInt32(res[0]);
                    num2 = Convert.ToInt32(res[2]);
                    ansNum= num1 + num2;
                    operationString = res[1];
                }
                if (ansNum >= 10)
                {
                    Ans += $"____元";
                }
                if (ansNum % 10 > 0)
                {
                    Ans += $"____角";
                }

                return $"{num1}角{operationString}{num2}角={Ans}";
            }
        }
    }
}
