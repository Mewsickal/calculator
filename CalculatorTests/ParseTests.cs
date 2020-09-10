using CalculatorApp;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace CalculatorAppTests
{
    [TestClass]
    public class ParseTests
    {
        [DataTestMethod]
        [DataRow("", Operation.Unknown)]
        [DataRow("Push", Operation.Unknown)]
        [DataRow("Push 1", Operation.Push, 1)]
        [DataRow("Pop", Operation.Pop)]
        [DataRow("Add", Operation.Add)]
        [DataRow("Sub", Operation.Sub)]
        public void WhenGivenCommandString_CommandShouldBeParsedCorrectly(string cmnd, Operation op, int val = 0)
        {
            Command result = Command.Parse(cmnd);
            result.Operation.Should().Be(op);
            result.Argument.Should().Be(val);
        }
    }
}
