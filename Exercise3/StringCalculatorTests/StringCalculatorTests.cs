using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StrCalculator;
using NUnit.Framework;

namespace StringCalculatorTests
{
    [TestFixture]
   class StringCalculatorTests
    {
        private StringCalculator sut;

        [SetUp]
        public void Setup()
        {
            sut = new StringCalculator();
        }


        [Test]
        public void CalculateEmptyStringInput()
        {
            var result = sut.Add("");

            Assert.AreEqual(0,result);
        }

        [Test]
        public void CalculateOneNumberReturnSameNumber()
        {
            var result = sut.Add("1");

            Assert.AreEqual(1,result);

        }

        [Test]
        public void CalculateMultipleNumbersReturnSum()
        {
            var result = sut.Add("1,2,");

            Assert.AreEqual(3,result);
        }

        [Test]
        public void CalculateNumbersWithNewLine()
        {
            var result = sut.Add("1\n2");

            Assert.AreEqual(3,result);
        }

        [Test]
        public void CalculateWithCustomDelimiter()
        {
            var result = sut.Add("//test\n 5 test 5, 2 test 3");

            Assert.AreEqual(15,result);
        }

        [Test]
        public void CalculateNegativeNumbersThrowException()
        {
           var message = Assert.Throws<NegativeNumberException>(() =>
            {
                sut.Add("10,5,-4,3");
            }).Message;

            Assert.IsTrue(message.Contains("-4"));



            
            
        }


    }
}
