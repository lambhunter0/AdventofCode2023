using System;
using System.Collections.Generic;
using System.IO;

namespace AdventofCode
{
    internal class Day1
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> matches = new Dictionary<string, int>()
            {
                ["one"] = 1,
                ["two"] = 2,
                ["three"] = 3,
                ["four"] = 4,
                ["five"] = 5,
                ["six"] = 6,
                ["seven"] = 7,
                ["eight"] = 8,
                ["nine"] = 9,
            };
            int calibrationSum = 0;
            StreamReader sr = new StreamReader("C:\\Users\\gtheophanous\\Desktop\\AOC\\AdventofCode\\AdventofCode\\2023Day1input");
            string input = sr.ReadToEnd();
            string[] inputs = input.Split('\r');
            foreach (string s in inputs)
            {
                Console.WriteLine(s);

                long first = -1;
                long last = -1;
                int indexSub = 0;
                foreach (char c in s.Trim().ToCharArray())
                {
                    if (Char.IsDigit(c))
                    {
                        string dig = "" + c;
                        long i = Int64.Parse(dig);
                        if (first == -1)
                        {
                            first = i;
                            Console.WriteLine("first: " + first);
                        }
                        else
                            last = i;
                    }
                    else
                    {
                        int len = s.Length;
                        int subStringLength = indexSub + 1 + 5 > len ? len - indexSub : 5;
                        string sub = s.Substring(indexSub, subStringLength); //5 is max length for eight

                        foreach (string key in matches.Keys) 
                        {
                            if (sub.Contains(key)) 
                            {
                                if (first == -1) 
                                {
                                    first = matches[key];
                                    Console.WriteLine("first: " + first);
                                }
                                else
                                    last = matches[key];
                            }
                        }
                    }
                    indexSub++;
                }
                int num = last == -1 ? (int)(first * 10 + first) : (int)(first * 10 + last);
                Console.WriteLine("last: " + last);
                Console.WriteLine("num: " + num);

                calibrationSum += num;
            }
            Console.WriteLine(calibrationSum);
            System.Threading.Thread.Sleep(50000);
        }
    }
}
