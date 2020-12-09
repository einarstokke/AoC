using System;
using System.Linq;
using AoC2020.day7;

namespace AoC2020
{
    class Program
    {
        static void Main(string[] args)
        {
            var bags = BagReader.ReadAllBags();
            var bagDict = bags.ToDictionary(x => x.Colour, x => x);
            
            //var allBagParents = BagReader.FindBagInBags("shiny gold", bags);
            //Console.WriteLine(allBagParents.Count);
            //Console.WriteLine(bags.Count);
            //var shite = bags.GroupBy(x => x.Colour).Select(x => x.First()).ToList().Count;

            var shite = BagReader.FindBagsInBag("shiny gold", bagDict, 1);
            Console.WriteLine(shite);

        }
    }
}
