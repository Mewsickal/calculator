using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace CalculatorApp
{
    public class Calculator
    {
        public IEnumerable<int> Stack
        {
            get
            {
                return stack;
            }
        }

        private Stack<int> stack = new Stack<int>();

        public bool TryPush(int value)
        {
            if (value < 0 || value > 1023)
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
    }
}
