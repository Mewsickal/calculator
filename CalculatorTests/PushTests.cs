using CalculatorApp;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace CalculatorTests
{
    [TestClass]
    public class PushTests
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
    }
}
