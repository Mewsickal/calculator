using System;
using System.Linq;

namespace CalculatorApp
{
    class Program        
    {
        static Calculator calculator = new Calculator();

        static void Main()
        {
            Console.WriteLine("You can use commands push, pop, add and sub. If you want to quit enter empty line.");
            
            while (true)
            {
                var input = Console.ReadLine();
                if (input == string.Empty)
                {
                    break;
                }
                var result = Evaluate(input);
                if (result != string.Empty)
                {
                    Console.WriteLine(result);
                }
            }
        }

        private static string Evaluate(string input)
        {
            var command = Command.Parse(input);

            switch (command.Operation)
            {
                case Operation.Unknown:
                    return "Invalid input!";
                case Operation.Push:
                    if (!calculator.TryPush(command.Argument))
                    {
                        return "Stack is full or number is invalid!";
                    }

                    return string.Empty;
                case Operation.Pop:
                    calculator.Pop();
                    return string.Empty;
                case Operation.Add:
                    if (calculator.TryAdd())
                    {
                        return calculator.Stack.Last().ToString();
                    }
                    else
                    {
                        return "Not enough numbers on the stack!";
                    }
                case Operation.Sub:
                    if (calculator.TrySub())
                    {
                        return calculator.Stack.Last().ToString();
                    }
                    else
                    {
                        return "Not enough numbers on the stack!";
                    }
                default:
                    return string.Empty;
            }
        }
    }
}
