using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AoC2020.day10
{
    public class JoltDistributionFinder
    {
        public static List<long> ReadInput()
        {
            string path = GetPathToNamedSubfolder("AoC2020");
            string fPath = Path.Combine(path, "day10", "adapters.txt");
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

        public static long Part1()
        {
            var allAdaptersSorted = ReadInput().OrderBy(i => i).ToList();
            allAdaptersSorted.Add(allAdaptersSorted.Last() + 3);

            var diffs = new List<long>();
            long lower = 0;

            foreach (var adapter in allAdaptersSorted)
            {
                diffs.Add(adapter - lower);
                lower = adapter;
            }

            var oners = diffs.Where(x => x == 1).ToList().Count;
            var threers = diffs.Where(x => x == 3).ToList().Count;
            return oners * threers;
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