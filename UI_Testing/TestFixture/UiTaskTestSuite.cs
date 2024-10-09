using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using NUnit.Allure.Core;
using NUnit.Allure.Attributes;
using OpenQA.Selenium.Support.UI;
using FluentAssertions;
using System.Collections.Generic;
using UI_Testing.PageObjects;

namespace UI_Testing.TestFixture
{
    [TestFixture]
    //[Parallelizable(ParallelScope.All)] 
    [AllureNUnit]
    [Obsolete]
    internal class TestBetas
    {
        private IWebDriver _driver;
        private WebDriverWait _wait;
        private MainPage _mainPage;
        private SolutionsPage _solutionsPage;
        private ContactPage _contactPage;

        // Setup method to initialize browser, driver, and page objects
        [SetUp]
        public void SetUp()
        {
            _driver = new ChromeDriver();
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);
            _driver.Manage().Window.Maximize();
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));

            // Initialize Page Objects
            _mainPage = new MainPage(_driver);
            _solutionsPage = new SolutionsPage(_driver);
            _contactPage = new ContactPage(_driver);
        }

        // TearDown method to close the browser after each test
        [TearDown]
        public void TearDown()
        {
            _driver.Quit();
        }

        // Test that verifies Solutions and Market Intelligence functionality
        [Test, TestCaseSource(nameof(UrlTestCases))]
        [AllureDescription("Test that verifies different page URLs in the application.")]
        [Obsolete]
        public void pageUrlcheck(string url, string expectedUrl)
        {
            // Navigate to the given URL
            _driver.Navigate().GoToUrl(url);

            // Click on "Solutions" menu using the MainPage object
            _mainPage.ClickSolutionsMenu();

            // Verify the URL is correct
            _driver.Url.Should().Be(expectedUrl);

            // Add screenshot for verification

            // Verify page title contains the correct word
            _driver.Title.Should().Contain("HOME - AGDATA");
        }

        // Test that verifies Market Intelligence sub-menu
        [Test]
        [AllureDescription("Happy path test: clicking on Market Intelligence submenu.")]
        [Obsolete]
        public void GotToMarketIntelligenceSubmenu()
        {
            _driver.Navigate().GoToUrl("https://www.agdata.com/");

            // Click on "Solutions" menu
            _mainPage.ClickSolutionsMenu();

            // Click on "Market Intelligence" submenu option
            _solutionsPage.ClickMarketIntelligence();

            // Verify the expected headings are displayed on the page
            var headings = _solutionsPage.GetHeadings();
            List<string> expectedHeadings = new List<string> { "MINIMIZE COSTS", "GENERATE REVENUE", "MITIGATE RISK" };

            for (int i = 0; i < headings.Count; i++)
            {
                headings[i].Text.Should().Be(expectedHeadings[i]);
            }
        }

        // Test for scrolling to the bottom and clicking "Let's Get Started" button
        [Test]
        [AllureDescription("Test for clicking the 'Let's Get Started' button.")]
        [Obsolete]
        public void LetsGetStartedButtonClick()
        {
            _driver.Navigate().GoToUrl("https://www.agdata.com/solutions/market-intelligence/");

            // Scroll to the bottom of the page
            IJavaScriptExecutor js = (IJavaScriptExecutor)_driver;
            js.ExecuteScript("window.scrollTo(0, document.body.scrollHeight);");

            // Click the "Let's Get Started" button using ContactPage object
            _contactPage.ClickLetsGetStarted();

            // Verify the Contact page details
            _contactPage.VerifyContactPage();
        }


        // Test case source for data-driven testing
        public static IEnumerable<TestCaseData> UrlTestCases()
        {
            yield return new TestCaseData("https://www.agdata.com/", "https://www.agdata.com/#");

        }


        // Helper method for screenshots


    }
}
