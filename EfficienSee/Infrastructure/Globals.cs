using System;
using Microsoft.Practices.Unity;
using Prism.Events;

namespace EfficienSee.Infrastructure
{
	public static class Globals
	{
		public static IEventAggregator GlobalEventAggregator { get; set; }
		public static IUnityContainer GlobalUnityContainer { get; set; }


	}
}
