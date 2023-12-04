  using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdventOfCode.Code
{
    internal class DayThree : Day
    {
        public DayThree(string path) : base(path)
        {
        }

        internal void SolutionPartOne()
        {
            var length = input.IndexOf("\n") + 1;
            var matches = Regex.Matches(input, "\\d+");
            var specMatch = Regex.Matches(input, "[^.\\w\\n\\r]");
            
            var running = 0;

            foreach (Match item in matches)
            {
                var numLen = item.Value.Length;
                var itemRel = item.Index % length;
                var part = false;
                foreach (Match spec in specMatch)
                {
                    var relIndex = spec.Index % length;
                    if(relIndex <= (itemRel + numLen) && relIndex >= (itemRel - 1) && (Math.Abs(item.Index - spec.Index) <= length + numLen + 1))
                    {
                        part = true;
                    }
                    if (part)
                        break;
                }
                if (part)
                    running += int.Parse(item.Value);
            }

            Console.WriteLine("Day 3 - Part 1: " + running);
        }

        internal void SolutionPartTwo()
        {
            var length = input.IndexOf("\n") + 1;
            var matches = Regex.Matches(input, "\\d+");
            var specMatch = Regex.Matches(input, "[^.\\w\\n\\r]");

            var running = 0;

            foreach (Match spec in specMatch)
            {
                var specRel = spec.Index % length;
                var part = 0;
                List<int> parts = new List<int>();
                foreach (Match num in matches)
                {
                    var numRel = num.Index % length;
                    var numLen = num.Value.Length;

                    var relIndex = spec.Index % length;
                    if (specRel <= (numRel + numLen) && specRel >= (numRel - 1) && (Math.Abs(num.Index - spec.Index) <= length + numLen + 1))
                    {
                        parts.Add(int.Parse(num.Value));
                        part++;
                    }
                    if (part > 2)
                        break;
                }

                if(part == 2)
                    running += (parts[0] * parts[1]);

            }

            Console.WriteLine("Day 3 - Part 2: " + running);
        }

    }
}
