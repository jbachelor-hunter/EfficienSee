using NUnit.Framework;
using System;
using EfficienSee.Services;

namespace EfficienSeeTests
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
		public void TestGetTotalTimeSavedForTaskReturnsCorrectAnswer(int secondsSavedPerTask, int taskFrequencyPerDay,
																	 int taskLifetimeDays, double expectedResultInSeconds)
		{
			var actualResult = TimeSavingsCalculator.GetTotalTimeSavedForTask(TimeSpan.FromSeconds(secondsSavedPerTask),
																			  taskFrequencyPerDay, taskLifetimeDays);

			AssertTwoDoublesAreCloseEnough(expectedResultInSeconds, actualResult.TotalSeconds);
		}


		public void AssertTwoDoublesAreCloseEnough(double expectedValue, double actualValue, double acceptableDifference = 1.0)
		{
			double difference = Math.Abs(expectedValue - actualValue);
			Assert.IsTrue(difference <= acceptableDifference, $"{expectedValue} is not close enough to {actualValue}");
		}
	}
}
