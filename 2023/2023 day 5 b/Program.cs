using System.Globalization;

namespace Day
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader("input");

            string[] splitInput = sr.ReadLine().Split("\n");
            string[] seedString = splitInput[0].Split(" ");
            List<map>[] maps = new List<map>[7];

            for (int i = 0; i < 7; i++) {

                maps[i] = new List<map>();
            }

            sr.ReadLine();
            sr.ReadLine();

            int currentMapIndex = 0;

            while (!sr.EndOfStream) {
                string line = sr.ReadLine();
                if (line == "") {
                    currentMapIndex++;
                } else if (!line.Contains(':')) {
                    maps[currentMapIndex].Add(new map(line));
                }
            }
            long min = long.MaxValue;

            for (int i = 0; i < (seedString.Length-1); i+=2) {
                for (int j = 0; j < Convert.ToInt64(seedString[i+2]); j++) {
                    long seed = Convert.ToInt64(seedString[i+1]) + j;
                    foreach (List<map> layer in maps) {
                        bool hasMoved = false;
                        foreach (map m in layer) {
                            if (!hasMoved && seed >= m.startSource && seed <= m.endSource) {
                                seed = seed - m.startSource + m.startDestination;
                                hasMoved = true;
                            }
                        }
                    }

                    if (seed < min) {
                        min = seed;
                    }

                    if (j%10000==0) {
                        Console.Clear();
                        Console.WriteLine((float)i / (seedString.Length-1) + (float)j / Convert.ToInt64(seedString[i+2]) / (seedString.Length-1));
                    }
                }
            }

            Console.WriteLine(min);
        }
        struct map{
            public map (string s) {
                string[] split = s.Split(" ");
                startDestination = Convert.ToInt64(split[0]);
                startSource = Convert.ToInt64(split[1]);
                range = Convert.ToInt64(split[2]);
            }

            public long startDestination {get; set;}
            public long startSource {get; set;}
            public long range {get; set;}
            public long endSource {get {return startSource + range - 1;}}
            public long endDestination {get {return startDestination + range - 1;}}
        }
    }
}