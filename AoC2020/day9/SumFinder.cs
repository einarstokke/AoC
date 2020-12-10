using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AoC2020.day9
{
    public class SumFinder
    {
        public static List<long> ReadInput()
        {
            string path = GetPathToNamedSubfolder("AoC2020");
            string fPath = Path.Combine(path, "day9", "xmas.txt");
            string line;
            var retVal = new List<long>();

            StreamReader file = new StreamReader(fPath);

            while ((line = file.ReadLine()) != null)
            {
                retVal.Add(long.Parse(line.Trim()));
            }

            file.Close();
            return retVal;
        }

        public static long Part2()
        {
            List<long> source = ReadInput();
            var range = FindContiguousRangeFromBelow(source);

            if (range.Count>0)
            {
                return range.Min() + range.Max();
            }

            return -1;
        }


        public static List<long> FindContiguousRangeFromBelow(List<long> source)
        {


            for (int i = 0; i < source.Count; i++)
            {
                long target = 36845998;

                for (int lBoundIndex = i; lBoundIndex>=0; lBoundIndex--)
                {
                    var window = source.GetRange(lBoundIndex, i - lBoundIndex);
                    long sum = window.Sum();
                    
                    if (sum == target)
                    {
                        return window;
                    }

                    if (sum > target)
                    {
                        break;
                    }
                }
            }
            
            return new List<long>();
        }


        public static long FindFirstOccurenceOfMissingSum()
        {
            int windowSize = 25;
            List<long> source = ReadInput();

            for (int i = windowSize; i < source.Count; i++)
            {
                var window = source.GetRange(i - windowSize, windowSize);
                var sums = GeneratePairSums(window);
                long compareTo = source[i];

                if (sums.IndexOf(compareTo) == -1)
                {
                    return compareTo;
                }
            }

            return -1;
        }


        public static List<long> GeneratePairSums(List<long> input)
        {
            var sums = new List<long>();

            for (int i = 0; i < input.Count; i++)
            {
                for (int j = 0; j < input.Count; j++)
                {
                    if (i != j && j < i)
                    {
                        sums.Add(input[i] + input[j]);
                    }
                }
            }

            return sums.Distinct().ToList();
        }


        private static string GetPathToNamedSubfolder(string folderName, int nLevelsUp = 0)
        {
            var dllDir = Directory.GetCurrentDirectory();
            var folders = dllDir.Split('\\');
            var folderList = folders.ToList();
            int folderLevel = folderList.IndexOf(folderName);
            folderList.RemoveRange(folderLevel + 1 - nLevelsUp, folderList.Count - folderLevel - 1 + nLevelsUp);
            return Path.Combine(folderList.ToArray());
        }
    }
}