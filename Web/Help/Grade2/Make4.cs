using System;
using System.Collections.Generic;

namespace Web.Help.Grade2
{
    public class Make4
    {
        public static string Make4_1_Sev(string selectifKH)
        {
            Random random = new Random();

            bool pass = false;
            List<string> Chars = new List<string>();
            do
            {
                var MainPoint = random.Next(0, 2);
                string[] Maths = new[] { "+", "-" };
                string Maths2 = Maths[random.Next(0, 2)];
                var strTemps = Make4_1(out Chars, null, random);
                var temp = Convert.ToInt32(Chars[0]) * Convert.ToInt32(Chars[2]);
                if (Maths2 == "+")
                {
                    List<string> Part2 = new List<string>();
                    Make3.Make_Plus(out Part2, temp, random);
                    Chars.Add(Part2[1]);
                    Chars.Add(Part2[2]);
                    pass = true;
                }
                else if(Maths2 == "-")
                {
                    List<string> Part2 = new List<string>();
                    Make3.Make_Min(out Part2, temp, random);
                    Chars.Add(Part2[1]);
                    Chars.Add(Part2[2]);
                    pass = true;
                }
            } while (pass == false);
            // 输出结果
            return $"{string.Join(" ", Chars)} = ";
        }

        public static string Make4_1(out List<string> res, int? part1 = null, Random farandom = null)
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
                num1 = 7;
            }
            else
            {
                num1 = (int)part1;
            }
            num2 = random.Next(1, 8);

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

        public static string Make4_2_Sev(string selectifKH)
        {
            Random random = new Random();

            bool pass = false;
            List<string> Chars = new List<string>();
            do
            {
                var MainPoint = random.Next(0, 2);
                string[] Maths = new[] { "+", "-" };
                string Maths2 = Maths[random.Next(0, 2)];
                var strTemps = Make4_2(out Chars, null, random);
                var temp = Convert.ToInt32(Chars[0]) * Convert.ToInt32(Chars[2]);
                if (Maths2 == "+")
                {
                    List<string> Part2 = new List<string>();
                    Make3.Make_Plus(out Part2, temp, random);
                    Chars.Add(Part2[1]);
                    Chars.Add(Part2[2]);
                    pass = true;
                }
                else if(Maths2 == "-")
                {
                    List<string> Part2 = new List<string>();
                    Make3.Make_Min(out Part2, temp, random);
                    Chars.Add(Part2[1]);
                    Chars.Add(Part2[2]);
                    pass = true;
                }
            } while (pass == false);
            // 输出结果
            return $"{string.Join(" ", Chars)} = ";
        }

        public static string Make4_2(out List<string> res, int? part1 = null, Random farandom = null)
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
                num1 = 8;
            }
            else
            {
                num1 = (int)part1;
            }
            num2 = random.Next(1, 9);

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

        public static string Make4_3_Sev(string selectifKH)
        {
            Random random = new Random();

            bool pass = false;
            List<string> Chars = new List<string>();
            do
            {
                var MainPoint = random.Next(0, 2);
                string[] Maths = new[] { "+", "-" };
                string Maths2 = Maths[random.Next(0, 2)];
                var strTemps = Make4_3(out Chars, null, random);
                var temp = Convert.ToInt32(Chars[0]) * Convert.ToInt32(Chars[2]);
                if (Maths2 == "+")
                {
                    List<string> Part2 = new List<string>();
                    Make3.Make_Plus(out Part2, temp, random);
                    Chars.Add(Part2[1]);
                    Chars.Add(Part2[2]);
                    pass = true;
                }
                else if(Maths2 == "-")
                {
                    List<string> Part2 = new List<string>();
                    Make3.Make_Min(out Part2, temp, random);
                    Chars.Add(Part2[1]);
                    Chars.Add(Part2[2]);
                    pass = true;
                }
            } while (pass == false);
            // 输出结果
            return $"{string.Join(" ", Chars)} = ";
        }

        public static string Make4_3(out List<string> res, int? part1 = null, Random farandom = null)
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
                num1 = 9;
            }
            else
            {
                num1 = (int)part1;
            }
            num2 = random.Next(1, 10);

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