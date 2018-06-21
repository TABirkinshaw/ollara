using System;

namespace Ollara
{
    class main
    {
        static void Main(string[] args)
        {
            MainMenu();

            // Keep everything open for debugging
            // Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }

        static void MainMenu()
        {
            Console.WriteLine("Welcome to Ollara!");
            bool selected = true;
            do
            {
                selected = true;
                Console.WriteLine("[1]  New Game");
                Console.WriteLine("[2]  Continue");
                Console.WriteLine("[3]  Past Games");
                Console.WriteLine("[X]  Exit");

                Console.Write(" > ");
                String input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        Console.WriteLine("Starting new game!");
                        break;
                    case "2":
                        Console.WriteLine("Continuing current game!");
                        break;
                    case "3":
                        Console.WriteLine("Printing past game records.");
                        break;
                    case "X":
                        break;
                    default:
                        Console.WriteLine("Incorrect input");
                        selected = false;
                        break;
                }
            } while (!selected);
        }
    }
}
