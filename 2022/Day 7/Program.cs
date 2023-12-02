using System.Security.Cryptography.X509Certificates;

namespace Day7
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
            //Console.Clear();
            //Console.WriteLine(input);

            //Start code here
            string[] commands = input.Split('\n');
            int directoryIndex = 0;
            List<int> cwd = new List<int>();
            int[] sizes = new int[999];
            string[] names = new string[999];
            int total = 0;

            foreach (string command in commands) {
                string[] parts = command.Split(" ");
                if (parts[0] == "$") {
                    if (parts[1] == "cd") {
                        if (parts[2].Trim() == "..") {
                            cwd.RemoveAt(cwd.Count-1);
                        } else {
                            cwd.Add(directoryIndex);
                            names[directoryIndex] = (parts[2]);
                            directoryIndex++;
                        }
                    }
                } else {
                    if (parts[0] != "dir") {
                        foreach (int i in cwd) {
                            sizes[i] += Convert.ToInt32(parts[0]);
                        }
                        total += Convert.ToInt32(parts[0]);
                    }
                }
            }


            int target = total - 30000000;
            Console.WriteLine(total);
            Console.WriteLine(target);

            int currnet = int.MaxValue;

            foreach (int i in sizes) {
                Console.WriteLine(i);
                if (i>=target && i < currnet) {
                    currnet = i;
                    
                }
            }

            Console.WriteLine(currnet);
        }
    }
}            