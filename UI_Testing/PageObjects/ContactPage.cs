using OpenQA.Selenium;
using FluentAssertions;

namespace UI_Testing.PageObjects
{
    public class ContactPage
    {
        private readonly IWebDriver _driver;

        // Constructor to initialize the driver
        public ContactPage(IWebDriver driver)
        {
            _driver = driver;
        }

        // Element locators
        private IWebElement LetsGetStartedButton => _driver.FindElement(By.CssSelector("#prefooter"));
        private IWebElement ContactHeader => _driver.FindElement(By.XPath("//*[@id='post-198']/div/section[1]/div/h4"));

        // Methods for interacting with the Contact Page
        public void ClickLetsGetStarted()
        {
            LetsGetStartedButton.Click();
        }

        public void VerifyContactPage()
        {
            _driver.Url.Should().Be("https://www.agdata.com/contact/");
            _driver.Title.Should().Contain("Contact");
            ContactHeader.Text.Should().Be("CONTACT");
        }
    }
}
