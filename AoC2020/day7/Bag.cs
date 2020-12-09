using System.Collections.Generic;
using System.Linq;

namespace AoC2020.day7
{
    public class Bag
    {
        public string Colour { get; }
        public Dictionary<string, int> Contents { get; }

        public Bag(string colour)
        {
            Contents = new Dictionary<string, int>();
            Colour = colour;
        }
        
        
        

        /*public Bag ReturnChildWithName(Bag)
        {
            var foundBags = _internalBags.Where(x => x.Name == childName).ToList();
            return foundBags.Any() ? foundBags[0] : null;
        }

        public List<string> GetInternalBagNames => _internalBags.Select(x => x.Name).ToList();
        public List<Bag> GetInternalBags => _internalBags;*/
    }
}