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
                    if (instruction.direction == 'L') {
                        head.Move(-Vector2.UnitX);
                    } else if (instruction.direction == 'R') {
                        head.Move(Vector2.UnitX);
                    } else if (instruction.direction == 'U') {
                        head.Move(Vector2.UnitY);
                    } else if (instruction.direction == 'D') {
                        head.Move(-Vector2.UnitY);
                    }

                    bool inList = false;
                    foreach (Vector2 p in previousLocations) {
                        if (p == tail.position) {
                            inList = true;
                        }
                    }
                    
                    if (!inList) {
                        previousLocations.Add(tail.position);
                    }
                }
            }
            
            Console.WriteLine(head);
            Console.WriteLine(previousLocations.Count);
        }

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


                if (this.position.X - child.position.X == 2) {
                    switch (this.position.Y - child.position.Y) {
                        case 0:
                            child.Move(Vector2.UnitX);
                            break;
                        case 1:
                            child.Move(Vector2.UnitX + Vector2.UnitY);
                            break;
                        case 2:
                            child.Move(Vector2.UnitX + Vector2.UnitY);
                            break;
                        case -1:
                            child.Move(Vector2.UnitX - Vector2.UnitY);
                            break;
                        case -2:
                            child.Move(Vector2.UnitX - Vector2.UnitY);
                            break;
                        default:
                            throw new Exception("sefio");
                    }
                } else if (this.position.X - child.position.X == -2) {
                    switch (this.position.Y - child.position.Y) {
                        case 0:
                            child.Move(-Vector2.UnitX);
                            break;
                        case 1:
                            child.Move(-Vector2.UnitX + Vector2.UnitY);
                            break;
                        case 2:
                            child.Move(-Vector2.UnitX + Vector2.UnitY);
                            break;
                        case -1:
                            child.Move(-Vector2.UnitX - Vector2.UnitY);
                            break;
                        case -2:
                            child.Move(-Vector2.UnitX - Vector2.UnitY);
                            break;
                        default:
                            throw new Exception("sefio");
                    }
                }

                if (this.position.Y - child.position.Y == 2) {
                    switch (this.position.X - child.position.X) {
                        case 0:
                            child.Move(Vector2.UnitY);
                            break;
                        case 1:
                            child.Move(Vector2.UnitY + Vector2.UnitX);
                            break;
                        case 2:
                            child.Move(Vector2.UnitY + Vector2.UnitX);
                            break;
                        case -1:
                            child.Move(Vector2.UnitY - Vector2.UnitX);
                            break;
                        case -2:
                            child.Move(Vector2.UnitY - Vector2.UnitX);
                            break;
                        default:
                            throw new Exception("sefio");
                    }
                } else if (this.position.Y - child.position.Y == -2) {
                    switch (this.position.X - child.position.X) {
                        case 0:
                            child.Move(-Vector2.UnitY);
                            break;
                        case 1:
                            child.Move(-Vector2.UnitY + Vector2.UnitX);
                            break;
                        case 2:
                            child.Move(-Vector2.UnitY + Vector2.UnitX);
                            break;
                        case -1:
                            child.Move(-Vector2.UnitY - Vector2.UnitX);
                            break;
                        case -2:
                            child.Move(-Vector2.UnitY - Vector2.UnitX);
                            break;
                        default:
                            throw new Exception("sefio");
                    }
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