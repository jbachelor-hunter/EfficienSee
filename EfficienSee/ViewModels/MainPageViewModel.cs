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

        private int _frequencyMinValue;
        public int FrequencyMinValue
        {
            get { return _frequencyMinValue; }
            set { SetProperty(ref _frequencyMinValue, value); }
        }

        private int _frequencyMaxValue;
        public int FrequencyMaxValue
        {
            get { return _frequencyMaxValue; }
            set { SetProperty(ref _frequencyMaxValue, value); }
        }


        private int _timeSavedMinValue;
        public int TimeSavedMinValue
        {
            get { return _timeSavedMinValue; }
            set { SetProperty(ref _timeSavedMinValue, value); }
        }

        private int _timeSavedMaxValue;
        public int TimeSavedMaxValue
        {
            get { return _timeSavedMaxValue; }
            set { SetProperty(ref _timeSavedMaxValue, value); }
        }

        private int _taskLifetimeMinValue;
        public int TaskLifetimeMinValue
        {
            get { return _taskLifetimeMinValue; }
            set { SetProperty(ref _taskLifetimeMinValue, value); }
        }

        private int _taskLifetimeMaxValue;
        public int TaskLifetimeMaxValue
        {
            get { return _taskLifetimeMaxValue; }
            set { SetProperty(ref _taskLifetimeMaxValue, value); }
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

        private TimeSpan _maxTimeToAllot;
        public TimeSpan MaxTimeToAllot
        {
            get { return _maxTimeToAllot; }
            set { SetProperty(ref _maxTimeToAllot, value); }
        }

        private ObservableCollection<string> _frequencyUnitsOfTime;
        public ObservableCollection<string> FrequencyUnitsOfTime
        {
            get { return _frequencyUnitsOfTime; }
            set { SetProperty(ref _frequencyUnitsOfTime, value); }
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

            FrequencyUnitsOfTime = new ObservableCollection<string>
            {
                "per day", "per week", "per month", "per year"
            };

            UnitsOfTime = new ObservableCollection<string>{
                "days","weeks","months","years"
            };

            SelectedFrequencyTimeUnit = "per month";
            SelectedTaskLifetimeTimeUnit = "weeks";

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

        internal TimeSpan GetMaxTimeToAllotInMinutes()
        {
            var maxTime = _timeSavingsCalculator.GetMaxTimeSaved(
                TimeSpan.FromMinutes(TimeSavedPerTask),
                TaskFrequency,
                SelectedFrequencyTimeUnit,
                TaskLifetime,
                SelectedTaskLifetimeTimeUnit);

            return maxTime;
        }
    }
}

