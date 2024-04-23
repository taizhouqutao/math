using System;
using System.Collections.Generic;

namespace Web.Help
{
    public class Make2
    {
        public static string Make2_2(out List<string> res, int? part1 = null, Random farandom = null) //20以内的退位减法
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
                num1 = random.Next(11, 19);
            }
            else
            {
                num1 = (int)part1;
            }

            int num1Last = num1 - 10;

            // 生成第一个2位数
            int num2 = random.Next(num1Last + 1, 10);

            res = new List<string>() { num1.ToString(), "-", num2.ToString() };
            // 输出结果
            return $"{num1} - {num2} = ";
        }

        public static string Make2_2_R(out List<string> res, int num2, Random farandom) //20以内的退位减法,反向
        {
            //num2 必须大于等于2，小于等于9
            int num1 = farandom.Next(11, 10 + num2);
            res = new List<string>() { num1.ToString(), "-", num2.ToString() };
            // 输出结果
            return $"{num1} - {num2} = ";
        }

        public static string Make2_2_Sev(string selectifKH)//20以内的退位减法,连式
        {
            Random random = new Random();

            bool pass = false;
            List<string> Chars = new List<string>();
            int ifHasKH=0;
            if(!string.IsNullOrEmpty(selectifKH))
            {
                ifHasKH = random.Next(0, 2);
            }
            do
            {
                var MainPoint = random.Next(0, 2);
                string[] Maths = new[] { "Make2_1", "Make2_2" };
                string Maths1 = string.Empty, Maths2 = string.Empty;
                if (MainPoint == 0)
                {
                    Maths1 = "Make2_2";
                    Maths2 = Maths[random.Next(0, 2)];
                }
                else
                {
                    Maths1 = Maths[random.Next(0, 2)];
                    Maths2 = "Make2_2";
                }
                int temp = 0;

                if (Maths1 == "Make2_1") //第一个方法是 20以内的进位加法
                {
                    var strTemps = Make2_1(out Chars, null, random);
                    temp = Convert.ToInt32(Chars[0]) + Convert.ToInt32(Chars[2]);
                }
                else if (Maths1 == "Make2_2")//第一个方法是
                {
                    var strTemps = Make2_2(out Chars, null, random);
                    temp = Convert.ToInt32(Chars[0]) - Convert.ToInt32(Chars[2]);
                }

                if(ifHasKH==1)//有括号
                {
                    if (Maths2 == "Make2_1")
                    {
                        if (temp < 2 || temp >= 10)
                        {
                            Chars.Clear();
                            continue;
                        }
                        else
                        {
                            List<string> Part2 = new List<string>();
                            Make2_1(out Part2, temp, random);
                            Chars.Insert(0, Part2[2]);
                            Chars.Insert(1, Part2[1]);
                            Chars.Insert(2, "(");
                            Chars.Insert(Chars.Count, ")");
                            pass = true;
                        }
                    }
                    else if (Maths2 == "Make2_2")
                    {
                        if (temp < 2 || temp >= 10)
                        {
                            Chars.Clear();
                            continue;
                        }
                        else
                        {
                            List<string> Part2 = new List<string>();
                            Make2_2_R(out Part2, temp, random);
                            Chars.Insert(0, Part2[0]);
                            Chars.Insert(1, Part2[1]);
                            Chars.Insert(2, "(");
                            Chars.Insert(Chars.Count, ")");
                            pass = true;
                        }
                    }
                }
                else
                {
                    if (Maths2 == "Make2_1")
                    {
                        if (temp < 2 || temp >= 10)
                        {
                            Chars.Clear();
                            continue;
                        }
                        else
                        {
                            List<string> Part2 = new List<string>();
                            Make2_1(out Part2, temp, random);
                            Chars.Add(Part2[1]);
                            Chars.Add(Part2[2]);
                            pass = true;
                        }
                    }
                    else if (Maths2 == "Make2_2")
                    {
                        if (temp < 11 || temp >= 19)
                        {
                            Chars.Clear();
                            continue;
                        }
                        else
                        {
                            List<string> Part2 = new List<string>();
                            Make2_2(out Part2, temp, random);
                            Chars.Add(Part2[1]);
                            Chars.Add(Part2[2]);
                            pass = true;
                        }
                    }
                }
            } while (pass == false);
            // 输出结果
            return $"{string.Join(" ", Chars)} = ";
        }

        public static string Make2_1(out List<string> res, int? part1 = null, Random farandom = null) //20以内的进位加法
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
                num1 = random.Next(2, 10);
            }
            else
            {
                num1 = (int)part1;
            }
            // 生成第一个2位数
            int num2 = random.Next(10 - num1 + 1, 10);

            var opt = random.Next(0, 2);
            if (opt == 1 && farandom == null)
            {
                var temp = num1;
                num1 = num2;
                num2 = temp;
            }
            res = new List<string>() { num1.ToString(), "+", num2.ToString() };
            // 输出结果
            return $"{num1} + {num2} = ";
        }

        public static string Make2_1_Sev(string selectifKH)//20以内的进位加法，连式
        {
            Random random = new Random();

            bool pass = false;
            List<string> Chars = new List<string>();
            int ifHasKH = 0;
            if (!string.IsNullOrEmpty(selectifKH))
            {
                ifHasKH = random.Next(0, 2);
            }
            do
            {
                int temp = 0;
                var MainPoint = random.Next(0, 2);
                string[] Maths = new[] { "Make1_2", "Make1_1", "Make2_1" };
                string Maths1 = string.Empty, Maths2 = string.Empty;
                if (MainPoint == 0)
                {
                    Maths1 = "Make2_1";
                    Maths2 = Maths[random.Next(0, 3)];
                }
                else
                {
                    Maths1 = Maths[random.Next(0, 3)];
                    Maths2 = "Make2_1";
                }

                if (Maths1 == "Make2_1") //第一个方法是 20以内的进位加法
                {
                    var strTemps = Make2_1(out Chars, null, random);
                    temp = Convert.ToInt32(Chars[0]) + Convert.ToInt32(Chars[2]);
                }
                else if (Maths1 == "Make1_1")
                {
                    var strTemps = Make1.Make1_1(out Chars, null, random);
                    temp = Convert.ToInt32(Chars[0]) + Convert.ToInt32(Chars[2]);
                }
                else if (Maths1 == "Make1_2")
                {
                    var strTemps = Make1.Make1_2(out Chars, null, random);
                    temp = Convert.ToInt32(Chars[0]) - Convert.ToInt32(Chars[2]);
                }

                if (ifHasKH == 1)
                {
                    if (Maths2 == "Make2_1")
                    {
                        if (temp < 2 || temp >= 10)
                        {
                            Chars.Clear();
                            continue;
                        }
                        else
                        {
                            List<string> Part2 = new List<string>();
                            Make2_1(out Part2, temp, random);
                            Chars.Insert(0, Part2[2]);
                            Chars.Insert(1, Part2[1]);
                            Chars.Insert(2, "(");
                            Chars.Insert(Chars.Count, ")");
                            pass = true;
                        }
                    }
                    else if (Maths2 == "Make1_1")
                    {
                        if (temp < 1 || temp >= 10)
                        {
                            Chars.Clear();
                            continue;
                        }
                        else
                        {
                            List<string> Part2 = new List<string>();
                            Make1.Make1_1(out Part2, temp, random);
                            Chars.Insert(0, Part2[2]);
                            Chars.Insert(1, Part2[1]);
                            Chars.Insert(2, "(");
                            Chars.Insert(Chars.Count, ")");
                            pass = true;
                        }
                    }
                    else if (Maths2 == "Make1_2")
                    {
                        if (temp < 1 || temp > 10)
                        {
                            Chars.Clear();
                            continue;
                        }
                        else
                        {
                            List<string> Part2 = new List<string>();
                            Make1.Make1_2_R(out Part2, temp, random);
                            Chars.Insert(0, Part2[0]);
                            Chars.Insert(1, Part2[1]);
                            Chars.Insert(2, "(");
                            Chars.Insert(Chars.Count, ")");
                            pass = true;
                        }
                    }
                }
                else
                {
                    if (Maths2 == "Make2_1")
                    {
                        if (temp < 2 || temp >= 10)
                        {
                            Chars.Clear();
                            continue;
                        }
                        else
                        {
                            List<string> Part2 = new List<string>();
                            Make2_1(out Part2, temp, random);
                            Chars.Add(Part2[1]);
                            Chars.Add(Part2[2]);
                            pass = true;
                        }
                    }
                    else if (Maths2 == "Make1_1")
                    {
                        if (temp < 1 || temp >= 10)
                        {
                            Chars.Clear();
                            continue;
                        }
                        else
                        {
                            List<string> Part2 = new List<string>();
                            Make1.Make1_1(out Part2, temp, random);
                            Chars.Add(Part2[1]);
                            Chars.Add(Part2[2]);
                            pass = true;
                        }
                    }
                    else if (Maths2 == "Make1_2")
                    {
                        if (temp < 1 || temp >= 11)
                        {
                            Chars.Clear();
                            continue;
                        }
                        else
                        {
                            List<string> Part2 = new List<string>();
                            Make1.Make1_2(out Part2, temp, random);
                            Chars.Add(Part2[1]);
                            Chars.Add(Part2[2]);
                            pass = true;
                        }
                    }
                }
            } while (pass == false);
            // 输出结果
            return $"{string.Join(" ", Chars)} = ";
        }
    }
}
