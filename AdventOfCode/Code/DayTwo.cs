using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace AdventOfCode.Code
{
    internal class DayTwo : Day
    {
        Dictionary<string, int> max = new Dictionary<string, int>();
        public DayTwo(string path) : base(path)
        {
            max.Add("blue", 14);
            max.Add("red", 12);
            max.Add("green", 13);
        }

        internal void SolutionPartOne()
        {
            var parse = input.Split("\n");
            var running = 0;

            for(int id = 1, i = 0; i < parse.Length; i++, id++)
            {
                var possible = true;
                var newline = parse[i].Split(":")[1];
                var blockCounts = new Regex(",|;").Split(newline.Trim());

                foreach(var block in blockCounts)
                {
                    var split = block.Trim().Split(" ");
                    var num = split[0];
                    var color = split[1];
                    max.TryGetValue(color, out int maxNum);

                    if (int.Parse(num) > maxNum)
                        possible = false;
                }

                if (possible)
                    running += id;

            }

            Console.WriteLine("Day 2 - Part 1: " + running);
        }

        internal void SolutionPartTwo()
        {
            

            var parse = input.Split("\n");
            var running = 0;

            for (int id = 1, i = 0; i < parse.Length; i++, id++)
            {
                Dictionary<string, int> fewest = new Dictionary<string, int>();

                var newline = parse[i].Split(":")[1];
                var blockCounts = new Regex(",|;").Split(newline.Trim());

                foreach (var block in blockCounts)
                {
                    var split = block.Trim().Split(" ");
                    var num = int.Parse(split[0]);
                    var color = split[1];

                    if (!fewest.ContainsKey(color))
                        fewest.Add(color, num);

                    else
                    {
                        fewest.TryGetValue(color, out int value);

                        if(num > value)
                            fewest[color] = num;
                    }

                }
                fewest.TryGetValue("blue", out int blue);
                fewest.TryGetValue("red", out int red);
                fewest.TryGetValue("green", out int green);

                var power = blue * red * green;
                running+= power;
            }

            Console.WriteLine("Day 2 - Part 2: " + running);

        }
    }
}
