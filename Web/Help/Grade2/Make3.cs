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
                    List<string> Part2 = new List<string>();
                    Make_Plus(out Part2, temp, random);
                    Chars.Add(Part2[1]);
                    Chars.Add(Part2[2]);
                    pass = true;
                }
                else if(Maths2 == "-")
                {
                    List<string> Part2 = new List<string>();
                    Make_Min(out Part2, temp, random);
                    Chars.Add(Part2[1]);
                    Chars.Add(Part2[2]);
                    pass = true;
                }
            } while (pass == false);
            // 输出结果
            return $"{string.Join(" ", Chars)} = ";
        }

        public static string Make_Plus(out List<string> res, int part1, Random farandom)
        {
            int num2 = farandom.Next(1, 100-part1+1);
            res = new List<string>() { part1.ToString(), "+", num2.ToString() };
            // 输出结果
            return $"{part1} + {num2} = ";
        }

        public static string Make_Min(out List<string> res, int part1, Random farandom)
        {
            int num2 = farandom.Next(1, part1+1);
            res = new List<string>() { part1.ToString(), "-", num2.ToString() };
            // 输出结果
            return $"{part1} - {num2} = ";
        }

        public static string Make3_1(out List<string> res, int? part1 = null, Random farandom = null) //表内乘法（一）5的乘法口诀
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
            if (opt == 1)
            {
                var temp = num1;
                num1 = num2;
                num2 = temp;
            }

            res = new List<string>() { num1.ToString(), "×", num2.ToString() };
            // 输出结果
            return $"{num1} × {num2} = ";
        }

        public static string Make3_2(out List<string> res, int? part1 = null, Random farandom = null) //表内乘法（一）2、3、4的乘法口诀
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
                num1 = random.Next(1, 5);
            }
            else
            {
                num1 = (int)part1;
            }
            num2 = random.Next(1, 5);
            res = new List<string>() { num1.ToString(), "×", num2.ToString() };
            // 输出结果
            return $"{num1} × {num2} = ";
        }

        public static string Make3_2_Sev(string selectifKH)
        {
            Random random = new Random();

            bool pass = false;
            List<string> Chars = new List<string>();
            do
            {
                var MainPoint = random.Next(0, 2);
                string[] Maths = new[] { "+", "-" };
                string Maths2 = Maths[random.Next(0, 2)];
                var strTemps = Make3_2(out Chars, null, random);
                var temp = Convert.ToInt32(Chars[0]) * Convert.ToInt32(Chars[2]);
                if (Maths2 == "+")
                {
                    List<string> Part2 = new List<string>();
                    Make_Plus(out Part2, temp, random);
                    Chars.Add(Part2[1]);
                    Chars.Add(Part2[2]);
                    pass = true;
                }
                else if(Maths2 == "-")
                {
                    List<string> Part2 = new List<string>();
                    Make_Min(out Part2, temp, random);
                    Chars.Add(Part2[1]);
                    Chars.Add(Part2[2]);
                    pass = true;
                }
            } while (pass == false);
            // 输出结果
            return $"{string.Join(" ", Chars)} = ";
        }

        public static string Make3_3(out List<string> res, int? part1 = null, Random farandom = null) //表内乘法（一）6的乘法口诀
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
                num1 = 6;
            }
            else
            {
                num1 = (int)part1;
            }
            num2 = random.Next(1, 7);

            var opt = random.Next(0, 2);
            if (opt == 1)
            {
                var temp = num1;
                num1 = num2;
                num2 = temp;
            }

            res = new List<string>() { num1.ToString(), "×", num2.ToString() };
            // 输出结果
            return $"{num1} × {num2} = ";
        }

        public static string Make3_3_Sev(string selectifKH)
        {
            Random random = new Random();

            bool pass = false;
            List<string> Chars = new List<string>();
            do
            {
                var MainPoint = random.Next(0, 2);
                string[] Maths = new[] { "+", "-" };
                string Maths2 = Maths[random.Next(0, 2)];
                var strTemps = Make3_3(out Chars, null, random);
                var temp = Convert.ToInt32(Chars[0]) * Convert.ToInt32(Chars[2]);
                if (Maths2 == "+")
                {
                    List<string> Part2 = new List<string>();
                    Make_Plus(out Part2, temp, random);
                    Chars.Add(Part2[1]);
                    Chars.Add(Part2[2]);
                    pass = true;
                }
                else if(Maths2 == "-")
                {
                    List<string> Part2 = new List<string>();
                    Make_Min(out Part2, temp, random);
                    Chars.Add(Part2[1]);
                    Chars.Add(Part2[2]);
                    pass = true;
                }
            } while (pass == false);
            // 输出结果
            return $"{string.Join(" ", Chars)} = ";
        }

    }
}