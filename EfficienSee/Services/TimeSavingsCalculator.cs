using System;

namespace EfficienSee.Services
{
	public static class TimeSavingsCalculator
	{
		public static double GetTotalTimeSavedInSecondsForDailyTask(int secondsSavedPerTask, int taskFrequencyPerDay,
													 int taskLifetimeInDays)
		{
			var secondsSavedPerDay = secondsSavedPerTask * taskFrequencyPerDay;
			var totalSecondsSavedOverLifetime = secondsSavedPerDay * taskLifetimeInDays;

			return totalSecondsSavedOverLifetime;
		}

		public static double GetTotalTimeSavedInSecondsForWeeklyTask(int secondsSavedPerTask, int taskFrequencyPerWeek, int taskLifetimeInWeeks)
		{
			var secondsSavedPerWeek = secondsSavedPerTask * taskFrequencyPerWeek;
			var totalSecondsSavedOverLifetime = secondsSavedPerWeek * taskLifetimeInWeeks;

			return totalSecondsSavedOverLifetime;
		}
	}
}
