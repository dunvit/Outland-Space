using NUnit.Framework;
using OutlandSpaceCommon;

namespace Tests.CommonTests
{
    [TestFixture]
    public class RandomGeneratorTests
    {
        [Test]
        [Repeat(25)]
        public void GetIntegerWithMaxTest()
        {
            Assert.That( RandomGenerator.GetInteger(10), Is.InRange(0, 10));
        }

        [Test]
        [Repeat(25)]
        public void GetIntegerWithMaxAndMinTest()
        {
            Assert.That(RandomGenerator.GetInteger(20, 30), Is.InRange(20, 30));
        }

        [Test]
        [Repeat(25)]
        public void GetIdTest()
        {
            Assert.That(RandomGenerator.GetId(), Is.InRange(1000000000, 2147483647));
        }

        [Test]
        [Repeat(25)]
        public void GetDoubleWithoutParametersTest()
        {
            Assert.That(RandomGenerator.GetDouble(), Is.GreaterThan(0));
            Assert.That(RandomGenerator.GetDouble(), Is.LessThan(1));
        }

        [Test]
        [TestCase(5d, 5d)]
        [TestCase(10d, 10d)]
        public void GetDoubleWithSomeParametersTest(double min, double max)
        {
            Assert.That(RandomGenerator.GetDouble(min, max), Is.GreaterThan(0));
            Assert.That(RandomGenerator.GetDouble(min, max), Is.LessThan(1));
        }

        [Test]
        [TestCase(5d, 15d)]
        [TestCase(10d, 20d)]
        public void GetDoubleWithParametersTest(double min, double max)
        {
            Assert.That(RandomGenerator.GetDouble(min, max), Is.InRange(min, max));
        }

        [Test]
        [Repeat(25)]
        public void GetDirectionTest()
        {
            Assert.That(RandomGenerator.Direction(), Is.InRange(0, 360));
        }

        [Test]
        [TestCase(1)]
        [TestCase(5)]
        [TestCase(10)]
        public void DiceRollerTest(int numberOfSides)
        {
            Assert.That(RandomGenerator.DiceRoller(numberOfSides), Is.InRange(1, numberOfSides));
        }

        [Test]
        [Repeat(25)]
        public void GenerateCelestialObjectNameTest()
        {
            var name = RandomGenerator.GenerateCelestialObjectName();
            Assert.That(name, Is.TypeOf<string>());
            Assert.That(name.Length, Is.EqualTo(16));

            var data = name.Split('-');

            Assert.That(data.Length, Is.EqualTo(3));
            Assert.That(data[0].Length, Is.EqualTo(6));
            Assert.That(data[1].Length, Is.EqualTo(4));
            Assert.That(data[2].Length, Is.EqualTo(4));
        }

        [Test]
        [TestCase(1)]
        [TestCase(5)]
        [TestCase(10)]
        public void RandomStringTest(int size)
        {
            Assert.That(RandomGenerator.RandomString(size).Length, Is.EqualTo(size));
        }

        [Test]
        [TestCase(1)]
        [TestCase(5)]
        [TestCase(10)]
        public void RandomNumberTest(int size)
        {
            Assert.That(RandomGenerator.RandomNumber(size).Length, Is.EqualTo(size));
        }
    }
}