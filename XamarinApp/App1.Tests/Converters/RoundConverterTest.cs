using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using App1.Converter;

namespace App1.Tests.Converters
{
    [TestClass]
    public class RoundConverterTest
    {
        [TestMethod]
        public void TestRoundConverter()
        {
            //arrange
            RoundConverter roundConverter = new RoundConverter();
            var actual = roundConverter.Convert(2.5478, typeof(double) , null, null);

            //test
            Assert.AreEqual(2.55, actual);
        }
    }
}
