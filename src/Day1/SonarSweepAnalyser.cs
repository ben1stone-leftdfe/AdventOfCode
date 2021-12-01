using Helpers;
using System.Collections.Generic;

namespace Day1
{
    public class SonarSweepAnalyser
    {
        public int GetDepthIncreasingCount(IList<int> report)
        {
            int increasingDepthCount = 0;

            report.ForEachWithNext((data, next) =>
            {
                if (next > data)
                {
                    increasingDepthCount++;
                }
            });

            return increasingDepthCount;
        }
    }
}
