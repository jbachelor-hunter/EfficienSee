using System;
using Microsoft.Practices.Unity;
using Prism.Events;

namespace EfficienSee.Infrastructure
{
	public static class Globals
	{
		public static IEventAggregator GlobalEventAggregator { get; set; }
		public static IUnityContainer GlobalUnityContainer { get; set; }

        public const int DaysPerYear = 365;
        public const int MonthsPerYear = 12;
        public const int WeeksPerYear = 52;
        public const double DaysPerMonth = 365.0 / 12.0;
        public const double WeeksPerMonth = 52.0 / 12.0;
        public const double DaysPerWeek = 365.0 / 52.0;
	}
}
