using CalculatorApp;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CalculatorAppTests
{
    [TestClass]
    public class CalculatorTests
    {
        [TestMethod]
        public void WhenNumberIsPushed_NumberShouldAppearOnStack()
        {
            Calculator calc = new Calculator();
            calc.TryPush(1);
            calc.Stack.Should().BeEquivalentTo(new List<int>() { 1 });
        }

        [TestMethod]
        public void When2NumbersArePushed_NumbersShouldAppearOnStackInOrder()
        {
            Calculator calc = new Calculator();
            calc.TryPush(1);
            calc.TryPush(2);
            calc.Stack.Should().BeEquivalentTo(new List<int>() { 1, 2 });
        }

        [TestMethod]
        public void When6thNumberIsPushed_ShouldReject()
        {
            Calculator calc = new Calculator();
            calc.TryPush(1).Should().BeTrue();
            calc.TryPush(1).Should().BeTrue();
            calc.TryPush(1).Should().BeTrue();
            calc.TryPush(1).Should().BeTrue();
            calc.TryPush(1).Should().BeTrue();
            calc.TryPush(1).Should().BeFalse();
        }

        [DataTestMethod]
        [DataRow(-1, false)]
        [DataRow(0, true)]
        [DataRow(1, true)]
        [DataRow(1023, true)]
        [DataRow(1024, false)]
        public void WhenNumberIsPushed_ShouldCheckIfItsInValidRange(int number, bool result)
        {
            Calculator calc = new Calculator();
            calc.TryPush(number).Should().Be(result);
        }

        [DataTestMethod]
        [DataRow(new int[] { }, new int[] { }, 1)]
        [DataRow(new int[] { 5 }, new int[] { }, 1)]
        [DataRow(new int[] { 5, 7 }, new int[] { 5 }, 1)]
        [DataRow(new int[] { 5, 7 }, new int[] { }, 2)]
        public void WhenNumberIsPoped_ShouldRemoveItFromStack(int[] initialStack, int[] resultStack, int timesToPop)
        {
            Calculator calc = new Calculator();
            foreach (var val in initialStack)
            {
                calc.TryPush(val);
            }
            for (int i = 0; i < timesToPop; i++)
            {
                calc.Pop();
            }                      
            calc.Stack.Should().BeEquivalentTo(resultStack);
        }
    }
}
