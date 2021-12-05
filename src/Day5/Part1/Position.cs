using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day5.Part1
{
    public class Position
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Position(string input)
        {
            var coordinate = input.Split(",");

            X = int.Parse(coordinate[0]);
            Y = int.Parse(coordinate[1]);
        }        
    }
}
