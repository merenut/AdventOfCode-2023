using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode
{
    internal class Game
    {
        internal List<string> WinningNumbers { get; set; }
        internal List<string> Guesses { get; set; }
        internal int GameID { get; set; }
        internal int Amount { get; set; }

        public Game()
        {
            WinningNumbers = new List<string>();
            Guesses = new List<string>();
        }
        internal int GetMatches()
        {
            var matches = 0;
            Guesses.ForEach(g =>
            {
                WinningNumbers.ForEach(h =>
                {
                    if(g.Equals(h)) matches++;
                });
            });

            return matches;
        }
    }
}
