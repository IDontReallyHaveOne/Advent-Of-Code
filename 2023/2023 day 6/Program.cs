namespace Day6
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
            List<string> timeStrings = input.Split("\n")[0].Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();
            timeStrings.RemoveAt(0);
            List<string> distanceStrings = input.Split("\n")[1].Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();
            distanceStrings.RemoveAt(0);

            int length = timeStrings.Count;

            //int[] nums = new int[length];

            long time = Convert.ToInt64(timeStrings[0] + timeStrings[1] + timeStrings[2] + timeStrings[3]);
            long targetDistance = Convert.ToInt64(distanceStrings[0] + distanceStrings[1] + distanceStrings[2] + distanceStrings[3]);

            int possibilities = 0;
            for (long j = 0; j <= time; j++) {
                long distance = j * (time - j);
                if (distance > targetDistance) {
                    possibilities++;
                }
            }

            Console.WriteLine(possibilities);
            // nums[i] = possibilities;

            // int total = 1;
            // foreach (int i in nums) {
            //     total *= i;
            // }

            // Console.WriteLine(total);
        }
    }
}