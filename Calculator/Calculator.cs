using System;
using System.Collections.Generic;

namespace CalculatorApp
{
    public class Calculator
    {
        const int maxVal = 1023;
        const int minVal = 0;

        private Stack<int> stack = new Stack<int>();

        public IEnumerable<int> Stack
        {
            get
            {
                return stack;
            }
        }        

        public bool TryPush(int value)
        {
            if (!IsInValidRange(value))
            {
                return false;
            }
            if (stack.Count >= 5)
            {
                return false;
            }
            stack.Push(value);
            return true;
        }

        public void Pop()
        {
            if (stack.Count > 0)
            {
                stack.Pop();
            }
        }

        public bool TryAdd()
        {
            return TryDoOperation((x, y) => x + y);
        }

        public bool TrySub()
        {
            return TryDoOperation((x, y) => x - y);
        }

        private bool TryDoOperation(Func<int, int, int> binaryOperation)
        {
            if (stack.Count < 2)
            {
                return false;
            }
            int result = binaryOperation(stack.Pop(),stack.Pop());
            stack.Push(Normalize(result));
            return true;
        }

        private bool IsInValidRange(int value) 
            => value >= minVal && value <= maxVal;

        private int Normalize(int result)
            => result & maxVal;
    }
}
