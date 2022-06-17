using System;

namespace TreeDepth
{
    class Program
    {
        static void Main(string[] args)
        {
            Tree<string> tree = new Tree<string>("Root")
                .Add(new Tree<string>("L")
                    .Add(new Tree<string>("LL"))
                )
                .Add(new Tree<string>("R")
                    .Add(new Tree<string>("RL")
                        .Add(new Tree<string>("RLL"))
                    )
                    .Add(new Tree<string>("RC")
                        .Add(new Tree<string>("RCL")
                            .Add("RCLC")
                        )
                        .Add("RCR")
                    )
                    .Add("RR")
                )
                ;

            tree.ForEach((string node, int depth) =>
                {
                    for (int i = 0; i < depth; i++)
                    {
                        Console.Write("  ");
                    }
                    Console.WriteLine(node);
                }
            );

            Console.WriteLine("Depth: " + tree.Depth());
        }
    }
}
