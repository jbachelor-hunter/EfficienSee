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
		[TestCase(1, 50, 7, 7, 350)]
		[TestCase(10, 50, 7, 7, 3500)]
		[TestCase(300, 5, 14, 7, 21000)]
		[TestCase(600, 1, 1825, 7, 1095000)]
		[TestCase(3600, 1, 1825, 7, 6570000)]
		[TestCase(1, 60, 1, 7, 60)]
		[TestCase(1, 60, 365, 7, 21900)]
		[TestCase(10, 60, 1, 7, 600)]
		[TestCase(30, 60, 1, 7, 1800)]
		public void TestDailyTaskReturnsCorrectAnswer(int secondsSavedPerTask, int taskFrequencyPerDay,
																	  int taskLifetimeDays, int daysPerWeekTaskIsPerformed,
																	  double expectedResult)
		{
			var actualResult = TimeSavingsCalculator.GetTotalTimeSavedInSecondsForDailyTask(
				 secondsSavedPerTask, taskFrequencyPerDay, taskLifetimeDays);

			AssertTwoDoublesAreCloseEnough(expectedResult, actualResult);
		}

		[Test]
		[TestCase(30, 1, 52 * 5, 7800)]
		[TestCase(3600, 1, 52 * 5, 936000)]
		[TestCase(3600, 10, 52 * 5, 9360000)]
		public void TestWeeklyTaskReturnsCorrectAnswer(int secondsSavedPerTask, int taskFrequencyPerWeek,
													   int taskLifetimeInWeeks, double expectedResult)
		{
			var actualResult = TimeSavingsCalculator.GetTotalTimeSavedInSecondsForWeeklyTask(secondsSavedPerTask,
																							 taskFrequencyPerWeek,
																							 taskLifetimeInWeeks);

			AssertTwoDoublesAreCloseEnough(expectedResult, actualResult);
		}


		public void AssertTwoDoublesAreCloseEnough(double expectedValue, double actualValue, double acceptableDifference = 1.0)
		{
			double difference = Math.Abs(expectedValue - actualValue);
			Assert.IsTrue(difference <= acceptableDifference, $"{expectedValue} is not close enough to {actualValue}");
		}
	}
}
