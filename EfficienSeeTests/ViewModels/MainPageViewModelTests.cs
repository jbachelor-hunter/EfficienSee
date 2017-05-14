using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using EfficienSee.ViewModels;
using NUnit.Framework;
using NSubstitute;
using EfficienSee.Services;

namespace EfficienSeeTests.ViewModels
{
    [TestFixture()]
    public class MainPageViewModelTests
    {
        MainPageViewModel mainPageViewModel;
        ITimeSavingsCalculator timeSavingsCalculatorSub;

        [TestFixtureSetUp]
        public void ClassInit()
        {

        }

        [SetUp]
        public void TestInit()
        {
            timeSavingsCalculatorSub = Substitute.For<ITimeSavingsCalculator>();

            mainPageViewModel = new MainPageViewModel(timeSavingsCalculatorSub);
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

            if (string.IsNullOrWhiteSpace(mainPageViewModel.MaxTimeToAllotLabelText))
            {
                failedProperties.Add($"MaxTimeToAllotLabelText:  {mainPageViewModel.MaxTimeToAllotLabelText}");
            }

            if (TestUtilities.AreTwoDoublesCloseEnough(0.0, 0.0) == false)
            {
                failedProperties.Add($"MaxTimeToAllot:  {mainPageViewModel.MaxTimeToAllot}");
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

        [Test]
        public void TestPropertyChangeFiredForTaskLifetime()
        {
            mainPageViewModel.TaskLifetime = 0;
            bool fired = false;
            mainPageViewModel.PropertyChanged += (sender, e) =>
            {
                if (e.PropertyName == "TaskLifetime")
                {
                    fired = true;
                }
            };

            mainPageViewModel.TaskLifetime = 50;
            Assert.IsTrue(fired);
        }

        [Test]
        [Ignore("not ready")]
        public void MaxTimeToAllotRecalculatesWhenTaskLifetimeChanges()
        {
            mainPageViewModel.TaskLifetime += 50;

            //timeSavingsCalculatorSub.Received(1).GetTotalTimeSavedForTask(
            //    Arg.Any<TimeSpan>(), Arg.Any<int>(), mainPageViewModel.TaskLifetime);
        }

        [Test]
        [Ignore("not ready")]
        public void MaxTimeToAllotRecalculatesWhenTaskFrequencyChanges()
        {
            mainPageViewModel.TaskFrequency += 5;

            //timeSavingsCalculatorSub.Received(1).GetTotalTimeSavedForTask(
            //    Arg.Any<TimeSpan>(), 5, Arg.Any<int>());
        }

        [Test]
        [Ignore("not ready")]
        public void MaxTimeToAllotRecalculatesWhenTimeSavedPerTaskChanges()
        {
            mainPageViewModel.TimeSavedPerTask += 5;

            //timeSavingsCalculatorSub.Received(1).GetTotalTimeSavedForTask(
            //    TimeSpan.FromMinutes(5), Arg.Any<int>(), Arg.Any<int>());
        }
    }
}
