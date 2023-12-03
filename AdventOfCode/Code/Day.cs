using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Code
{
    internal class Day
    {
        internal string input;
        public Day(string path)
        {

            if (string.IsNullOrWhiteSpace(path))
                return;

            var workDir = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName + "\\Inputs\\";
            input = File.ReadAllText(workDir + path);
        }
        public Day()
        {

        }
    }
}
