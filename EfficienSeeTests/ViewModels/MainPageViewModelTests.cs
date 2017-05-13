using NUnit.Framework;
using System;
using EfficienSee.ViewModels;

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
        [Ignore("need prism nuget pkg... No go on airplane sans wifi!")]
        public void TestTimeSavedPerTaskOnlySetsValueWhenItsDifferent()
        {

        }
    }
}
