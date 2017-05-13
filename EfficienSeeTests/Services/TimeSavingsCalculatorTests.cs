using NUnit.Framework;
using System;
using EfficienSee.Services;

namespace EfficienSeeTests.Services
{
    [TestFixture()]
    public class TimeSavingsCalculatorTests
    {
        [TestFixtureSetUp]
        public void ClassInit()
        {

        }

        [SetUp]
        public void TestInit()
        {

        }

        [Test]
        [TestCase(1, 50, 7, 350)]
        [TestCase(10, 50, 7, 3500)]
        [TestCase(300, 5, 14, 21000)]
        [TestCase(600, 1, 1825, 1095000)]
        [TestCase(3600, 1, 1825, 6570000)]
        [TestCase(1, 60, 1, 60)]
        [TestCase(1, 60, 365, 21900)]
        [TestCase(10, 60, 1, 600)]
        [TestCase(30, 60, 1, 1800)]
        [TestCase(30, 1, 52 * 5, 7800)]
        [TestCase(3600, 1, 52 * 5, 936000)]
        [TestCase(3600, 10, 52 * 5, 9360000)]
        [TestCase(86400, 1, 5, 5 * 86400)]
        public void TestGetTotalTimeSavedForTaskReturnsCorrectAnswer(int secondsSavedPerTask, int taskFrequencyPerUnitOfTime,
                                                                     int taskLifetimeInUnitOfTime, double expectedResultInSeconds)
        {
            var actualResult = TimeSavingsCalculator.GetTotalTimeSavedForTask(TimeSpan.FromSeconds(secondsSavedPerTask),
                                                                              taskFrequencyPerUnitOfTime, taskLifetimeInUnitOfTime);

            TestUtilities.AssertTwoDoublesAreCloseEnough(expectedResultInSeconds, actualResult.TotalSeconds);
        }
    }
}
