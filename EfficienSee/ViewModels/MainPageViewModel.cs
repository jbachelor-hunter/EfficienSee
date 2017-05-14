using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using EfficienSee.Services;
using System.Collections.ObjectModel;

namespace EfficienSee.ViewModels
{
    public class MainPageViewModel : BindableBase, INavigatingAware, IDestructible
    {
        private ITimeSavingsCalculator _timeSavingsCalculator;

        private string _title;
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        private string _timeSavedLabelText;
        public string TimeSavedLabelText
        {
            get { return _timeSavedLabelText; }
            set { SetProperty(ref _timeSavedLabelText, value); }
        }

        private int _timeSavedPerTask;
        public int TimeSavedPerTask
        {
            get { return _timeSavedPerTask; }
            set
            {
                var valueDidChange = SetProperty(ref _timeSavedPerTask, value);
                if (valueDidChange)
                {
                    MaxTimeToAllot = GetMaxTimeToAllotInMinutes();
                }
            }
        }

        private string _taskFrequencyLabelText;
        public string TaskFrequencyLabelText
        {
            get { return _taskFrequencyLabelText; }
            set { SetProperty(ref _taskFrequencyLabelText, value); }
        }

        private int _taskFrequency;
        public int TaskFrequency
        {
            get { return _taskFrequency; }
            set
            {
                var valueDidChange = SetProperty(ref _taskFrequency, value);
                if (valueDidChange)
                {
                    MaxTimeToAllot = GetMaxTimeToAllotInMinutes();
                }
            }
        }

        private string _taskLifetimeLabelText;
        public string TaskLifetimeLabelText
        {
            get { return _taskLifetimeLabelText; }
            set { SetProperty(ref _taskLifetimeLabelText, value); }
        }

        private int _taskLifetime;
        public int TaskLifetime
        {
            get { return _taskLifetime; }
            set
            {
                var valueDidChange = SetProperty(ref _taskLifetime, value);
                if (valueDidChange)
                {
                    MaxTimeToAllot = GetMaxTimeToAllotInMinutes();
                }
            }
        }

        private string _maxTimeToAllotLabelText;
        public string MaxTimeToAllotLabelText
        {
            get { return _maxTimeToAllotLabelText; }
            set { SetProperty(ref _maxTimeToAllotLabelText, value); }
        }

        private double _maxTimeToAllot;
        public double MaxTimeToAllot
        {
            get { return _maxTimeToAllot; }
            set { SetProperty(ref _maxTimeToAllot, value); }
        }

        private ObservableCollection<string> _unitsOfTime;
        public ObservableCollection<string> UnitsOfTime
        {
            get { return _unitsOfTime; }
            set { SetProperty(ref _unitsOfTime, value); }
        }

        private string _selectedFrequencyTimeUnit;
        public string SelectedFrequencyTimeUnit
        {
            get { return _selectedFrequencyTimeUnit; }
            set { SetProperty(ref _selectedFrequencyTimeUnit, value); }
        }

        private string _selectedTaskLifetimeTimeUnit;
        public string SelectedTaskLifetimeTimeUnit
        {
            get { return _selectedTaskLifetimeTimeUnit; }
            set { SetProperty(ref _selectedTaskLifetimeTimeUnit, value); }
        }

        public MainPageViewModel(ITimeSavingsCalculator timeSavingsCalculator)
        {
            Debug.WriteLine($"**** {this.GetType().Name}.{nameof(MainPageViewModel)}:  ctor");

            _timeSavingsCalculator = timeSavingsCalculator;

            UnitsOfTime = new ObservableCollection<string>
            {
                "per day", "per week", "per month", "per year"
            };

            Title = "EfficienSee";
            TimeSavedLabelText = "By how many minutes could you shorten your task, given some effort to make some part of it automated, or more efficient?";
            TaskFrequencyLabelText = "How frequently do you it?";
            TaskLifetimeLabelText = "How long will you keep performing this task?";
            MaxTimeToAllotLabelText = "You can spend this much time before spending more time than you will save:";
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

        internal double GetMaxTimeToAllotInMinutes()
        {
            Debug.WriteLine($"**** {this.GetType().Name}.{nameof(GetMaxTimeToAllotInMinutes)}");
            
            var maxTime = _timeSavingsCalculator.GetMaxTimeSaved(
                TimeSpan.FromMinutes(TimeSavedPerTask), 
                TaskFrequency, 
                SelectedFrequencyTimeUnit, 
                TaskLifetime,
                SelectedTaskLifetimeTimeUnit);

            return maxTime.TotalMinutes;
        }
    }
}

