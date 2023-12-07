using System.Numerics;
using System.Runtime.InteropServices;

namespace Day9
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

            //Console.WriteLine(input);

            string[] split =  input.Split("\n");
            List<Vector2> previousLocations = new List<Vector2>();
            List<Instruction> instructions = new List<Instruction>();

            Position tail = new Position(0, 0);
            List<ConnectedPosition> others = new List<ConnectedPosition>();

            for (int i = 0; i < 9; i++) {
                if (others.Count == 0) {
                    others.Add(new ConnectedPosition(0, 0, tail));
                } else {
                    others.Add(new ConnectedPosition(0, 0, others[others.Count - 1]));
                }
            }

            ConnectedPosition head = others[others.Count - 1];

            foreach (string s in split) {
                instructions.Add(new Instruction(s));
            }

            foreach (Instruction instruction in instructions) {
                for (int i = 0; i < instruction.repeats; i++) {
                    charDirections.TryGetValue(instruction.direction, out Vector2 moveVector);
                    head.Move(moveVector);

                    if (!previousLocations.Contains(tail.position)) {
                        previousLocations.Add(tail.position);
                    }
                }
            }

            Console.WriteLine(previousLocations.Count);
        }

        static Dictionary<char, Vector2> charDirections = new() {{'L', -Vector2.UnitX}, {'R', Vector2.UnitX}, {'U', Vector2.UnitY}, {'D', -Vector2.UnitY}};

        class Position{
            public Position(int x, int y) {
                position = new Vector2(x, y);
            }

            public override string ToString()
            {
                return $"{position}";
            }

            public virtual void Move(Vector2 move) {
                position += move;
            }

            public Vector2 position {get; set;}
        }

        class ConnectedPosition : Position {
            public ConnectedPosition(int x, int y, Position child) : base(x, y) {
                this.child = child;
            }

            public override void Move(Vector2 move) {
                base.Move(move);
                if ((this.position - child.position).LengthSquared() >= 4) {
                    child.Move(new Vector2(Math.Sign(this.position.X - child.position.X), Math.Sign(this.position.Y - child.position.Y)));
                }
            }
            public Position child {get; set;}
        }

        struct Instruction{
            public Instruction(string s) {
                direction = s.Split(" ")[0][0];
                repeats = Convert.ToInt32(s.Split(" ")[1]);
            }

            public int repeats {get; set;}
            public char direction {get; set;}
        }
    }
}            