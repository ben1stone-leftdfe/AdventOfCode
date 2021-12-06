using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day6
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = File.ReadAllText("../../../Data/input.txt");

            var school = new School(input);

            school.IncrementGenerations(256);

            Console.WriteLine($"Result: {school.TotalFish}");
        }
    }

    public class School
    {
        private List<Generation> _generations;

        public School(string input)
        {
            var startingFish = input.Split(",").Select(fish => int.Parse(fish)).ToList();

            _generations = startingFish.GroupBy(x => x).Select(g => new Generation(g.Key, (ulong)g.Count())).ToList();
        }

        public ulong TotalFish => _generations.Select(g => (ulong)g.FishCount).Aggregate((a, b) => a+b);
      
        public void IncrementGenerations(int generationsRemaining)
        {
            ulong babyFish = 0;

            foreach (var generation in _generations)
            {
                var numberBorn = generation.AgeGeneration();

                if (numberBorn > 0)
                {
                    babyFish += numberBorn;
                }
            }

            _generations.Add(new Generation(8, babyFish));

            generationsRemaining -= 1;

            if (generationsRemaining > 0)
            {
                IncrementGenerations(generationsRemaining);
            }
        }
    }

    public class Generation
    {
        public int DaysUntilOffspring { get; set; }
        public ulong FishCount { get; set; }

        public Generation(int daysUntil, ulong fishCount)
        {
            DaysUntilOffspring = daysUntil;
            FishCount = fishCount;
        }

        public ulong AgeGeneration()
        {
            if (DaysUntilOffspring == 0)
            {
                DaysUntilOffspring = 6;
                return FishCount;
            }

            DaysUntilOffspring -= 1;

            return 0;
        }
    }
}
