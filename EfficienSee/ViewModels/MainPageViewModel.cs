using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using EfficienSee.Services;

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
                    MaxTimeToAllot = GetMaxTimeToAllot();
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
                    MaxTimeToAllot = GetMaxTimeToAllot();
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
                    MaxTimeToAllot = GetMaxTimeToAllot();
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

        public MainPageViewModel(ITimeSavingsCalculator timeSavingsCalculator)
        {
            Debug.WriteLine($"**** {this.GetType().Name}.{nameof(MainPageViewModel)}:  ctor");

            _timeSavingsCalculator = timeSavingsCalculator;

            Title = "EfficienSee";
            TimeSavedLabelText = "By how much time could you shorten your task, given some effort to make some part of it automated, or more efficient?";
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

        internal double GetMaxTimeToAllot()
        {
            Debug.WriteLine($"**** {this.GetType().Name}.{nameof(GetMaxTimeToAllot)}");
            TimeSpan maxTime = _timeSavingsCalculator.GetTotalTimeSavedForTask(
                TimeSpan.FromHours(TimeSavedPerTask), TaskFrequency, TaskLifetime);

            return maxTime.TotalHours;
        }
    }
}

