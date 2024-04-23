using System;
using System.Collections.Generic;

namespace Web.Help
{
    public class Make6
    {
        public static string Make6_1(out List<string> res, int? part1 = null, Random farandom = null,string operationString="") //整十数加减整十数
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

            // 随机选择加法或减法
            int operation = random.Next(0, 2);
            if(string.IsNullOrEmpty(operationString))
            {
                operationString = operation == 0 ? "+" : "-";
            }

            // 生成第一个随机整十数
            int num1 = 0;
            if (part1 == null)
            {
                num1 = random.Next(1, 10);
            }
            else
            {
                num1 = (int)part1;
            }

            int num2;
            int next = 0;
            if (operationString == "-")
            {
                next = num1 + 1;
            }
            else
            {
                next = 10 - num1 + 1;
            }
            num2 = random.Next(1, next);

            res = new List<string>() { (num1*10).ToString(), operationString, (num2*10).ToString() };

            // 输出结果
            return $"{num1 * 10} {operationString} {num2 * 10} = ";
        }

        public static string Make6_1_R(out List<string> res, int num2, Random farandom) //整十数减整十数,反向
        {
            //num2 必须大于等于10 小于等于90
            int num1 = farandom.Next(num2/10, 10);
            res = new List<string>() { (num1*10).ToString(), "-", (num2*10).ToString() };
            // 输出结果
            return $"{num1*10} - {num2*10} = ";
        }

        public static string Make6_2(out List<string> res, int? part1 = null, Random farandom = null) //两位数加一位数、整十数
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

            // 两位数加一位数、整十数
            int operation = 0;
            if (part1 != null && (int)part1 >= 91)
            {
                operation = 0;
            }
            else
            {
                operation = random.Next(0, 2);
            }

            // 生成第一个2位数
            int num1 = 0;

