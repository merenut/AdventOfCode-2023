using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdventOfCode.Code
{
    internal class DayOne : Day
    {
        string[] numbersSpelled = { "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };

        public DayOne(string path) : base(path)
        {
        }

        internal void SolutionOne()
        {
            var running = 0;
            var simplified = Regex.Replace(input, @"[A-Za-z]", "");
            var parse = simplified.Split("\n");
            foreach (var line in parse)
            {
                var linesimp = line.Trim();
                var first = linesimp.Substring(0, 1);
                var last = linesimp.Substring(linesimp.Length - 1, 1);
                var number = first + last;
                running += int.Parse(number);
            }
            Console.WriteLine("Day 1 - Part 1: " + running);
        }

        internal void SolutionTwo()
        {
            var running = 0;
            var parse = input.Split("\n");

            foreach (var line in parse)
            {
                string regex = numbersSpelled.Aggregate((i, j) => i + "|" + j);
                regex = "(" + regex + ")" + @"|\d";
                regex = "(?=" + "(" + regex + "))";
                var matches = Regex.Matches(line, regex);

                var first = matches.First().Groups[1];
                var last = matches.Last().Groups[1];

                var firststring = int.TryParse(first.Value, out int result1) ? result1.ToString() : (Array.IndexOf(numbersSpelled, first.Value) + 1).ToString();
                var laststring = int.TryParse(last.Value, out int result3) ? result3.ToString() : (Array.IndexOf(numbersSpelled, last.Value) + 1).ToString();

                var number = firststring + laststring;

                running += int.Parse(number);

            }
            Console.WriteLine("Day 1 - Part 2: " + running);
        }

    }
}
