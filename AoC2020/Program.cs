using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using AoC2020.day10;
using AoC2020.day7;
using AoC2020.day8;
using AoC2020.day9;
using Microsoft.VisualBasic;

namespace AoC2020
{
    class Program
    {
        static void Main(string[] args)
        {
            // Day 7
            // _______________________________________________________________________________________________
            
            // 7.1
            var bags = BagReader.ReadAllBags();
            var bagDict = bags.ToDictionary(x => x.Colour, x => x);

            var allBagParents = BagReader.FindBagInBags("shiny gold", bags);
            Console.WriteLine($"Answer 7.1: {allBagParents.Count}");

            // 7.2

            var allBagContents = BagReader.FindBagsInBag("shiny gold", bagDict, 1);
            Console.WriteLine($"Answer 7.2: {allBagContents-1}");

            // Day 8
            // ________________________________________________________________________________________________
            
            
            var machina = new Machine();
            
            // 8.1
            
            Console.WriteLine($"Answer 8.1: {machina.Main()}");
            
            
            // 8.2
            
            var sums =machina.Main2();
            Console.WriteLine($"Answer 8.2: {sums[0]}");


            // Day 9
            // ________________________________________________________________________________________________
            
            
            // 9.1
            
            Console.WriteLine($"Answer 9.1: {SumFinder.FindFirstOccurenceOfMissingSum()}");
            
            // 9.2
            
            Console.WriteLine($"Answer 9.2: {SumFinder.Part2()}");
            
            
            // Day 10
            // ________________________________________________________________________________________________
            
            
            // 10.1
            
            Console.WriteLine($"Answer 10.1: {JoltDistributionFinder.Part1()}");
            
            // 10.2
            
            

        }
    }
}