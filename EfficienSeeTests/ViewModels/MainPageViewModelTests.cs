using System;
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
            if (string.IsNullOrWhiteSpace(mainPageViewModel.Title))
            {
                Assert.Fail("Title was not set.");
            }

            if (string.IsNullOrWhiteSpace(mainPageViewModel.TimeSavedLabelText))
            {
                Assert.Fail("TimeSavedLabelText was not set.");
            }

            if (mainPageViewModel.TimeSavedPerTask != 0)
            {
                Assert.Fail("TimeSavedPerTask was not 0 to start.");
            }

            if (string.IsNullOrWhiteSpace(mainPageViewModel.TaskFrequencyLabelText))
            {
                Assert.Fail("TaskFrequencyLabelText was not set.");
            }

            if (mainPageViewModel.TaskFrequency != 0)
            {
                Assert.Fail("Task frequency not properly set.");
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
