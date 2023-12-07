using System.Reflection.Metadata.Ecma335;

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

            Console.WriteLine(input);
            //Start code here

            List<Hand> hands = new();
            foreach (string s in input.Split("\n")) {
                hands.Add(new Hand(s));
            }

            long[] values = new long[hands.Count];

            for (int i = 0; i < hands.Count; i++) {
                Console.WriteLine(hands[i]);
                values[i] = hands[i].Value();
            }

            Array.Sort(values);

            long total = 0;

            foreach (Hand h in hands) {
                //values.Add(h.Value());
                total += h.weight * (Array.IndexOf(values, h.Value()) + 1);
            }

            Console.WriteLine(total);
        }

        struct Hand{
            public Hand(string text) {
                for (int i = 0; i < 5; i++) {
                    cardTypes.TryGetValue(text.Split(" ")[0][i], out int num);
                    this.cards[i] = num;
                }
                weight = Convert.ToInt32(text.Split(" ")[1]);
            }

            public override string ToString()
            {
                string s = "";
                foreach (int i in cards) {
                    s += $"{i} | ";
                }
                return $"{s}{weight} | {HandType()} | {Value()}";
            }

            public int[] cards = new int[5];
            public int weight {get; set;}

            public long Value() {
                //return HandType();
                return 100000000 * this.HandType() + (long)Math.Pow(15, 4) * cards[0] + (long)Math.Pow(15, 3) * cards[1] + (long)Math.Pow(15, 2) * cards[2] + (long)Math.Pow(15, 1) * cards[3] + cards[4];
            }
            public int HandType() {
                int[] nums = new int[15];

                foreach (int i in cards) { //10300100313
                    nums[i]++;
                }

                int jokers = nums[1];
                nums[1] = 0;

                bool hasGotFour = false;
                bool hasGotThree = false;
                int pairs = 0;

                foreach (int i in nums) {
                    if (i == 5) {
                        return 6;
                    } else if (i == 4) {
                        hasGotFour = true;
                    } else if (i == 3) {
                        hasGotThree = true;
                    } else if (i == 2) {
                        pairs++;
                    }
                }

                if (hasGotFour) {
                    if (jokers == 1) {
                        return 6;
                    } else {
                        return 5;
                    }
                } else if (hasGotThree) {
                    if (jokers == 2) {
                        return 6;
                    } else if (jokers == 1)
                    {
                        return 5;
                    } else {
                        if (pairs == 1) {
                            return 4;
                        } else {
                            return 3;
                        }
                    }
                } else if (pairs == 2) {
                    if (jokers == 1) {
                        return 4;
                    } else {
                        return 2;
                    }
                } else if (pairs == 1) {
                    if (jokers == 3) {
                        return 6;
                    } else if (jokers == 2) {
                        return 5;
                    } else if (jokers == 1) {
                        return 3;
                    } else {
                        return 1;
                    }
                } else {
                    if (jokers == 5) {
                        return 6;
                    } else if (jokers == 4) {
                        return 6;
                    } else if (jokers == 3) {
                        return 5;
                    } else if (jokers == 2) {
                        return 3;
                    } else if (jokers == 1) {
                        return 1;
                    } else {
                        return 0;
                    }
                }
            }
        }

        static Dictionary<char, int> cardTypes = new() {{'2', 2}, {'3', 3}, {'4', 4}, {'5', 5}, {'6', 6}, {'7', 7}, {'8', 8}, {'9', 9}, {'T', 10}, {'J', 1}, {'Q', 12}, {'K', 13}, {'A', 14}};
    }
}