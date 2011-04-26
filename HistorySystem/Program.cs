using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HistorySystem
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = string.Empty;

            while (true)
            {
                Console.WriteLine("Please enter a command:");
                input = Console.ReadLine();

                switch (input.ToLower())
                {
                    case "exit":
                        Console.WriteLine("Goodbye!");

                        for (int i = 0; i < 3; i++)
                        {
                            Console.Write(".");
                            System.Threading.Thread.Sleep(1000);
                        }
                        Environment.Exit(0);
                        break;

                    case "help":
                        PrintHelpText();
                        break;

                    case "test":
                        Test();
                        break;

                    case "hist":
                        Interactive();
                        break;

                    case "clear":
                        Console.Clear();
                        break;

                    default:
                        Console.Beep();
                        Console.WriteLine("Command not recognized...  Please try again.");
                        break;
                }
            }
        }

        private static void PrintHelpText()
        {
            Console.WriteLine("");

            Console.WriteLine("Commands:");
            Console.WriteLine("exit - exit this application");
            Console.WriteLine("help - display this help documentation");
            Console.WriteLine("test - execute basic test of the history system");
            Console.WriteLine("hist - execute interactive mode of the history system");
            Console.WriteLine("clear - clear the screen");

            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
        }

        private static void Interactive()
        {
            History<string> appHistory = new History<string>();
            bool interactiveMode = true;
            string input = string.Empty;

            Console.WriteLine("");

            while (interactiveMode)
            {
                Console.Write("hist> ");
                input = Console.ReadLine();

                switch (input.ToLower())
                {
                    case "exit":
                        interactiveMode = false;
                        Console.WriteLine("hist> Exiting hist program... Thanks for playing!");
                        Console.WriteLine("");
                        Console.WriteLine("");
                        Console.WriteLine("");
                        break;

                    case "help":
                        Console.WriteLine("hist> Commands:");
                        Console.WriteLine("hist> exit - exit the hist program");
                        Console.WriteLine("hist> help - display this help text");
                        Console.WriteLine("hist> add - add input to the application history at the next prompt");
                        Console.WriteLine("hist> undo - undo the last input from the application history");
                        Console.WriteLine("hist> redo - redo the last input from the application history");
                        break;

                    case "add":
                        Console.WriteLine("hist> Enter text to add to history:");
                        Console.Write("hist> ");

                        input = Console.ReadLine();
                        Console.WriteLine("hist> Adding {0} to history...", input);
                        appHistory.AddItemToHistory(input);
                        break;

                    case "undo":
                        string undo = appHistory.Undo();

                        if (undo != null)
                        {
                            Console.WriteLine("hist> Undo {0} from application...", undo);
                        }
                        else
                        {
                            Console.WriteLine("hist> Nothing to undo...");
                        }
                        break;

                    case "redo":
                        string redo = appHistory.Redo();

                        if (redo != null)
                        {
                            Console.WriteLine("hist> Redo {0} to application...", redo);
                        }
                        else
                        {
                            Console.WriteLine("hist> Nothing to redo...");
                        }
                        break;

                    default:
                        Console.Beep();
                        Console.WriteLine("hist> Command not recognized...  Please try again.");
                        break;
                }
            }
        }

        private static void Test()
        {
            int numberOfOperations = 20;
            Random random = new Random(DateTime.UtcNow.Millisecond);
            History<string> applicationHistory = new History<string>(null);
            string operationName = string.Empty;

            Console.WriteLine("Enter the number of random operations you'd like to add to the history:");

            if (!int.TryParse(Console.ReadLine(), out numberOfOperations))
            {
                numberOfOperations = 20;
            }

            Console.WriteLine("Testing with {0} random operation{1}...", numberOfOperations, numberOfOperations == 1 ? string.Empty : "s");

            for (int i = 0; i < numberOfOperations; i++)
            {
                operationName = GetOperation(random.Next());
                applicationHistory.AddItemToHistory(operationName);

                Console.WriteLine("Adding operation {0} to history...", operationName);
            }

            for (int i = 0; i < numberOfOperations; i++)
            {
                string op = applicationHistory.Undo();
                Console.WriteLine("Undoing operation {0} from history...", op);
            }

            for (int i = 0; i < numberOfOperations; i++)
            {
                string op = applicationHistory.Redo();
                Console.WriteLine("Redoing operation {0} from history...", op);
            }

            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
        }

        private static string GetOperation(int input)
        {
            string output = string.Empty;
            int opNumber = input % 6;

            switch (opNumber)
            {
                case 1:
                    output = "Paint";
                    break;

                case 2:
                    output = "Image";
                    break;

                case 3:
                    output = "Cut";
                    break;

                case 4:
                    output = "Copy";
                    break;

                case 5:
                    output = "Paste";
                    break;

                default:
                case 0:
                    output = "Type";
                    break; 
            }

            return output;
        }
    }
}
