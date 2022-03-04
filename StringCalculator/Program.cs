using System;
using System.Collections.Generic;

namespace StringCalculator
{
    public class Calculator
    {
        public int Calculate(string arguments)
        {
            int res = 0;
            List<string> splitters = new List<string>();

            if (arguments.Length > 3 && arguments[0] == '/' && arguments[1] == '/')
            {
                if(arguments.Length > 5 && arguments.Contains('[') && arguments.Contains(']'))
                {
                    splitters.Add(arguments.Substring(3, arguments.IndexOf(']') - 3));
                    arguments = arguments.Substring(arguments.IndexOf(']') + 1);
                }
                else
                {
                    splitters.Add(arguments[2].ToString());
                    arguments = arguments.Substring(3);
                }
            }

            if(arguments.Contains(",") && arguments.Contains("\n"))
            {
                splitters.Add(",");
                splitters.Add("\n");
            }
            else if(arguments.Contains("\n"))
            {
                splitters.Add("\n");
            }
            else
            {
                splitters.Add(",");
            }

            string[] args = arguments.Split(splitters.ToArray(), StringSplitOptions.RemoveEmptyEntries);

            foreach (string arg in args)
            {
                if(arg != "")
                {
                    int num = Int32.Parse(arg);

                    if (num < 0)
                        throw new ArgumentOutOfRangeException();
                    else if (num > 1000)
                        num = 0;

                    res += num;
                }
            }

            return res;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
