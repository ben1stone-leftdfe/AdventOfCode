using System;
using System.Collections.Generic;

namespace Helpers
{
    public static class Enumerable
    {
        public static void ForEachWithNext<T>(this IList<T> collection, Action<T, T> func)
        {
            for (int i = 0; i < collection.Count - 1; i++)
            {
                func(collection[i], collection[i + 1]);
            } 
        }

        public static void ForEachRollingGroupSumAndNextGroup(this IList<int> collection, Action<int, int> func)
        {
            for (int i = 0; i < collection.Count - 3; i++)
            {
                var group = collection[i] + collection[i + 1] + collection[i + 2];
                var nextGroup = collection[i + 1] + collection[i + 2] + collection[i + 3];

                func(group, nextGroup);
            }
        }
    }
}
