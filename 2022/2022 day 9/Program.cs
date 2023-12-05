namespace Day9
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

            string[] split =  input.Split("\n");
            List<Position> previousLocations = new List<Position>();
            List<Instruction> instructions = new List<Instruction>();
            Position head = new Position(0, 0);
            Position tail = new Position(0, 0);

            foreach (string s in split) {
                instructions.Add(new Instruction(s));
            }

            foreach (Instruction i in instructions) {
                if (i.direction == 'L') {

                } else if (i.direction == 'R') {

                } else if (i.direction == 'U') {
                    
                } else if (i.direction == 'D') {
                    
                }
            }
            
        }

        struct Position{
            public Position(int x, int y) {
                this.x = x;
                this.y = y;
            }

            public int x {get; set;}
            public int y {get; set;}
        }
        struct Instruction{
            public Instruction(string s) {
                direction = s.Split(" ")[0][0];
                repeats = Convert.ToInt32(s.Split(" ")[1]);
            }

            public int repeats {get; set;}
            public char direction {get; set;}
        }
    }
}            