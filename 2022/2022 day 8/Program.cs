using System.ComponentModel;
using System.Numerics;

namespace Day8
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
            int[,] numbers = new int[splitInput.Length, splitInput[0].Length];

            for (int x = 0; x < splitInput.Length; x++) {
                for (int y = 0; y < splitInput[0].Length; y++) {
                    numbers[x, y] = Convert.ToInt32(splitInput[x][y]); //convert to string
                }
            }

            int bestScenic = 0;

            for (int x = 0; x < splitInput.Length; x++) {
                for (int y = 0; y < splitInput[0].Length; y++) { 
                    int targetHeight = numbers[x, y];
                    int upView = 0;
                    int downView = 0;
                    int leftView = 0;
                    int rightView = 0;

                    // int currrentX = x-1;
                    // while (currrentX != -1 && numbers[currrentX, y] < targetHeight) {
                    //     currrentX--;
                    //     leftView++;
                    // }

                    // currrentX = x+1;
                    // while (currrentX != splitInput.Length && numbers[currrentX, y] < targetHeight) {
                    //     currrentX++;
                    //     rightView++;
                    // }

                    // int currrentY = y-1;
                    // while (currrentY != -1 && numbers[x, currrentY] < targetHeight) {
                    //     currrentY--;
                    //     upView++;
                    // }

                    // currrentY = y+1;
                    // while (currrentY != splitInput[0].Length && numbers[x, currrentY] < targetHeight) {
                    //     currrentY++;
                    //     downView++;
                    // }

                    int currrentX = x-1;
                    while (currrentX != -1 && numbers[currrentX, y] < targetHeight) {
                        currrentX--;
                        leftView++;
                    }
                    if (currrentX != -1) {
                        leftView++;
                    }

                    currrentX = x+1;
                    while (currrentX != splitInput.Length && numbers[currrentX, y] < targetHeight) {
                        currrentX++;
                        rightView++;
                    }
                    if (currrentX != splitInput.Length) {
                        rightView++;
                    }

                    int currrentY = y-1;
                    while (currrentY != -1 && numbers[x, currrentY] < targetHeight) {
                        currrentY--;
                        upView++;
                    }
                    if (currrentY != -1) {
                        upView++;
                    }

                    currrentY = y+1;
                    while (currrentY != splitInput[0].Length && numbers[x, currrentY] < targetHeight) {
                        currrentY++;
                        downView++;
                    }
                    if (currrentY != splitInput[0].Length) {
                        downView++;
                    }
                    

                    int score = leftView * rightView * upView * downView;
                Console.WriteLine($"{targetHeight - 48}: {leftView} {rightView} {upView} {downView}");
                    if (bestScenic < score) {
                        bestScenic = score;
                    }
                }
            }

            Console.WriteLine(bestScenic);
        }
    }
}            