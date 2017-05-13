using System;

namespace EfficienSee.Services
{
    public interface ITimeSavingsCalculator
    {
        TimeSpan GetTotalTimeSavedForTask(TimeSpan timeSavedPerTask, int taskFrequencyPerUnitOfTime, int taskLifetimeInUnitOfTime);
    }
}
