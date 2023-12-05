namespace Day4
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

            string[] lines = input.Split("\n");
            int tickets = lines.Length;
            string[,] cardsAsStrings = new string[tickets,2];
            List<string>[,] strings = new List<string>[tickets, 2];
            List<int>[,] nums = new List<int>[tickets, 2];

            for (int i = 0; i<tickets; i++) {
                string cards = lines[i].Split(":")[1];
                cardsAsStrings[i, 0] = cards.Split("|")[0];
                strings[i, 0] = cardsAsStrings[i, 0].Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();
                cardsAsStrings[i, 1] = cards.Split("|")[1];
                strings[i, 1] = cardsAsStrings[i, 1].Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();
            }
            
            for (int i = 0; i<tickets; i++) {
                for (int j = 0; j < 2; j++) {
                    nums[i, j] = new List<int>();
                    for (int k = 0; k < strings[i, j].Count; k++) {
                        nums[i, j].Add(Convert.ToInt32(strings[i, j][k]));
                    }
                }
            }

            int[] amount = new int[tickets];
            for (int i = 0; i<tickets; i++) {
                amount[i] = 1;
            }
            
            for (int i = 0; i<tickets; i++) {
                int current = 0;
                foreach (int x in nums[i, 0]) {
                    if (nums[i, 1].Contains(x)) {
                        current ++;
                    }
                }
                
                for (int x = 1; x <= current; x++) {
                    amount[i + x] += amount[i];
                }
            }

            Console.WriteLine(amount.Sum());
        }
    }
}            