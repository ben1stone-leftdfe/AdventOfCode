using System;
using System.Collections.Generic;
using System.Linq;

namespace Day3
{
    public class DiagnosticsAnalyserPart2
    {
        private List<string> _readings;
        private string OxygenRating => FilterReadings(_readings, 0, OxygenRatingFilter);
        private string Co2Rating => FilterReadings(_readings, 0, Co2RatingFilter);

        public DiagnosticsAnalyserPart2(List<string> readings)
        {
            _readings = readings;
        }

        public int LifeSupportResult() => Convert.ToInt32(OxygenRating, 2) * Convert.ToInt32(Co2Rating, 2);

        private char OxygenRatingFilter(int trueCount, int falseCount) => trueCount < falseCount ? '1' : '0';
        private char Co2RatingFilter(int trueCount, int falseCount) => trueCount >= falseCount ? '1' : '0';

        private string FilterReadings(List<string> readings, int index, Func<int, int, char> optionToKeep)
        {
            var trueCount = readings.Count(r => r[index] == '1');
            var falseCount = readings.Count - trueCount;

            readings = readings.Where(r => r[index] == optionToKeep(trueCount, falseCount)).Select(r => r).ToList();

            return (readings.Count != 1)
                ? FilterReadings(readings, index + 1, optionToKeep)
                : readings.First();
        }
    }
}
