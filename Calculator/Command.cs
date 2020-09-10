using System;

namespace CalculatorApp
{
    public struct Command
    {
        public Operation Operation { get; }
        public int Argument { get; }

        public Command(Operation operation)
        {
            this.Operation = operation;
            this.Argument = default;
        }
        public Command(Operation operation, int argument)
        {
            this.Operation = operation;
            this.Argument = argument;
        }

        public static Command Parse(string serializedCommand)
        {
            var tokens = serializedCommand.Split();
            var operation = tokens.Length > 0 ? ParseOperation(tokens[0]) : Operation.Unknown;
            if (operation == Operation.Push)
            {
                return ParsePush(tokens);
            }
            return new Command(operation);
        }

        private static Command ParsePush(string[] tokens)
        {
            if (tokens.Length > 1 && int.TryParse(tokens[1], out int argument))
            {
                return new Command(Operation.Push, argument);
            }
            return new Command(Operation.Unknown);            
        }

        private static Operation ParseOperation(string op)
        {
            Operation result = Operation.Unknown;
            Enum.TryParse(op, true, out result);
            return result;
        }
    }
}
