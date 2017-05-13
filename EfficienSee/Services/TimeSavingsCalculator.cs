using System;
using System.Diagnostics;

namespace EfficienSee.Services
{
    public static class TimeSavingsCalculator
    {
        public static TimeSpan GetTotalTimeSavedForTask(TimeSpan timeSavedPerTask, int taskFrequencyPerUnitOfTime,
                                                               int taskLifetimeInUnitOfTime)
        {
            var secondsSavedPerUnitOfTime = timeSavedPerTask.TotalSeconds * taskFrequencyPerUnitOfTime;
            var totalSecondsSavedOverLifetime = secondsSavedPerUnitOfTime * taskLifetimeInUnitOfTime;

            Debug.WriteLine($"{nameof(TimeSavingsCalculator)}.{nameof(GetTotalTimeSavedForTask)}:  Returning {totalSecondsSavedOverLifetime} seconds.");

            return TimeSpan.FromSeconds(totalSecondsSavedOverLifetime);
        }
    }
}
