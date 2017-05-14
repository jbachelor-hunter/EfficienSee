using System;

namespace EfficienSee.Services
{
    public interface ITimeSavingsCalculator
    {
        TimeSpan GetMaxTimeSaved(TimeSpan timeSavedPerTask, int taskFrequency, string taskFrequencyUnitOfTime, int taskLifetime, string taskLifetimeUnitOfTime);
    }
}
