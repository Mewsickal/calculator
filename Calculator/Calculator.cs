using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

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
            if (!InValidRange(value))
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
            if (stack.Count < 2)
            {
                return false;
            }
            int result = stack.Pop() + stack.Pop();
            stack.Push(ReduceResult(result));
            return true;
        }

        private bool InValidRange(int value)
        {
            return value >= minVal && value <= maxVal;
        }

        private int ReduceResult(int result)
        {
            if (!InValidRange(result))
            {
                result = result % (maxVal + 1);
            }
            return result;
        }
    }
}
