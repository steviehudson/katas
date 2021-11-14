using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace Katas.FizzBuzz
{
    [TestFixture]
    public class FizzBuzzSpecs
    {
        private FizzBuzzer sut;
        private List<GeneratedString> genStrings;

        [SetUp]
        public void SetupBeforeEachTest()
        {
            //Arrange 
            sut = new FizzBuzzer();

            //Act
            genStrings = sut.GetGeneratedStrings();
        }

        [Test]
        public void IntegarsNotBelowMinimum()
        {
            //Assert
            var minInt = genStrings.Min(x => x.Number);
            Assert.AreEqual(FizzBuzzConstants.Min, minInt);
        }

        [Test]
        public void IntegarsNotAboveMaximum()
        {
            //Assert
            var maxInt = genStrings.Max(x => x.Number);
            Assert.AreEqual(FizzBuzzConstants.Max, maxInt);
        }

        [Test]
        public void IntegarsAllBetweenMinAndMax()
        {
            var countExpected = FizzBuzzConstants.Count;
            var orderedGenStrings = genStrings.OrderBy(x => x.Number);
            var genStringsNotIncremented = orderedGenStrings.Where((x, index) => x.Number != index + FizzBuzzConstants.Min);

            Assert.AreEqual(countExpected, orderedGenStrings.Count());
            Assert.IsFalse(genStringsNotIncremented.Any());
        }

        [Test]
        public void DivisableByThreeOnlyIsFizz()
        {
            //Assert
            var divisables = genStrings.Where(x => x.Number % 3 == 0 && x.Number % 5 != 0);

            Assert.IsTrue(divisables.Any());
            Assert.IsFalse(divisables.Any(x => x.NumberToSting != FizzBuzz.Fizz.ToString()));
        }

        [Test]
        public void DivisableByFiveOnlyIsBuzz()
        {
            //Assert
            var divisables = genStrings.Where(x => x.Number % 5 == 0 && x.Number % 3 != 0);

            Assert.IsTrue(divisables.Any());
            Assert.IsFalse(divisables.Any(x => x.NumberToSting != FizzBuzz.Buzz.ToString()));
        }

        [Test]
        public void DivisableByThreeAndFiveIsFizzBuzz()
        {
            //Assert
            var divisables = genStrings.Where(x => x.Number % 5 == 0 && x.Number % 3 == 0);

            Assert.IsTrue(divisables.Any());
            Assert.IsFalse(divisables.Any(x => x.NumberToSting != FizzBuzz.FizzBuzz.ToString()));
        }

        [Test]
        public void NonDivisablesMatchIntegar()
        {
            //Assert
            var nonDivisables = genStrings.Where(x => x.Number % 3 != 0 && x.Number % 5 != 0);

            Assert.IsTrue(nonDivisables.Any());
            Assert.IsFalse(nonDivisables.Any(x => x.Number.ToString() != x.NumberToSting));
        }
    }
}
