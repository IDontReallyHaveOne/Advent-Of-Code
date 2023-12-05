using System.Numerics;

namespace Day3
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
            string[] splitInput = input.Split("\n", StringSplitOptions.TrimEntries);
            char[,] inputs = new char[splitInput.Length, splitInput[0].Length];
            bool[,] isSchematic = new bool[splitInput.Length, splitInput[0].Length];
            int total = 0;

            for (int x = 0; x < splitInput.Length; x++) {
                for (int y = 0; y< splitInput[0].Length; y++) {
                    inputs[x, y] = splitInput[x].ToCharArray()[y];
                }
            }

            for (int x = 0; x < splitInput.Length; x++) {
                for (int y = 0; y< splitInput[0].Length; y++) {
                    bool isPartNum = false;
                    int adjacent = 0;
                    bool mustExit = false;
                    List<Vector2> adjacentNums = new List<Vector2>();
                    if (inputs[x, y] == '*') {
                        for (int i = -1; i < 2; i++) {
                            for (int j = -1; j< 2; j++) {
                                try {
                                    if (char.IsDigit(inputs[x+i, y+j])) {
                                        if (!mustExit) {
                                            adjacentNums.Add(new Vector2(i, j));
                                            adjacent ++;
                                            mustExit = true;
                                        }
                                    } else {
                                        mustExit = false;
                                    }
                                } catch {
                                    
                                }
                            }
                            mustExit = false;
                        }

                        Console.WriteLine($"{adjacent}, {x}, {y}");

                        if (adjacent == 2) {
                            int i = (int)adjacentNums[0].X;
                            int j = (int)adjacentNums[0].Y;

                            while (y+j != -1 && char.IsDigit(inputs[x+i, y+j])) {
                                j--;
                            }

                            j++;
                            string current = "";
                            while (y+j != splitInput[0].Length && char.IsDigit(inputs[x+i, y+j])) {
                                current += inputs[x+i, y+j];
                                j++;
                            }

                            Console.WriteLine(current);
                            int num1 = Convert.ToInt32(current);

                            i = (int)adjacentNums[1].X;
                            j = (int)adjacentNums[1].Y;

                            while (y+j != -1 && char.IsDigit(inputs[x+i, y+j])) {
                                j--;
                            }

                            j++;
                            current = "";
                            while (y+j != splitInput[0].Length && char.IsDigit(inputs[x+i, y+j])) {
                                current += inputs[x+i, y+j];
                                j++;
                            }

                            total += num1 * Convert.ToInt32(current);
                        }
                    }
                }
            }

            // string current = "";
            // bool inSchematic = false;
            // for (int x = 0; x < splitInput.Length; x++) {
            //     for (int y = 0; y< splitInput[0].Length; y++) {
            //         if (char.IsDigit(inputs[x, y])) {
            //             current += inputs[x, y];
            //             if (isSchematic[x, y]) {
            //                 inSchematic = true;
            //             }
            //         } else {
            //             if (current != "") {
            //                 if (inSchematic) {
            //                     total += Convert.ToInt32(current);
            //                     Console.WriteLine($"{current} added");
            //                 } else {
            //                     Console.WriteLine($"{current} discarded");
            //                 }
            //                 current = "";
            //                 inSchematic = false;
            //             }
            //         }

            //         if (y==splitInput.Length-1) {
            //             if (current != "") {
            //                 if (inSchematic) {
            //                     total += Convert.ToInt32(current);
            //                     Console.WriteLine($"{current} added");
            //                 } else {
            //                     Console.WriteLine($"{current} discarded");
            //                 }
            //                 current = "";
            //                 inSchematic = false;
            //             }
            //         }
            //     }
            // }

            // for (int x = 0; x < splitInput.Length; x++) {
            //     for (int y = 0; y< splitInput[0].Length; y++) {
            //         Console.Write(isSchematic[x, y]?"y":"n");
            //     }
            //     Console.WriteLine();
            // }

            Console.WriteLine(total);
        }
    }
}            