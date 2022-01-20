using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day10
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = File.ReadAllLines("../../../Data/input.txt").ToList();

            var NavigationSystem = new NavigationSystem(input);

            var partOneResult = NavigationSystem.GetSyntaxErrorScore();
            var partTwoResult = NavigationSystem.GetMiddleScore();

            Console.WriteLine($"{partOneResult}");
            Console.WriteLine($"{partTwoResult}");
        }
    }    
}