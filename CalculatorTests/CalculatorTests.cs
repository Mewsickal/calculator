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

        [TestMethod]
        public void WhenAddIsUsedOnEmptyStack_ShouldReject()
        {
            Calculator calc = new Calculator();
            calc.TryAdd().Should().BeFalse();
        }

        [TestMethod]
        public void WhenAddIsUsedOnStackWith1Element_ShouldReject()
        {
            Calculator calc = new Calculator();
            calc.TryPush(1);
            calc.TryAdd().Should().BeFalse();
        }

        [DataTestMethod]
        [DataRow(new int[] { 1, 1 }, new int[] { 2 }, 1)]
        [DataRow(new int[] { 1, 1, 5 }, new int[] { 1, 6 }, 1)]
        [DataRow(new int[] { 1, 1, 5 }, new int[] { 7 }, 2)]
        [DataRow(new int[] { 1023, 1 }, new int[] { 0 }, 1)]
        [DataRow(new int[] { 1023, 1023 }, new int[] { 1022 }, 1)]
        public void WhenNumbersAreAdded_ShouldShowResultOnStack(int[] initialStack, int[] resultStack, int timesToAdd)
        {
            Calculator calc = new Calculator();
            foreach (var val in initialStack)
            {
                calc.TryPush(val);
            }
            for (int i = 0; i < timesToAdd; i++)
            {
                calc.TryAdd();
            }
            calc.Stack.Should().BeEquivalentTo(resultStack);
        }
    }
}
