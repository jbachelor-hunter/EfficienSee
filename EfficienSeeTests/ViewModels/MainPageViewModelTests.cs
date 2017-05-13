using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using EfficienSee.ViewModels;
using NUnit.Framework;

namespace EfficienSeeTests.ViewModels
{
    [TestFixture()]
    public class MainPageViewModelTests
    {
        MainPageViewModel mainPageViewModel;

        [TestFixtureSetUp]
        public void ClassInit()
        {

        }

        [SetUp]
        public void TestInit()
        {
            mainPageViewModel = new MainPageViewModel();
        }

        [Test]
        public void TestPropertiesSetToDefaultValuesOnInstantiation()
        {
            var failMessage = string.Empty;
            var failedProperties = new List<string>();

            if (string.IsNullOrWhiteSpace(mainPageViewModel.Title))
            {
                failedProperties.Add($"Title:  {mainPageViewModel.Title}");
            }

            if (string.IsNullOrWhiteSpace(mainPageViewModel.TimeSavedLabelText))
            {
                failedProperties.Add($"TimeSavedLabelText:  {mainPageViewModel.TimeSavedLabelText}");
            }

            if (mainPageViewModel.TimeSavedPerTask != 0)
            {
                failedProperties.Add($"TimeSavedPerTask:  {mainPageViewModel.TimeSavedPerTask}");
            }

            if (string.IsNullOrWhiteSpace(mainPageViewModel.TaskFrequencyLabelText))
            {
                failedProperties.Add($"TaskFrequencyLabelText:  {mainPageViewModel.TaskFrequencyLabelText}");
            }

            if (mainPageViewModel.TaskFrequency != 0)
            {
                failedProperties.Add($"TaskFrequency:  {mainPageViewModel.TaskFrequency}");
            }

            if (mainPageViewModel.TaskLifetime != 0)
            {
                failedProperties.Add($"TaskLifetime:  {mainPageViewModel.TaskLifetime}");
            }

            if (string.IsNullOrWhiteSpace(mainPageViewModel.TaskLifetimeLabelText))
            {
                failedProperties.Add($"TaskLifetimeLabelText:  {mainPageViewModel.TaskLifetimeLabelText}");
            }

            if (failedProperties.Count > 0)
            {
                failMessage = $"Some properties not set to the correct initial value:  \n\t{string.Join("\n\t", failedProperties)}";
                Assert.Fail(failMessage);
            }
            else
            {
                Assert.Pass();
            }
        }

        [Test]
        [TestCase(0, 1, true)]
        [TestCase(1, 1, false)]
        [TestCase(9, 1, true)]
        [TestCase(7, 7, false)]
        public void TestTimeSavedPerTaskOnlySetsValueWhenItsDifferent(int initialValue, int newValue, bool shouldFirePropertyChanged)
        {
            mainPageViewModel.TimeSavedPerTask = initialValue;

            bool fired = false;
            mainPageViewModel.PropertyChanged += (sender, e) =>
            {
                Console.WriteLine($"Property changing on {e.PropertyName}");
                if (e.PropertyName == "TimeSavedPerTask")
                {
                    fired = true;
                }
            };

            mainPageViewModel.TimeSavedPerTask = newValue;

            if (shouldFirePropertyChanged)
            {
                Assert.IsTrue(fired);
            }
            else
            {
                Assert.IsFalse(fired);
            }
        }

        [Test]
        public void TestPropertyChangeFiredForTitle()
        {
            mainPageViewModel.Title = string.Empty;
            bool fired = false;
            mainPageViewModel.PropertyChanged += (sender, e) =>
            {
                if (e.PropertyName == "Title")
                {
                    fired = true;
                }
            };

            mainPageViewModel.Title = "cool sauce";
            Assert.IsTrue(fired);
        }

        [Test]
        public void TestPropertyChangeFiredForTimeSavedLabelText()
        {
            mainPageViewModel.TimeSavedLabelText = string.Empty;
            bool fired = false;
            mainPageViewModel.PropertyChanged += (sender, e) =>
            {
                if (e.PropertyName == "TimeSavedLabelText")
                {
                    fired = true;
                }
            };

            mainPageViewModel.TimeSavedLabelText = "hot sauce";
            Assert.IsTrue(fired);
        }

        [Test]
        public void TestPropertyChangeFiredForTaskFrequencyLabelText()
        {
            mainPageViewModel.TaskFrequencyLabelText = string.Empty;
            bool fired = false;
            mainPageViewModel.PropertyChanged += (sender, e) =>
            {
                if (e.PropertyName == "TaskFrequencyLabelText")
                {
                    fired = true;
                }
            };

            mainPageViewModel.TaskFrequencyLabelText = "hot sauce";
            Assert.IsTrue(fired);
        }

        [Test]
        public void TestPropertyChangeFiredForTaskFrequency()
        {
            mainPageViewModel.TaskFrequency = 0;
            bool fired = false;
            mainPageViewModel.PropertyChanged += (sender, e) =>
            {
                if (e.PropertyName == "TaskFrequency")
                {
                    fired = true;
                }
            };

            mainPageViewModel.TaskFrequency = 90;
            Assert.IsTrue(fired);
        }
    }
}
