using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Day8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var sr = new StreamReader("input");
            string directions = sr.ReadLine();
            sr.ReadLine();
            
            Console.WriteLine(directions);
            List<Node> nodes = new ();
            foreach (string s in sr.ReadToEnd().Split('\n')) {
                nodes.Add(new(s));
            }

            bool running = true;
            int distance = 0;

            List<Node> currentNodes = new();

            foreach (Node n in nodes) {
                if (n.name[2] == 'A') {
                    currentNodes.Add(n);
                    //Console.WriteLine(n);
                }
            }

            for (int i = 0; i < nodes.Count; i++) {
                for (int j = 0; j < nodes.Count; j++) {
                    if (nodes[i].rightString == nodes[j].name) {
                        nodes[i].right = nodes[j];
                    }
                    if (nodes[i].leftString == nodes[j].name) {
                        nodes[i].left = nodes[j];
                    }
                }
                if (nodes[i].left == null || nodes[i].right == null) {
                        
                    throw new Exception();
                }
            }

            int len = currentNodes.Count;
            string currentDirection = "";
            List<int>[] multiple = new List<int>[len];
            for (int m = 0; m < len; m++) {
                multiple[m] = new List<int>();
            }

            while (running) {
                bool everythingEnded = distance > 1000000;
                for (int x = 0; x < len; x++) {
                    if (currentNodes[x].name[2] == 'Z') {
                        multiple[x].Add(distance);
                    }
                }

                //Console.WriteLine(currentNodes[1].name);
                // foreach (Node n in currentNodes) {
                //     if (n.name[2] != 'Z') {
                //         everythingEnded = false;
                //     }
                // }
                if (everythingEnded) {
                    running = false;
                } else {
                    distance++;
                    if (currentDirection.Length == 0) {
                        currentDirection += directions;
                    }
                    char thisDirection = currentDirection[0];
                    currentDirection = currentDirection.Substring(1);

                    for (int i = 0; i < currentNodes.Count; i++) {
                        
                        if (thisDirection == 'L') {
                            currentNodes[i] = (Node)currentNodes[i].left;
                        } else {
                            currentNodes[i] = (Node)currentNodes[i].right;
                        }
                    }
                }
                // if (distance % 10000 == 0) {
                //     Console.Clear();
                //     Console.WriteLine(distance);
                // }
            }

            foreach(List<int> m in multiple) {
                Console.WriteLine(m[0]);
            }
            long f = 21003205388313;
            bool Running = true;
            while (Running) {
                bool answer = true;
                foreach(List<int> m in multiple) {
                    if (f % m[0] != 0) {
                        answer = false;
                    }
                }
                if (answer && f!=0) {
                    Console.WriteLine(f);
                    Running = false;
                }
                f++;
            }

            //Console.WriteLine(distance);
        }

        class Node {
            public Node(string constructor) {
                this.name = constructor.Substring(0, 3);
                this.leftString = constructor.Substring(7, 3);
                this.rightString = constructor.Substring(12, 3);
            }

            // public override string ToString()
            // {
            //     return $"{name} - {left}, {right}";
            // }

            public string name {get; set;}
            public string leftString;
            public string rightString;
            public object? left {get; set;}
            public object? right {get; set;}

        }
    }
}