using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using Assert = NUnit.Framework.Assert;

namespace Tests
{
    [TestFixture]
    public class CalculatorTests
    {
        [Test]
        public void AddNumbers_ValidValues_ReturnsCorrectResult()
        {
            var sut = new Calculator();
            int result = sut.AddNumbers(1, 2);

            Assert.That(result, Is.EqualTo(3));
        }
    }

    public class Calculator
    {
        public int AddNumbers(int i, int i1)
        {
            return 0;
        }
    }
}
