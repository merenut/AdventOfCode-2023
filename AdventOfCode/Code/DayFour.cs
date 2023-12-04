using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Code
{
    internal class DayFour : Day
    {
        Dictionary<List<string>, int> numScoreCard = new Dictionary<List<string>, int>();
        List<Game> games = new List<Game>();
        public DayFour(string path) : base(path)
        {
        }

        internal void SolutionPartOne()
        {
            var lines = input.Split("\n");
            var running = 0;

            foreach(var line in lines)
            {
                var parse = line.Split(":")[1].Trim().Split("|");

                var winning = parse[0].Trim().Split(" ").Where(x => !string.IsNullOrWhiteSpace(x));
                var guesses = parse[1].Trim().Split(" ").Where(x => !string.IsNullOrWhiteSpace(x));

                var cardworth = 0;

                foreach (var item in guesses)
                {
                    foreach (var item1 in winning)
                    {

                        if (item.Equals(item1))
                        {
                            if (cardworth == 0)
                                cardworth++;
                            else cardworth *= 2;
                        }
                    }
                }
                running += cardworth;

            }

            Console.WriteLine("Day 4 - Part 1: " + running);
        }

        internal void SolutionPartTwo()
        {
            PopulateGames();
            var running = 0;

            games.ForEach(x =>
            {
                var score = x.GetMatches();
                for (var i = 0; i < x.Amount; i++)
                {
                    IncrementGameIds(x.GameID, score);
                }
            });

            Console.WriteLine("Day 4 - Part 2: " + games.Sum(x => x.Amount));
        }

        internal void PopulateGames()
        {
            var lines = input.Split("\n");
            int gameId = 1;
            foreach (var line in lines)
            {
                var parse = line.Split(":")[1].Trim().Split("|");

                var winning = parse[0].Trim().Split(" ").Where(x => !string.IsNullOrWhiteSpace(x));
                var guesses = parse[1].Trim().Split(" ").Where(x => !string.IsNullOrWhiteSpace(x));

                Game game = new Game();
                game.WinningNumbers.AddRange(winning);
                game.Guesses.AddRange(guesses);
                game.Amount = 1;
                game.GameID = gameId;

                games.Add(game);

                gameId++;
            }
        }

        internal void IncrementGameIds(int currentId, int score)
        {
            for(int i = 0; i < score; i++)
            {
                if (currentId + i> games.Count)
                    break;
                games[currentId + i].Amount = games[currentId + i].Amount + 1;
            }
        }
    }
}
