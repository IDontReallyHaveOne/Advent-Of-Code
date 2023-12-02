namespace Day
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

            string[] inputs = input.Split("\n");

            List<List<string>> gay = new List<List<string>>();

            foreach (string s in inputs) {
                string cut = s.Split(":")[1];
                gay.Add(cut.Split(";").ToList());
            }

            int total = 0;

            for (int i = 0; i < gay.Count; i++) {
                bool isOk =  true;
                List<string> subGames = gay[i];
                int blue = 0;
                int red = 0;
                int green = 0;
                foreach (string subGame in subGames) {
                    string[] balls = subGame.Split(",");
                    foreach (string s in balls) {
                        string ball = s;
                        ball = ball.Trim();
                        int num = 0;
                        bool finishedNum = false;
                        while (!finishedNum) {
                            if (ball[0] == ' ') {
                                finishedNum = true;
                            } else {
                                num = num * 10 + Convert.ToInt32(ball[0].ToString());
                            }
                            ball = ball.Substring(1);
                        }

                        if (ball == "green" && num > green) {
                            green = num;
                        } else if (ball == "red" && num > red) {
                            red = num;
                        } else if (ball == "blue" && num > blue) {
                            blue = num;
                        }
                        Console.WriteLine($"{ball} {num}");
                    }

                }

                total += blue * red * green;

            }

            Console.WriteLine(total);
        }
    }
}            