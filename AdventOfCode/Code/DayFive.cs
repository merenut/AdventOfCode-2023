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

        public DayFive(string path) : base(path)
        {
        }

        internal void SolutionPartOne()
        {
            LoadMaps();

            seeds.ForEach(s =>
            {
                MapSeed(maps, s);
            });
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

        internal void MapSeed(List<List<string>> maps, string seed)
        {
            var intSeed = int.Parse(seed);

            maps.ForEach(m =>
            {
                m.ForEach(s => {
                    var parse = s.Split(" ");
                    var dest = int.Parse(parse[0]);
                    var source = int.Parse(parse[1]);
                    var range = int.Parse(parse[2]);

                    if (intSeed >= source && intSeed <= source + range)
                        intSeed += (dest - source);
;
                });
            });

        }
    }
}
