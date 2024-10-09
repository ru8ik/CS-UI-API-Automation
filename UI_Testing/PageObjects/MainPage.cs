using OpenQA.Selenium;

namespace UI_Testing.PageObjects
{
    public class MainPage
    {
        private readonly IWebDriver _driver;

        // Constructor to initialize the driver
        public MainPage(IWebDriver driver)
        {
            _driver = driver;
        }

        // Element locators
        private IWebElement SolutionsMenu => _driver.FindElement(By.CssSelector("#menu-item-991"));

        // Methods for interacting with the Main Page
        public void ClickSolutionsMenu()
        {
            SolutionsMenu.Click();
        }
    }
}
