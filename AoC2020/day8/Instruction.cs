namespace AoC2020.day8
{
    public class Instruction
    {
        public string Operation { get; set; }
        public int Arg { get; }
        public bool Evaluated { get; set; }
        
        public int Index { get; set; }
        
        public Instruction(string operation, int arg)
        {
            Operation = operation;
            Arg = arg;
        }
    }
}