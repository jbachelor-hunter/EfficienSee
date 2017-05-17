using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using EfficienSee.Infrastructure;

[assembly: InternalsVisibleTo("EfficienSeeTests")]
namespace EfficienSee.Services
{
	public class TimeSavingsCalculator : ITimeSavingsCalculator
	{
		/// <summary>
		/// Calculates the amount of time that would be saved by making a task more efficient in some way.
		/// </summary>
		/// <param name="timeSavedPerTask">How much time one could shorten a task by</param>
		/// <param name="taskFrequency">How frequently one engages in the task</param>
		/// <param name="taskFrequencyUnitOfTime">day/week/month/year</param>
		/// <param name="taskLifetime">How long will the task go on in days/weeks/months/years</param>
		/// <param name="taskLifetimeUnitOfTime">day/week/month/year</param>
		/// <returns></returns>
		public TimeSpan GetMaxTimeSaved(TimeSpan timeSavedPerTask, int taskFrequency, string taskFrequencyUnitOfTime, int taskLifetime, string taskLifetimeUnitOfTime)
		{
			double secondsSavedPerFrequencyUnitOfTime = timeSavedPerTask.TotalSeconds * taskFrequency;
			double taskLifetimeInFrequencyUnitOfTime = GetTaskLifetimeInTaskFrequencyUnitOfTime(
				taskFrequencyUnitOfTime, taskLifetimeUnitOfTime, taskLifetime);

			var maxTimeSavedInSeconds = secondsSavedPerFrequencyUnitOfTime * taskLifetimeInFrequencyUnitOfTime;
			return TimeSpan.FromSeconds(maxTimeSavedInSeconds);
		}

		/// <summary>
		/// Converts task lifetime to be in the same unit of time that task frequency is measured in.
		/// </summary>
		/// <param name="taskFrequencyUnitOfTime">day/week/month/year</param>
		/// <param name="taskLifetimeUnitOfTime">day/week/month/year</param>
		/// <param name="taskLifetime">How long will the task go on in days/weeks/months/years</param>
		/// <returns></returns>
		internal double GetTaskLifetimeInTaskFrequencyUnitOfTime(string taskFrequencyUnitOfTime, string taskLifetimeUnitOfTime, int taskLifetime)
		{
			if (string.IsNullOrWhiteSpace(taskFrequencyUnitOfTime) || string.IsNullOrWhiteSpace(taskLifetimeUnitOfTime))
			{
				return 0.0;
			}

			double taskLifetimeInFrequencyUnitOfTime = 0.0;

			if (string.Equals(taskFrequencyUnitOfTime, taskLifetimeUnitOfTime, StringComparison.OrdinalIgnoreCase))
			{
				taskLifetimeInFrequencyUnitOfTime = taskLifetime;
			}
			else if (taskFrequencyUnitOfTime.Contains("day") && taskLifetimeUnitOfTime.Contains("week"))
			{
				taskLifetimeInFrequencyUnitOfTime = GetDaysFromWeeks(taskLifetime);
			}
			else if (taskFrequencyUnitOfTime.Contains("day") && taskLifetimeUnitOfTime.Contains("month"))
			{
				taskLifetimeInFrequencyUnitOfTime = GetDaysFromMonths(taskLifetime);
			}
			else if (taskFrequencyUnitOfTime.Contains("day") && taskLifetimeUnitOfTime.Contains("year"))
			{
				taskLifetimeInFrequencyUnitOfTime = GetDaysFromYears(taskLifetime);
			}
			else if (taskFrequencyUnitOfTime.Contains("week") && taskLifetimeUnitOfTime.Contains("month"))
			{
				taskLifetimeInFrequencyUnitOfTime = GetWeeksFromMonths(taskLifetime);
			}
			else if (taskFrequencyUnitOfTime.Contains("week") && taskLifetimeUnitOfTime.Contains("year"))
			{
				taskLifetimeInFrequencyUnitOfTime = GetWeeksFromYears(taskLifetime);
			}
			else if (taskFrequencyUnitOfTime.Contains("month") && taskLifetimeUnitOfTime.Contains("year"))
			{
				taskLifetimeInFrequencyUnitOfTime = GetMonthsFromYears(taskLifetime);
			}

			return taskLifetimeInFrequencyUnitOfTime;
		}

		internal int GetDaysFromYears(int years)
		{
			return years * Globals.DaysPerYear;
		}

		internal double GetDaysFromMonths(int months)
		{
			return months * Globals.DaysPerMonth;
		}

		internal double GetDaysFromWeeks(int weeks)
		{
			return weeks * Globals.DaysPerWeek;
		}

		internal double GetWeeksFromYears(int years)
		{
			return years * Globals.WeeksPerYear;
		}

		internal double GetWeeksFromMonths(int months)
		{
			return months * Globals.WeeksPerMonth;
		}

		internal double GetMonthsFromYears(int years)
		{
			return years * Globals.MonthsPerYear;
		}
	}
}
