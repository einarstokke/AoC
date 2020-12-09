using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;


namespace AoC2020.day7
{
    public static class BagReader
    {
        public static List<Bag> ReadAllBags()
        {
            string path = GetPathToNamedSubfolder("AoC2020");
            string fPath = Path.Combine(path, "day7", "bagList.txt");
            string line;
            var retVal = new List<Bag>();
            
            StreamReader file = new StreamReader(fPath);
            
            while((line = file.ReadLine()) != null)
            {
                retVal.Add(BagFromLine(line));
            }  
  
            file.Close();

            return retVal;
        }

        private static Bag BagFromLine(string line)
        {
            string dotRemoved = line.Replace(".", string.Empty);
            string wordBagsRemoved = dotRemoved.Replace("bags", string.Empty);
            string wordBagRemoved = wordBagsRemoved.Replace("bag", string.Empty);
            string[] parentAndChildren = wordBagRemoved.Split("contain");

            List<string> childNamesAndNumbers = parentAndChildren[1].Split(",").Select(x=>x.Trim()).ToList();
            
            
            Bag parent = new Bag(parentAndChildren[0].Trim());

            if (childNamesAndNumbers[0] == "no other") return parent;
            foreach (var nameAndNumber in childNamesAndNumbers)
            {
                string numberAsString = ExtractIntFromString(nameAndNumber);
                int number = int.Parse(numberAsString);
                string name = nameAndNumber.Replace(numberAsString, "").Trim();
                parent.Contents.Add(name, number);
            }
            
            return parent;
        }

        private static string ExtractIntFromString(string str)
        {
            string b = string.Empty;

            for (int i=0; i< str.Length; i++)
            {
                if (Char.IsDigit(str[i]))
                    b += str[i];
            }

            return b.Length > 0 ? b : string.Empty;
        }

        
        public static int FindBagsInBag(string bagName, Dictionary<string, Bag> bags, int accu)
        {
            var bag = bags[bagName];
            int newAccu = accu;

            if (bag.Contents.Count == 0)
            {
                return 1;
            }
            
            foreach (var bagSets in bag.Contents)
            {
                newAccu += accu * bagSets.Value * FindBagsInBag(bagSets.Key, bags, accu);
            }

            return newAccu;
        }

        public static List<Bag> FindBagInBags(string desiredName, List<Bag> bags)
        {
            var bagsFound = bags.Where(bag => bag.Contents.ContainsKey(desiredName)).ToList();
            var validBags = new List<Bag>();
            validBags.AddRange(bagsFound);

            if (bagsFound.Count <= 0) return bagsFound;

            foreach (var bag in bagsFound) validBags.AddRange(FindBagInBags(bag.Colour, bags));
            return validBags.Distinct().ToList();
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