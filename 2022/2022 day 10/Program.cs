namespace Day
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input;
            using (var sr = new StreamReader("input"))
            {
                input = sr.ReadToEnd();
            }
            Console.WriteLine(input);
            //Start code here

            string[] splitInput = input.Split(" ");
            int instructionNum = splitInput.Length;
            List<Instruction> instructions = new ();

            for (int i = 0; i < instructionNum; i++) {
                instructions.Add(new Instruction(splitInput[i]));
            }

            int currentCycle = 0;
            while (instructions.Count != 0) {
                instructions.RemoveAt(0);

                currentCycle++;
            }

        }

        struct Instruction {
            public Instruction(string s) {
                bool isNoop = s.Split(" ")[0] == "noop";
                if (!isNoop) {
                    value = Convert.ToInt32(s.Split(" ")[1]);
                }
            }

            public bool isNoop;
            public int value;
        }
    }
}