using System;
using System.Collections.Generic;

namespace Web.Help.Grade2
{
    public class Make2
    {
        public static string Make2_1_Sev(string selectifKH)
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
                var strTemps = Make2_1(out Chars, null, random);
                int temp = Convert.ToInt32(Chars[0]) + Convert.ToInt32(Chars[2]);
                if(ifHasKH==1)//有括号
                {
                    if (temp < 10 || temp >= 90)
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
                else
                {
                    if (temp < 10 || temp >= 90)
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
            } while (pass == false);
            // 输出结果
            return $"{string.Join(" ", Chars)} = ";
        }

        public static string Make2_1(out List<string> res, int? part1 = null, Random farandom = null) //100以内的加法和减法（二）不进位加
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
                num1 = random.Next(10, 90);
            }
            else
            {
                num1 = (int)part1;
            }
            do{
                num2 = random.Next(10, 100 - num1);
            }while((num1%10+num2%10)>=10);
            res = new List<string>() { num1.ToString(), "+", num2.ToString() };
            // 输出结果
            return $"{num1} + {num2} = ";
        }

        public static string Make2_2_Sev(string selectifKH)
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
                if(Maths1=="Make2_2")
                {
                    var strTemps = Make2_2(out Chars, null, random);
                    temp = Convert.ToInt32(Chars[0]) + Convert.ToInt32(Chars[2]);
                }
                else if(Maths1=="Make2_1")
                {
                    var strTemps = Make2_1(out Chars, null, random);
                    temp = Convert.ToInt32(Chars[0]) + Convert.ToInt32(Chars[2]);
                }
                if(ifHasKH==1)//有括号
                {
                    if (Maths2 == "Make2_1")
                    {
                        if (temp < 10 || temp >= 90)
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
                        if (temp < 11 || temp >= 90||temp%10==0)
                        {
                            Chars.Clear();
                            continue;
                        }
                        else
                        {
                            List<string> Part2 = new List<string>();
                            Make2_2(out Part2, temp, random);
                            Chars.Insert(0, Part2[2]);
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
                        if (temp < 10 || temp >= 90)
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
                        if (temp < 11 || temp >= 90||temp%10==0)
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

        public static string Make2_2(out List<string> res, int? part1 = null, Random farandom = null) //100以内的加法和减法（二）进位加
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
                do{
                    num1 = random.Next(11, 90);
                }while(num1%10==0);
            }
            else
            {
                num1 = (int)part1;
            }
            do{
                num2 = random.Next(11, 100 - num1+1);
            }while((num1%10+num2%10)<10);
            res = new List<string>() { num1.ToString(), "+", num2.ToString() };
            // 输出结果
            return $"{num1} + {num2} = ";
        }
    
        public static string Make2_3(out List<string> res, int? part1 = null, Random farandom = null) //100以内的加法和减法（二）不退位减
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
                num1 = random.Next(21, 100);
            }
            else
            {
                num1 = (int)part1;
            }
            do{
                num2 = random.Next(11, num1+1);
            }while(num1%10<num2%10);
            res = new List<string>() { num1.ToString(), "-", num2.ToString() };
            // 输出结果
            return $"{num1} - {num2} = ";
        }
    
        public static string Make2_3_Sev(string selectifKH)
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
                string[] Maths = new[] { "Make2_1", "Make2_2", "Make2_3" };
                string Maths1 = string.Empty, Maths2 = string.Empty;
                if (MainPoint == 0)
                {
                    Maths1 = "Make2_3";
                    Maths2 = Maths[random.Next(0, 3)];
                }
                else
                {
                    Maths1 = Maths[random.Next(0, 3)];
                    Maths2 = "Make2_3";
                }
                int temp = 0;
                if(Maths1=="Make2_1")
                {
                    var strTemps = Make2_1(out Chars, null, random);
                    temp = Convert.ToInt32(Chars[0]) + Convert.ToInt32(Chars[2]);
                }
                else if(Maths1=="Make2_2")
                {
                    var strTemps = Make2_2(out Chars, null, random);
                    temp = Convert.ToInt32(Chars[0]) + Convert.ToInt32(Chars[2]);
                }
                else if(Maths1=="Make2_3")
                {
                    var strTemps = Make2_3(out Chars, null, random);
                    temp = Convert.ToInt32(Chars[0]) - Convert.ToInt32(Chars[2]);
                }
                if(ifHasKH==1)//有括号
                {
                    if (Maths2 == "Make2_1")
                    {
                        if (temp < 10 || temp >= 90)
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
                        if (temp < 11 || temp >= 90||temp%10==0)
                        {
                            Chars.Clear();
                            continue;
                        }
                        else
                        {
                            List<string> Part2 = new List<string>();
                            Make2_2(out Part2, temp, random);
                            Chars.Insert(0, Part2[2]);
                            Chars.Insert(1, Part2[1]);
                            Chars.Insert(2, "(");
                            Chars.Insert(Chars.Count, ")");
                            pass = true;
                        }
                    }
                    else if (Maths2 == "Make2_3")
                    {
                        if (temp < 10 || temp >= 99)
                        {
                            Chars.Clear();
                            continue;
                        }
                        else
                        {
                            List<string> Part2 = new List<string>();
                            Make2_3_R(out Part2, temp, random);
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
                        if (temp < 10 || temp >= 90)
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
                        if (temp < 11 || temp >= 90||temp%10==0)
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
                    else if (Maths2 == "Make2_3")
                    {
                        if (temp < 21 || temp >= 100)
                        {
                            Chars.Clear();
                            continue;
                        }
                        else
                        {
                            List<string> Part2 = new List<string>();
                            Make2_3(out Part2, temp, random);
                            Chars.Add(Part2[1]);
                            Chars.Add(Part2[2]);
                            pass = true;
                        }
                    }
                }
            }while (pass == false);
            // 输出结果
            return $"{string.Join(" ", Chars)} = ";
        }

        public static string Make2_3_R(out List<string> res, int num2, Random farandom)
        {
            int Min=num2;
            int num1=0;
            do{ 
                num1 = farandom.Next(Min, 100);
            }while((num1%10)<(num2%10));
            res = new List<string>() { num1.ToString(), "-", num2.ToString() };
            // 输出结果
            return $"{num1} - {num2} = ";
        }

        public static string Make2_4(out List<string> res, int? part1 = null, Random farandom = null) //100以内的加法和减法（二）退位减
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
                do{
                    num1 = random.Next(20, 100);
                }while(num1%10==9);
            }
            else
            {
                num1 = (int)part1;
            }
            do{
                num2 = random.Next(11, num1+1);
            }while(num1%10>=num2%10);
            res = new List<string>() { num1.ToString(), "-", num2.ToString() };
            // 输出结果
            return $"{num1} - {num2} = ";
        }

        public static string Make2_4_Sev(string selectifKH)
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
                string[] Maths = new[] { "Make2_1", "Make2_2", "Make2_3", "Make2_4" };
                string Maths1 = string.Empty, Maths2 = string.Empty;
                if (MainPoint == 0)
                {
                    Maths1 = "Make2_4";
                    Maths2 = Maths[random.Next(0, 3)];
                }
                else
                {
                    Maths1 = Maths[random.Next(0, 3)];
                    Maths2 = "Make2_4";
                }
                int temp = 0;
                if(Maths1=="Make2_1")
                {
                    var strTemps = Make2_1(out Chars, null, random);
                    temp = Convert.ToInt32(Chars[0]) + Convert.ToInt32(Chars[2]);
                }
                else if(Maths1=="Make2_2")
                {
                    var strTemps = Make2_2(out Chars, null, random);
                    temp = Convert.ToInt32(Chars[0]) + Convert.ToInt32(Chars[2]);
                }
                else if(Maths1=="Make2_3")
                {
                    var strTemps = Make2_3(out Chars, null, random);
                    temp = Convert.ToInt32(Chars[0]) - Convert.ToInt32(Chars[2]);
                }
                else if(Maths1=="Make2_4")
                {
                    var strTemps = Make2_4(out Chars, null, random);
                    temp = Convert.ToInt32(Chars[0]) - Convert.ToInt32(Chars[2]);
                }
                if(ifHasKH==1)//有括号
                {
                    if (Maths2 == "Make2_1")
                    {
                        if (temp < 10 || temp >= 90)
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
                        if (temp < 11 || temp >= 90||temp%10==0)
                        {
                            Chars.Clear();
                            continue;
                        }
                        else
                        {
                            List<string> Part2 = new List<string>();
                            Make2_2(out Part2, temp, random);
                            Chars.Insert(0, Part2[2]);
                            Chars.Insert(1, Part2[1]);
                            Chars.Insert(2, "(");
                            Chars.Insert(Chars.Count, ")");
                            pass = true;
                        }
                    }
                    else if (Maths2 == "Make2_3")
                    {
                        if (temp < 10 || temp >= 99)
                        {
                            Chars.Clear();
                            continue;
                        }
                        else
                        {
                            List<string> Part2 = new List<string>();
                            Make2_3_R(out Part2, temp, random);
                            Chars.Insert(0, Part2[0]);
                            Chars.Insert(1, Part2[1]);
                            Chars.Insert(2, "(");
                            Chars.Insert(Chars.Count, ")");
                            pass = true;
                        }
                    }
                    else if (Maths2 == "Make2_4")
                    {
                        if (temp < 11 || temp >= 90||temp%10==0)
                        {
                            Chars.Clear();
                            continue;
                        }
                        else
                        {
                            List<string> Part2 = new List<string>();
                            Make2_4_R(out Part2, temp, random);
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
                        if (temp < 10 || temp >= 90)
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
                        if (temp < 11 || temp >= 90||temp%10==0)
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
                    else if (Maths2 == "Make2_3")
                    {
                        if (temp < 21 || temp >= 100)
                        {
                            Chars.Clear();
                            continue;
                        }
                        else
                        {
                            List<string> Part2 = new List<string>();
                            Make2_3(out Part2, temp, random);
                            Chars.Add(Part2[1]);
                            Chars.Add(Part2[2]);
                            pass = true;
                        }
                    }
                    else if (Maths2 == "Make2_4")
                    {
                        if (temp < 20 || temp >= 100||temp%10==9)
                        {
                            Chars.Clear();
                            continue;
                        }
                        else
                        {
                            List<string> Part2 = new List<string>();
                            Make2_4(out Part2, temp, random);
                            Chars.Add(Part2[1]);
                            Chars.Add(Part2[2]);
                            pass = true;
                        }
                    }
                }
            }while (pass == false);
            // 输出结果
            return $"{string.Join(" ", Chars)} = ";
        }
    
        public static string Make2_4_R(out List<string> res, int num2, Random farandom)
        {
            int Min=num2;
            int num1=0;
            do{ 
                num1 = farandom.Next(Min, 100);
            }while((num1%10)>=(num2%10));
            res = new List<string>() { num1.ToString(), "-", num2.ToString() };
            // 输出结果
            return $"{num1} - {num2} = ";
        }
    }
}