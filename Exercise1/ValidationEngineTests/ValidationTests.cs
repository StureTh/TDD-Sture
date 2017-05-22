using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValidationEngine;
namespace ValidationEngineTests
{
    [TestFixture]
   public class ValidationTests
    {
        
        [Test]
        public void TrueForValidAdress()
        {
            var sut = new Validator();

            var valid = sut.ValidateEmailAddress("sture@mail.com");

            Assert.IsTrue(valid);
        }

        [Test]
        public void FalseForInvalidAdress()
        {
            var sut = new Validator();

            var invalid = sut.ValidateEmailAddress("sture21huren@mail.com");

            Assert.IsFalse(invalid);
        }

        [Test]

        public void AdressIsNull()
        {
            var sut = new Validator();

            var isNull = sut.ValidateEmailAddress("");

            Assert.IsFalse(isNull);
        }

     
    }
}
