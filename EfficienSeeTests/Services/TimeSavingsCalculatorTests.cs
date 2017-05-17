using NUnit.Framework;
using System;
using EfficienSee.Services;
using EfficienSee.Infrastructure;

namespace EfficienSeeTests.Services
{
	[TestFixture()]
	public class TimeSavingsCalculatorTests
	{
		TimeSavingsCalculator timeSavingsCalculator;

		[TestFixtureSetUp]
		public void ClassInit()
		{

		}

		[SetUp]
		public void TestInit()
		{
			timeSavingsCalculator = new TimeSavingsCalculator();
		}

		[Test]
		[TestCase(1)]
		[TestCase(2)]
		[TestCase(10)]
		public void TestGetDaysFromYears(int years)
		{
			var expectedResult = years * Globals.DaysPerYear;
			var actualResult = timeSavingsCalculator.GetDaysFromYears(years);
			Assert.AreEqual(expectedResult, actualResult);
		}

		[Test]
		[TestCase(1)]
		[TestCase(2)]
		[TestCase(10)]
		public void TestGetWeekssFromYears(int years)
		{
			var expectedResult = years * Globals.WeeksPerYear;
			var actualResult = timeSavingsCalculator.GetWeeksFromYears(years);
			Assert.AreEqual(expectedResult, actualResult);
		}

		[Test]
		[TestCase(1)]
		[TestCase(2)]
		[TestCase(10)]
		public void TestGetMonthsFromYears(int years)
		{
			var expectedResult = years * Globals.MonthsPerYear;
			var actualResult = timeSavingsCalculator.GetMonthsFromYears(years);
			Assert.AreEqual(expectedResult, actualResult);
		}


		[Test]
		[TestCase(1)]
		[TestCase(2)]
		[TestCase(10)]
		public void TestGetDaysFromMonths(int months)
		{
			var expectedResult = months * Globals.DaysPerMonth;
			var actualResult = timeSavingsCalculator.GetDaysFromMonths(months);
			TestUtilities.AssertTwoDoublesAreCloseEnough(expectedResult, actualResult);
		}

		[Test]
		[TestCase(1)]
		[TestCase(4)]
		[TestCase(10)]
		public void TestGetWeeksFromMonths(int months)
		{
			var expectedResult = months * Globals.WeeksPerMonth;
			var actualResult = timeSavingsCalculator.GetWeeksFromMonths(months);
			TestUtilities.AssertTwoDoublesAreCloseEnough(expectedResult, actualResult);
		}

		[Test]
		[TestCase(1)]
		[TestCase(4)]
		[TestCase(10)]
		public void TestGetDaysFromWeeks(int weeks)
		{
			var expectedResult = weeks * Globals.DaysPerWeek;
			var actualResult = timeSavingsCalculator.GetDaysFromWeeks(weeks);
			TestUtilities.AssertTwoDoublesAreCloseEnough(expectedResult, actualResult);
		}

		[Test]
		[TestCase("week", "week", 8, 8)]
		[TestCase("day", "day", 3, 3)]
		[TestCase("month", "month", 5, 5)]
		[TestCase("year", "year", 9, 9)]
		[TestCase("week", "year", 1, 52.0)]
		[TestCase("week", "year", 5, 260.0)]
		[TestCase("week", "year", 10, 520.0)]
		[TestCase("week", "month", 1, (Globals.WeeksPerMonth * 1))]
		[TestCase("week", "month", 8, (Globals.WeeksPerMonth * 8))]
		[TestCase("month", "year", 1, (Globals.MonthsPerYear * 1))]
		[TestCase("month", "year", 31, (Globals.MonthsPerYear * 31))]
		[TestCase("day", "week", 1, 7.0)]
		[TestCase("day", "week", 11, 77.0)]
		[TestCase("day", "month", 1, (Globals.DaysPerMonth * 1))]
		[TestCase("day", "month", 12, (Globals.DaysPerMonth * 12))]
		[TestCase("day", "year", 1, (Globals.DaysPerYear * 1))]
		[TestCase("day", "year", 18, (Globals.DaysPerYear * 18))]
		public void TestGetTaskLifetimeInTaskFrequencyUnitOfTimeReturnsCorrectResult(string taskFrequencyUnitOfTime, string taskLifetimeUnitOfTime, int taskLifetime, double expectedResult)
		{
			var actualResult = timeSavingsCalculator.GetTaskLifetimeInTaskFrequencyUnitOfTime(taskFrequencyUnitOfTime, taskLifetimeUnitOfTime, taskLifetime);
			TestUtilities.AssertTwoDoublesAreCloseEnough(expectedResult, actualResult);
		}

		[Test]
		public void GetTaskLifetimeInTaskFrequencyUnitOfTimeReturns0ForNulls()
		{
			var actualResult = timeSavingsCalculator.GetTaskLifetimeInTaskFrequencyUnitOfTime(null, null, 90);
			Assert.AreEqual(0, actualResult);
		}

		[Test]
		[TestCase(60, 10, "day", 1, "year", 219000)]
		[TestCase(3600, 1, "day", 1, "year", 1314000)]
		[TestCase(30, 4, "day", 1, "year", 43800)]
		[TestCase(60, 4, "day", 1, "week", 1684.615)]
		[TestCase(60, 4, "day", 7, "week", 11792.308)]
		[TestCase(900, 3, "week", 1, "year", 140400)]
		[TestCase(900, 3, "week", 5, "year", 702000)]
		[TestCase(60, 5, "week", 1, "month", 1300)]
		[TestCase(900, 10, "month", 1, "year", 108000)]
		public void TestGetTotalTimeSavedForTaskRules(int secondsSavedPerTask, int taskFreq, string taskFreqUnitOfTime, int taskLifetime, string taskLifetimeUnitOfTime, double expectedMaxSecondsSaved)
		{
			var timeSavedPerTask = TimeSpan.FromSeconds(secondsSavedPerTask);
			var expectedResult = TimeSpan.FromSeconds(expectedMaxSecondsSaved);

			var actualResult = timeSavingsCalculator.GetMaxTimeSaved(timeSavedPerTask, taskFreq, taskFreqUnitOfTime, taskLifetime, taskLifetimeUnitOfTime);

			TestUtilities.AssertTwoDoublesAreCloseEnough(expectedResult.TotalSeconds, actualResult.TotalSeconds);
		}
	}
}
