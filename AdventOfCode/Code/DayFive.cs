using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Code
{
    internal class DayFive : Day
    {
        List<List<string>> maps = new List<List<string>>();
        List<string> seeds = new List<string>();
        Dictionary<long, long> seedRanges = new Dictionary<long, long>();
        List<long> locations = new List<long>();
        long lowest = long.MaxValue;
        List<SeedThread> seedInfo = new List<SeedThread>();
        List<Thread> threads = new List<Thread>();

        public DayFive(string path) : base(path)
        {
        }

        internal void SolutionPartOne()
        {
            LoadMaps();

            seeds.ForEach(s =>
            {
                MapSeed(maps, Int64.Parse(s));
            });

            Console.WriteLine("Day 5 - Part 1: " + lowest);
        }
        internal void LoadMaps()
        {
            var lines = input.Split("\r\n\r\n");

            seeds.AddRange(lines[0].Split(":")[1].Split(" ").Where(x => !string.IsNullOrWhiteSpace(x)));

            for (int i = 1; i < lines.Length; i++)
            {
                var noHead = lines[i].Trim().Split(":");
                var map = noHead[1].Split("\r\n").Where(x => !string.IsNullOrWhiteSpace(x));
                maps.Add(map.ToList());
            }
        }

        internal void MapSeed(List<List<string>> maps, long seed)
        {
            var intSeed = seed;
            
            foreach(var m in maps)
            {
                foreach(var s in m)
                {
                    var parse = s.Split(" ");
                    var dest = Int64.Parse(parse[0]);
                    var source = Int64.Parse(parse[1]);
                    var range = Int64.Parse(parse[2]);

                    if (intSeed >= source && intSeed < source + range)
                    {
                        intSeed += (dest - source);
                        break;
                    }
                }
            }

            if(intSeed < lowest)
                lowest = intSeed;
        }

        internal void SolutionPartTwo()
        {
            lowest = long.MaxValue;
            LoadMapsPart2();

            seedRanges.Keys.ToList().ForEach(s =>
            {
                SeedThread st = new SeedThread(s, maps, seedRanges);
                Thread t = new Thread(new ThreadStart(st.GetLowest));

                seedInfo.Add(st);
                threads.Add(t);

                t.Start();
            });

            threads.ForEach(s => s.Join());

            Console.WriteLine("Day 5 - Part 2: " + seedInfo.Min(x => x.lowest));
        }

        internal void LoadMapsPart2()
        {
            for(int i = 0; i < seeds.Count; i+=2)
            {
                seedRanges.Add(Int64.Parse(seeds[i]), Int64.Parse(seeds[i+1]));
            }
        }
    }
}
