using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Web.Help.Grade2
{
    public class Make22
    {
        public static string Make2_1_Sev(string selectifKH)
        {
            Random random = new Random();

            bool pass = false;
            List<string> Chars = new List<string>();
            int ifHasKH = 0;
            if (!string.IsNullOrEmpty(selectifKH))
            {
                ifHasKH = random.Next(0, 2);
            }

            int temp = 0;
            var MainPoint = random.Next(0, 2);
            string[] Maths = new[] { "+", "-", "*","9Make2_1" };
            string Maths1 = string.Empty, Maths2 = string.Empty;
            if (MainPoint == 0)
            {
                Maths1 = "9Make2_1";
                Maths2 = Maths[random.Next(0, 4)];
            }
            else
            {
                int startIndex=(ifHasKH==0)?2:0;//无括号，那第二算法是除法，第一算法一定要是乘法除
                Maths1 = Maths[random.Next(startIndex, 4)];
                Maths2 = "9Make2_1";
            }
            do
            {
                if(Maths1=="9Make2_1")
                {
                    var strTemps = Make2_1(out Chars, null, random);
                    temp = Convert.ToInt32(Chars[0]) / Convert.ToInt32(Chars[2]);
                }
                else if(Maths1=="*")
                {
                    var math1num1 = random.Next(1, 10);
                    var math1num2 = random.Next(1, 10);
                    Chars=new List<string>() { math1num1.ToString(), "×", math1num2.ToString() };
                    temp=math1num1*math1num2;
                }
                else if(Maths1=="+")
                {
                    var math1num1 = random.Next(1, 6);
                    var math1num2 = random.Next(1, 6-math1num1+1);
                    Chars=new List<string>() { math1num1.ToString(), "+", math1num2.ToString() };
                    temp=math1num1+math1num2;
                }
                else if(Maths1=="-")
                {
                    var math1num1 = random.Next(2, 100);
                    var minNum2=math1num1-6<1?1:math1num1-6;
                    var math1num2 = random.Next(minNum2, math1num1);
                    Chars=new List<string>() { math1num1.ToString(), "-", math1num2.ToString() };
                    temp=math1num1-math1num2;
                }
                if(ifHasKH==0)//无括号
                {
                    if (Maths2 == "9Make2_1")
                    {
                        if (!GetMake2_1AllRes().Contains(temp))
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
                    else if (Maths2 == "*")
                    {
                        if (temp>=10)
                        {
                            Chars.Clear();
                            continue;
                        }
                        else
                        {
                            var math1num2 = random.Next(1, 10);
                            Chars.Add("×");
                            Chars.Add(math1num2.ToString());
                            pass = true;
                        }
                    }
                    else if (Maths2 == "+")
                    {
                        if (temp>=100)
                        {
                            Chars.Clear();
                            continue;
                        }
                        else
                        {
                            var math1num2 = random.Next(1, 100-temp+1);
                            Chars.Add("+");
                            Chars.Add(math1num2.ToString());
                            pass = true;
                        }
                    }
                    else if (Maths2 == "-")
                    {
                        if (temp<=0)
                        {
                            Chars.Clear();
                            continue;
                        }
                        else
                        {
                            var math1num2 = random.Next(1, temp+1);
                            Chars.Add("-");
                            Chars.Add(math1num2.ToString());
                            pass = true;
                        }
                    }
                }
                else
                {
                    if(Maths2=="9Make2_1")
                    {
                        if (temp>=7)
                        {
                            Chars.Clear();
                            continue;
                        }
                        else
                        {
                            var ch1 = random.Next(1, 10);
                            var number1 = ch1*temp;
                            Chars.Insert(0, number1.ToString());
                            Chars.Insert(1, "÷");
                            Chars.Insert(2, "(");
                            Chars.Insert(Chars.Count, ")");
                            pass = true;
                        }
                    }
                    else if(Maths2 == "*")
                    {
                        if (temp>=10)
                        {
                            Chars.Clear();
                            continue;
                        }
                        else
                        {
                            var number1 = random.Next(1, 10);
                            Chars.Insert(0, number1.ToString());
                            Chars.Insert(1, "×");
                            Chars.Insert(2, "(");
                            Chars.Insert(Chars.Count, ")");
                            pass = true;
                        }
                    }
                    else if(Maths2 == "+")
                    {
                        if (temp>=100)
                        {
                            Chars.Clear();
                            continue;
                        }
                        else
                        {
                            var number1 = random.Next(1, 100-temp+1);
                            Chars.Insert(0, number1.ToString());
                            Chars.Insert(1, "+");
                            pass = true;
                        }
                    }
                    else if(Maths2 == "-")
                    {
                        if (temp<=0)
                        {
                            Chars.Clear();
                            continue;
                        }
                        else
                        {
                            var number1 = random.Next(temp, 100);
                            Chars.Insert(0, number1.ToString());
                            Chars.Insert(1, "-");
                            pass = true;
                        }
                    }
                }
            } while (pass == false);
            // 输出结果
            return $"{string.Join(" ", Chars)} = ";
        }

        public static string Make2_1(out List<string> res, int? part1 = null, Random farandom = null) //表内除法（一）用2~6的乘法口诀求商
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
                var ch1 = random.Next(1, 10);
                num2  = random.Next(1, 7);
                num1 = ch1*num2;
            }
            else
            {
                num1 = (int)part1;
                do{
                    num2=random.Next(1, 7);
                }while(num1%num2!=0);
            }
            res = new List<string>() { num1.ToString(), "÷", num2.ToString() };
            // 输出结果
            return $"{num1} ÷ {num2} = ";
        }

        public static List<int> GetMake2_1AllRes()
        {
            List<int> result=new List<int>();
            for(int i=1;i<10;i++)
            {
                for(int j=1;j<7;j++)
                {
                    result.Add(i*j);
                }
            }
            return result.Distinct().ToList();
        }

        public static string Make4_1(out List<string> res, int? part1 = null, Random farandom = null) //表内除法（二）
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
                var ch1 = random.Next(1, 10);
                num2  = random.Next(1, 10);
                num1 = ch1*num2;
            }
            else
            {
                num1 = (int)part1;
                do{
                    num2=random.Next(1, 10);
                }while(num1%num2!=0);
            }
            res = new List<string>() { num1.ToString(), "÷", num2.ToString() };
            // 输出结果
            return $"{num1} ÷ {num2} = ";
        }

        public static string Make4_1_Sev(string selectifKH)
        {
            Random random = new Random();

            bool pass = false;
            List<string> Chars = new List<string>();
            int ifHasKH = 0;
            if (!string.IsNullOrEmpty(selectifKH))
            {
                ifHasKH = random.Next(0, 2);
            }

            int temp = 0;
            var MainPoint = random.Next(0, 2);
            string[] Maths = new[] { "+", "-", "*","9Make4_1" };
            string Maths1 = string.Empty, Maths2 = string.Empty;
            if (MainPoint == 0)
            {
                Maths1 = "9Make4_1";
                Maths2 = Maths[random.Next(0, 4)];
            }
            else
            {
                int startIndex=(ifHasKH==0)?2:0;//无括号，那第二算法是除法，第一算法一定要是乘法除
                Maths1 = Maths[random.Next(startIndex, 4)];
                Maths2 = "9Make4_1";
            }
            do
            {
                if(Maths1=="9Make4_1")
                {
                    var strTemps = Make4_1(out Chars, null, random);
                    temp = Convert.ToInt32(Chars[0]) / Convert.ToInt32(Chars[2]);
                }
                else if(Maths1=="*")
                {
                    var math1num1 = random.Next(1, 10);
                    var math1num2 = random.Next(1, 10);
                    Chars=new List<string>() { math1num1.ToString(), "×", math1num2.ToString() };
                    temp=math1num1*math1num2;
                }
                else if(Maths1=="+")
                {
                    var math1num1 = random.Next(1, 9);
                    var math1num2 = random.Next(1, 9-math1num1+1);
                    Chars=new List<string>() { math1num1.ToString(), "+", math1num2.ToString() };
                    temp=math1num1+math1num2;
                }
                else if(Maths1=="-")
                {
                    var math1num1 = random.Next(2, 100);
                    var minNum2=math1num1-9<1?1:math1num1-9;
                    var math1num2 = random.Next(minNum2, math1num1);
                    Chars=new List<string>() { math1num1.ToString(), "-", math1num2.ToString() };
                    temp=math1num1-math1num2;
                }
                if(ifHasKH==0)//无括号
                {
                    if (Maths2 == "9Make4_1")
                    {
                        if (!GetMake4_1AllRes().Contains(temp))
                        {
                            Chars.Clear();
                            continue;
                        }
                        else
                        {
                            List<string> Part2 = new List<string>();
                            Make4_1(out Part2, temp, random);
                            Chars.Add(Part2[1]);
                            Chars.Add(Part2[2]);
                            pass = true;
                        }
                    }
                    else if (Maths2 == "*")
                    {
                        if (temp>=10)
                        {
                            Chars.Clear();
                            continue;
                        }
                        else
                        {
                            var math1num2 = random.Next(1, 10);
                            Chars.Add("×");
                            Chars.Add(math1num2.ToString());
                            pass = true;
                        }
                    }
                    else if (Maths2 == "+")
                    {
                        if (temp>=100)
                        {
                            Chars.Clear();
                            continue;
                        }
                        else
                        {
                            var math1num2 = random.Next(1, 100-temp+1);
                            Chars.Add("+");
                            Chars.Add(math1num2.ToString());
                            pass = true;
                        }
                    }
                    else if (Maths2 == "-")
                    {
                        if (temp<=0)
                        {
                            Chars.Clear();
                            continue;
                        }
                        else
                        {
                            var math1num2 = random.Next(1, temp+1);
                            Chars.Add("-");
                            Chars.Add(math1num2.ToString());
                            pass = true;
                        }
                    }
                }
                else
                {
                    if(Maths2=="9Make4_1")
                    {
                        if (temp>=10)
                        {
                            Chars.Clear();
                            continue;
                        }
                        else
                        {
                            var ch1 = random.Next(1, 10);
                            var number1 = ch1*temp;
                            Chars.Insert(0, number1.ToString());
                            Chars.Insert(1, "÷");
                            Chars.Insert(2, "(");
                            Chars.Insert(Chars.Count, ")");
                            pass = true;
                        }
                    }
                    else if(Maths2 == "*")
                    {
                        if (temp>=10)
                        {
                            Chars.Clear();
                            continue;
                        }
                        else
                        {
                            var number1 = random.Next(1, 10);
                            Chars.Insert(0, number1.ToString());
                            Chars.Insert(1, "×");
                            Chars.Insert(2, "(");
                            Chars.Insert(Chars.Count, ")");
                            pass = true;
                        }
                    }
                    else if(Maths2 == "+")
                    {
                        if (temp>=100)
                        {
                            Chars.Clear();
                            continue;
                        }
                        else
                        {
                            var number1 = random.Next(1, 100-temp+1);
                            Chars.Insert(0, number1.ToString());
                            Chars.Insert(1, "+");
                            pass = true;
                        }
                    }
                    else if(Maths2 == "-")
                    {
                        if (temp<=0)
                        {
                            Chars.Clear();
                            continue;
                        }
                        else
                        {
                            var number1 = random.Next(temp, 100);
                            Chars.Insert(0, number1.ToString());
                            Chars.Insert(1, "-");
                            pass = true;
                        }
                    }
                }
            } while (pass == false);
            // 输出结果
            return $"{string.Join(" ", Chars)} = ";
        }

        public static List<int> GetMake4_1AllRes()
        {
            List<int> result=new List<int>();
            for(int i=1;i<10;i++)
            {
                for(int j=1;j<10;j++)
                {
                    result.Add(i*j);
                }
            }
            return result.Distinct().ToList();
        }
    }
}