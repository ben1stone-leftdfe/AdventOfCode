using System;
using System.Collections.Generic;

namespace Day3
{
    public class DiagnosticsAnalyser
    {
        private List<string> _readings;

        public DiagnosticsAnalyser(List<string> readings)
        {
            _readings = readings;
        }

        public int GetPowerConsumption()
        {
            string gamma = string.Empty;
            string epsilon = string.Empty;

            for (var b = 0; b < _readings[0].Length; b++)
            {
                var trueCount = 0;
                var falseCount = 0;

                foreach (var reading in _readings)
                {
                    if (reading[b] == '1')
                    {
                        trueCount++;
                    }
                    else
                    {
                        falseCount++;
                    }
                }

                gamma += (trueCount > falseCount) ? '1' : '0';
                epsilon += (trueCount < falseCount) ? '1' : '0';
            }

            var gammaInt = Convert.ToInt32(gamma, 2);
            var epsilonInt = Convert.ToInt32(epsilon, 2);

            return gammaInt * epsilonInt;
        }
    }
}
