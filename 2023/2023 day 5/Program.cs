namespace Day
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader("input");

            string[] splitInput = sr.ReadLine().Split("\n");
            string[] seedString = splitInput[0].Split(" ");
            int[] seeds = new int[seedString.Length-1];
            List<map>[] maps = new List<map>[7];

            for (int i = 0; i < seeds.Length; i++) {
                seeds[i] = Convert.ToInt32(seedString[i+1]);
            }


            bool running = true;
            string line = "";
            while (!sr.EndOfStream) {
                line = sr.ReadLine();
                if (line == "") {
                    Console.WriteLine(sr.ReadLine());
                } else if (line.Contains(':')) {
                    Console.WriteLine("next");
                } else {
                    Console.WriteLine(line);
                }

            }

            sr.Close();
        }

        struct map{
            public map (string s) {
                string[] split = s.Split(" ");
                startDestination = Convert.ToInt32(split[0]);
                startSource = Convert.ToInt32(split[1]);
                range = Convert.ToInt32(split[2]);
            }

            public int startDestination {get; set;}
            public int startSource {get; set;}
            public int range {get; set;}
        }
    }
}            