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

            bool givenValue = false;
            for (int i = 0; i<input.Length-14; i++) {
                char[] four = input.Substring(i, 14).ToCharArray();
                bool foundStart = true;
                for (int x = 0; x<14; x++) {
                    for (int y = 0; y<14; y++) {
                        if (four[x] == four[y] && x != y) {
                            foundStart = false;
                        }
                    }
                }

                if (foundStart && !givenValue) {
                    Console.WriteLine(i+14);
                    givenValue = true;
                }
            }
        }
    }
}