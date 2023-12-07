using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode
{
    internal class SeedThread
    {
        long seed {  get; set; }
        List<List<string>> maps = new List<List<string>>();
        Dictionary<long, long> seedRanges = new Dictionary<long, long>();
        internal long lowest { get; set; }

        internal SeedThread(long seed, List<List<string>> maps, Dictionary<long, long> seedRanges)
        {
            this.seed = seed;
            this.maps.AddRange(maps);
            this.seedRanges = seedRanges;
            lowest = long.MaxValue;
        }

        public void GetLowest()
        {
            for (long i = 0; i < seedRanges.GetValueOrDefault(seed); i++)
            {
                MapSeed(maps, seed + i);
            }
        }

        internal void MapSeed(List<List<string>> maps, long seed)
        {
            var intSeed = seed;

            foreach (var m in maps)
            {
                foreach (var s in m)
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

            if (intSeed < lowest)
                lowest = intSeed;
        }

    }
}
