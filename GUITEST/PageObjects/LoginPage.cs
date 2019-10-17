using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;

namespace GUITEST.PageObjects
{
    internal class LoginPage
    {
        private IWebDriver driver;

        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            var test = wait.Until(driver => driver.FindElement(By.Id("token")));
            PageFactory.InitElements(driver, this);
        }
        [FindsBy(How = How.Id, Using = "token")]
        private IWebElement token;

        [FindsBy(How = How.XPath, Using = "//*[contains(text(), 'Login')] ")]
        private IWebElement login;
        public CategoryPage Login(string tokenValue)
        {
            this.token.SendKeys(tokenValue);
            login.Click();
            return new CategoryPage(this.driver);
        }
    }
}