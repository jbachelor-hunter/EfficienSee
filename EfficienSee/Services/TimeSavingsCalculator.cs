using System;
using System.Diagnostics;

namespace EfficienSee.Services
{
    public static class TimeSavingsCalculator
    {
        public static TimeSpan GetTotalTimeSavedForTask(TimeSpan timeSavedPerTask, int taskFrequencyPerUnitOfTime,
                                                               int taskLifetimeInUnitOfTime)
        {
            Debug.WriteLine($"{nameof(TimeSavingsCalculator)}.{nameof(GetTotalTimeSavedForTask)}");
            var secondsSavedPerUnitOfTime = timeSavedPerTask.TotalSeconds * taskFrequencyPerUnitOfTime;
            var totalSecondsSavedOverLifetime = secondsSavedPerUnitOfTime * taskLifetimeInUnitOfTime;

            return TimeSpan.FromSeconds(totalSecondsSavedOverLifetime);
        }
    }
}
