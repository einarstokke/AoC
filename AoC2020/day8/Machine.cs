using System.Collections.Generic;
using System.Linq;

namespace AoC2020.day8
{
    public class Machine
    {
        private readonly List<Instruction> _instructions;
        private int _index;
        private int _sum;


        public Machine()
        {
            _instructions = InstructionBuilder.Build();
            _index = 0;
            _sum = 0;
        }

        public int Main()
        {
            int currentIndex = 0;
            var instr = _instructions[currentIndex];

            while (!instr.Evaluated)
            {
                switch (instr.Operation)
                {
                    case "acc":
                        _sum += instr.Arg;
                        _index++;
                        break;
                    case "nop":
                        _index++;
                        break;
                    case "jmp":
                        _index += instr.Arg;
                        break;
                }

                instr.Evaluated = true;
                instr = _instructions[_index];
            }

            return _sum;
        }

        public List<int> Main2()
        {

            List<Instruction> allJmps = _instructions.Where(x => x.Operation == "jmp").ToList();
            List<int> allJmpIndices = allJmps.Select(x => x.Index).ToList();
            List<int> sums = new List<int>();

            for (int i = 0; i < allJmpIndices.Count; i++)
            {
                foreach (var instruction in _instructions) instruction.Evaluated = false;
                _index = 0;
                _sum = 0;
                var instr = _instructions[_index];
                _instructions[allJmpIndices[i]].Operation = "nop";

                
                while (!instr.Evaluated)
                {
                    switch (instr.Operation)
                    {
                        case "acc":
                            _sum += instr.Arg;
                            _index++;
                            break;
                        case "nop":
                            _index++;
                            break;
                        case "jmp":
                            _index += instr.Arg;
                            break;
                    }

                    instr.Evaluated = true;
                    if (_index >= _instructions.Count)
                    {
                        sums.Add(_sum);
                        break;
                    }

                    instr = _instructions[_index];
                }
                
                _instructions[allJmpIndices[i]].Operation = "jmp";
            }

            return sums;
        }
    }
}