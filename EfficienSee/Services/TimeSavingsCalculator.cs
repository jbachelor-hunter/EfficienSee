using System;
using EfficienSee.Infrastructure;

namespace EfficienSee.Services
{
	public static class TimeSavingsCalculator
	{
		public static TimeSpan GetTotalTimeSavedForTask(TimeSpan timeSavedPerTask, int taskFrequencyPerUnitOfTime,
															   int taskLifetimeInUnitOfTime)
		{
			var secondsSavedPerUnitOfTime = timeSavedPerTask.TotalSeconds * taskFrequencyPerUnitOfTime;
			var totalSecondsSavedOverLifetime = secondsSavedPerUnitOfTime * taskLifetimeInUnitOfTime;

			return TimeSpan.FromSeconds(totalSecondsSavedOverLifetime);
		}
	}
}
