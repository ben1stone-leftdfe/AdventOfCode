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
    }
}
