using System.Collections.Generic;
using System.Linq;

namespace Helpers
{
    public static class FileReader
    {
        public static IList<int> ReadIntegersFromTextFile(string path)
        {
            var lines = ReadStringsFromTextFile(path);

            return lines.Select(line => int.Parse(line)).ToList();
        }

        public static IList<string> ReadStringsFromTextFile(string path)
        {
            return System.IO.File.ReadAllLines(path);
        }
    }
}
