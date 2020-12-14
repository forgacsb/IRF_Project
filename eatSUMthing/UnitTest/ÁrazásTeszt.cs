using eatSUMthing;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest
{
    public class ÁrazásTeszt
    {
        [
    Test,
    TestCase("abcd1234", false),
    TestCase("-123", false),
    TestCase("100.00", false),
    TestCase("500", true)
]
        public void TestValidateÁr(string Ár, bool expectedResult)
        {
            // Arrange
            var árazás = new Árazás();

            // Act
            var actualResult = árazás.ValidateÁr(Ár);

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
