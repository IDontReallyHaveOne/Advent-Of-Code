using System.Reflection.Metadata.Ecma335;

namespace Day
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader("input");

            string[] splitInput = sr.ReadLine().Split("\n");
            string[] seedString = splitInput[0].Split(" ");
            List<range> seeds = new List<range>();
            List<range> oldSeeds = new List<range>();
            List<map>[] maps = new List<map>[7];

            for (int i = 0; i < 7; i++) {

                maps[i] = new List<map>();
            }

            for (int i = 0; i < (seedString.Length-1); i+=2) {
                seeds.Add(new range(Convert.ToInt64(seedString[i+1]), Convert.ToInt64(seedString[i+1]) + Convert.ToInt64(seedString[i+2])-1));
                // for (int j = 0; j < Convert.ToInt64(seedString[i+2]); j++) {
                //     seeds.Add(Convert.ToInt64(seedString[i+1]) + j);
                //     //Console.WriteLine(Convert.ToInt64(seedString[i+1]) + j);
                // }
            }

            sr.ReadLine();
            sr.ReadLine();

            bool running = true;
            string line = "";
            int currentMapIndex = 0;

            while (!sr.EndOfStream) {
                line = sr.ReadLine();
                if (line == "") {
                    currentMapIndex++;
                } else if (!line.Contains(':')) {
                    maps[currentMapIndex].Add(new map(line));
                }
            }
            
            for (int i = 0; i < 7; i++) {
                foreach (range r in seeds) {
                    Console.WriteLine(r);
                }
                Console.WriteLine("-----------------------");


                oldSeeds = seeds;
                seeds = new List<range>();
                List<map> currentMaps = maps[i];
                foreach (map m in currentMaps) {
                    range[] oldSeedsCopy = new range[oldSeeds.Count];
                    oldSeeds.CopyTo(oldSeedsCopy);
                    oldSeeds = new List<range>();
                    foreach (range r in oldSeedsCopy) {
                        range?[] outRanges =  r.map(m);
                        if (outRanges[0] != null) {
                            seeds.Add((range)outRanges[0]);
                        }
                        oldSeeds.Add((range)outRanges[1]);
                        if (outRanges.Length == 3) {
                            oldSeeds.Add((range)outRanges[2]);
                        }
                        //oldSeeds.Remove(r);
                    }
                }

                foreach (range r in oldSeeds) {
                    seeds.Add(r);
                }

                
            }
            
            long min = 9999999;
            foreach (range r in seeds) {
                if (r.start < min) {
                    min = r.start;
                }
            }

            Console.WriteLine(min);

            sr.Close();
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
        struct range{
            public range(long start, long end) {
                this.start = start;
                this.end = end;
            }

            public override string ToString()
            {
                return $"({start}, {end})";
            }

            public range?[] map(map map) {
                if (map.startSource > this.end) {
                    Console.WriteLine("1"); // Map starts after range ended
                    return new range?[] {null, this};
                } else if (map.endSource < this.start) {
                    Console.WriteLine("2"); // Map ends before range starts
                    return new range?[] {null, this};
                } else if (false) {
                    Console.WriteLine("3"); // Map contains source range
                    return new range?[] {new range(map.startDestination - this.start, map.endDestination - this.end), new range(this.start, map.startSource-1), new range(map.endSource + 1, this.end)};
                } else if (map.endSource > this.end) {
                    Console.WriteLine("4"); // map contains begininning of range
                    return new range?[] {new range(map.startDestination, map.startDestination + (this.end - map.startSource)), new range(this.start, map.startSource-1)};
                } else if (map.startSource < this.start) {
                    Console.WriteLine("5"); // map contains end of range
                    return new range?[] {new range(this.start - map.startSource, map.endDestination), new range(map.endSource+1, this.end)};
                } else {
                    throw new Exception("Error");
                }
            }

            public long start {get; set;}
            public long end {get; set;}
        }
    }
}            