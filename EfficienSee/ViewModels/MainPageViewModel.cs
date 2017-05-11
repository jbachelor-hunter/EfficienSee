using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;

namespace EfficienSee.ViewModels
{
	public class MainPageViewModel : BindableBase, INavigatingAware, IDestructible
	{
		private string _title;
		public string Title
		{
			get { return _title; }
			set { SetProperty(ref _title, value); }
		}

		public MainPageViewModel()
		{
			Debug.WriteLine($"**** {this.GetType().Name}.{nameof(MainPageViewModel)}:  ctor");
		}

		~MainPageViewModel()
		{
			Debug.WriteLine($"**** {this.GetType().Name}.{nameof(MainPageViewModel)}:  dtor");
		}

		#region INavigatingAware

		public void OnNavigatingTo(NavigationParameters parameters)
		{
			Debug.WriteLine($"**** {this.GetType().Name}.{nameof(OnNavigatingTo)}");
		}

		#endregion End INavigatingAware

		#region IDestructible

		public void Destroy()
		{
			Debug.WriteLine($"**** {this.GetType().Name}.{nameof(Destroy)}");
		}

		#endregion End IDestructible
	}
}

