using OpenQA.Selenium;

namespace GUITEST.PageObjects
{
    internal class ApiPage
    {
        private IWebDriver driver;

        public ApiPage(IWebDriver driver)
        {
            this.driver = driver;
        }
    }
}