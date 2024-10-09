using OpenQA.Selenium;
using System.Collections.Generic;

namespace UI_Testing.PageObjects
{
    public class SolutionsPage
    {
        private readonly IWebDriver _driver;

        // Constructor to initialize the driver
        public SolutionsPage(IWebDriver driver)
        {
            _driver = driver;
        }

        // Element locators
        private IWebElement MarketIntelligenceSubmenu => _driver.FindElement(By.CssSelector("#menu-item-813"));

        // Methods for interacting with the Solutions Page
        public void ClickMarketIntelligence()
        {
            MarketIntelligenceSubmenu.Click();
        }

        public List<IWebElement> GetHeadings()
        {
            return new List<IWebElement>
            {
                _driver.FindElement(By.XPath("//h3[text()='Minimize Costs']")),
                _driver.FindElement(By.XPath("//h3[text()='Generate Revenue']")),
                _driver.FindElement(By.XPath("//h3[text()='Mitigate Risk']"))
            };
        }
    }
}
