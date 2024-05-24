using System;
using System.Collections.Generic;

namespace Web.Help.Grade2
{
    public class Make3
    {
        public static string Make3_1_Sev(string selectifKH)
        {
            Random random = new Random();

            bool pass = false;
            List<string> Chars = new List<string>();
            do
            {
                var MainPoint = random.Next(0, 2);
                string[] Maths = new[] { "+", "-" };
                string Maths2 = Maths[random.Next(0, 2)];
                var strTemps = Make3_1(out Chars, null, random);
                var temp = Convert.ToInt32(Chars[0]) * Convert.ToInt32(Chars[2]);
                if (Maths2 == "+")
                {
                    
                }
                else if(Maths2 == "-")
                {

                }
            } while (pass == false);
            // 输出结果
            return $"{string.Join(" ", Chars)} = ";
        }

        public static string Make3_1(out List<string> res, int? part1 = null, Random farandom = null)
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
                num1 = 5;
            }
            else
            {
                num1 = (int)part1;
            }
            num2 = random.Next(1, 6);

            var opt = random.Next(0, 2);
            if (opt == 1 && farandom == null)
            {
                var temp = num1;
                num1 = num2;
                num2 = temp;
            }

            res = new List<string>() { num1.ToString(), "×", num2.ToString() };
            // 输出结果
            return $"{num1} × {num2} = ";
        }
    }
}