using NUnit.Framework;
using SumExampleForUnitTests;

namespace UnitTestForSumExample
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestSumInt()
        {
            int sum;
            sum = Program.Sum(2, 2);
            Assert.AreEqual(4, sum);

            //Assert.Pass();
        }

        [Test]
        public void TestSumDouble()
        {
            double sum,delta=0.0001;
            sum = Program.Sum(1/6, 1/6);

            Assert.AreEqual(2/6, sum,delta);

            //Assert.Pass();
        }
    }
}