            int num2;
            int next = 0;
            if (operation == 0) //两位数加一位数
            {
                // 生成第一个2位数
                if (part1 != null)
                {
                    num1 = (int)part1;
                }
                else
                {
                    num1 = random.Next(10, 100);
                }
                next = 100 - num1 + 1;
                if (next > 10) { next = 10; }
                num2 = random.Next(1, next);

                var opt = random.Next(0, 2);
                if (opt == 1 && farandom==null)
                {
                    var temp = num1;
                    num1 = num2;
                    num2 = temp;
                }
            }
            else //两位数加整十数
            {
                if (part1 != null)
                {
                    num1 = (int)part1;
                }
                else
                {
                    num1 = random.Next(10, 91);
                }
                var num1_ten = Convert.ToInt32(Math.Ceiling(num1 * 1.0 / 10));
                next = 10 - num1_ten + 1;
                num2 = random.Next(1, next) * 10;

                var opt = random.Next(0, 2);
                if (opt == 1 && farandom==null)
                {
                    var temp = num1;
                    num1 = num2;
                    num2 = temp;
                }
            }
            res = new List<string>() { num1.ToString(), "+", num2.ToString() };
            // 输出结果
            return $"{num1} + {num2} = ";
        }

        public static string Make6_3(out List<string> res, int? part1 = null, Random farandom = null) //两位数减一位数、整十数
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

            // 随机选择加法或减法
            int operation = random.Next(0, 2);

            // 生成第一个2位数
            int num1 = 0;
            if (part1 != null)
            {
                num1 =(int) part1;
            }
            else
            {
                num1 = random.Next(10, 100);
            }
            int num2;
            int next = 0;
            if (operation == 0) //两位数减一位数
            {
                next = num1 + 1;
                if (next > 10) { next = 10; }
                num2 = random.Next(1, next);
            }
            else //两位数减整十数
            {
                var num1_ten = num1 / 10;
                next = num1_ten + 1;
                num2 = random.Next(1, next) * 10;
            }
            res = new List<string>() { num1.ToString(), "-", num2.ToString() };
            // 输出结果
            return $"{num1} - {num2} = ";
        }

        public static string Make6_1_Sev(string selectifKH)
        {
            Random random = new Random();

            bool pass = false;
            int ifHasKH=0;
            if(!string.IsNullOrEmpty(selectifKH))
            {
                ifHasKH = random.Next(0, 2);
            }
            List<string> Chars = new List<string>();
            do
            {
                int temp = 0;
                var strTemps = Make6_1(out Chars, null, random);
                if (Chars[1] == "+")
                {
                    temp = Convert.ToInt32(Chars[0]) + Convert.ToInt32(Chars[2]);
                }
                else
                {
                    temp = Convert.ToInt32(Chars[0]) - Convert.ToInt32(Chars[2]);
                }

                if(ifHasKH==1)//有括号
                {
                    int operation = random.Next(0, 2);
                    string operationString = operation == 0 ? "+" : "-";
                    if(operationString=="+")
                    {
                        if (temp/10 < 1 || temp/10 >= 10)
                        {
                            Chars.Clear();
                            continue;
                        }
                        else
                        {
                            List<string> Part2 = new List<string>();
                            Make6_1(out Part2, temp, random,operationString);
                            Chars.Insert(0, Part2[2]);
                            Chars.Insert(1, Part2[1]);
                            Chars.Insert(2, "(");
                            Chars.Insert(Chars.Count, ")");
                            pass = true;
                        }
                    }
                    else
                    {
                        if (temp/10 < 1 || temp/10 >= 10)
                        {
                            Chars.Clear();
                            continue;
                        }
                        else
                        {
                            List<string> Part2 = new List<string>();
                            Make6_1_R(out Part2, temp, random);
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
                    if (temp/10 < 1 || temp/10 >= 10)
                    {
                        Chars.Clear();
                        continue;
                    }
                    else
                    {
                        List<string> Part2 = new List<string>();
                        Make6_1(out Part2, temp/10, random);
                        Chars.Add(Part2[1]);
                        Chars.Add(Part2[2]);
                        pass = true;
                    }
                }
            } while (pass == false);
            // 输出结果
            return $"{string.Join(" ", Chars)} = ";
        }

        public static string Make6_2_Sev(string selectifKH)
        {
            Random random = new Random();

            bool pass = false;
            List<string> Chars = new List<string>();

            do
            {
                int temp = 0;
                var strTemps = Make6_2(out Chars, null, random);
                temp = Convert.ToInt32(Chars[0]) + Convert.ToInt32(Chars[2]);

                var opt = random.Next(0, 2);
                if (opt == 1)
                {
                    var Chartemp = Chars[0];
                    Chars[0] = Chars[2];
                    Chars[2] = Chartemp;
                }

                if (temp < 10 || temp >= 100)
                {
                    Chars.Clear();
                    continue;
                }
                else
                {
                    List<string> Part2 = new List<string>();
                    Make6_2(out Part2, temp, random);
                    Chars.Add(Part2[1]);
                    Chars.Add(Part2[2]);
                    pass = true;
                }
            } while (pass == false);
            return $"{string.Join(" ", Chars)} = ";
        }

        public static string Make6_3_Sev(string selectifKH)
        {
            Random random = new Random();

            bool pass = false;
            List<string> Chars = new List<string>();

            do
            {
                var MainPoint = random.Next(0, 2);
                string[] Maths = new[] { "Make6_3", "Make6_2" };
                string Maths1 = string.Empty, Maths2 = string.Empty;
                if (MainPoint == 0)
                {
                    Maths1 = "Make6_3";
                    Maths2 = Maths[random.Next(0, 2)];
                }
                else
                {
                    Maths1 = Maths[random.Next(0, 2)];
                    Maths2 = "Make6_3";
                }
                int temp = 0;

                if (Maths1 == "Make6_3") //第一个方法是 20以内的进位加法
                {
                    var strTemps = Make6_3(out Chars, null, random);
                    temp = Convert.ToInt32(Chars[0]) - Convert.ToInt32(Chars[2]);
                }
                else if (Maths1 == "Make6_2")
                {
                    var strTemps = Make6_2(out Chars, null, random);
                    temp = Convert.ToInt32(Chars[0]) + Convert.ToInt32(Chars[2]);

                    var opt = random.Next(0, 2);
                    if (opt == 1)
                    {
                        var Chartemp = Chars[0];
                        Chars[0] = Chars[2];
                        Chars[2] = Chartemp;
                    }
                }

                if (Maths2 == "Make6_3")
                {
                    if (temp < 10 || temp >= 100)
                    {
                        Chars.Clear();
                        continue;
                    }
                    else
                    {
                        List<string> Part2 = new List<string>();
                        Make6_3(out Part2, temp, random);
                        Chars.Add(Part2[1]);
                        Chars.Add(Part2[2]);
                        pass = true;
                    }
                }
                else if (Maths2 == "Make6_2")
                {
                    if (temp < 10 || temp >= 100)
                    {
                        Chars.Clear();
                        continue;
                    }
                    else
                    {
                        List<string> Part2 = new List<string>();
                        Make6_2(out Part2, temp, random);
                        Chars.Add(Part2[1]);
                        Chars.Add(Part2[2]);
                        pass = true;
                    }
                }
            } while (pass == false);
            return $"{string.Join(" ", Chars)} = ";
        }
    }
}
