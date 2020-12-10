using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AoC2020.day8
{
    public static class InstructionBuilder
    {
        public static List<Instruction> Build()
        {
            string path = GetPathToNamedSubfolder("AoC2020");
            string fPath = Path.Combine(path, "day8", "instructions.txt");
            string line;
            int index = 0;
            var retVal = new List<Instruction>();
            
            StreamReader file = new StreamReader(fPath);
            
            while((line = file.ReadLine()) != null)
            {
                retVal.Add(BuildInstructionFromString(line, index));
                index++;
            }  
  
            file.Close();

            return retVal;
        }

        private static Instruction BuildInstructionFromString(string line, int index)
        {
            string plusRemoved = line.Replace("+", string.Empty);
            string[] instrAndArg = plusRemoved.Split(null);

            string instr = instrAndArg[0];
            int arg = int.Parse(instrAndArg[1]);

            var instrObject = new Instruction(instr, arg);
            instrObject.Index = index;
            return instrObject;
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