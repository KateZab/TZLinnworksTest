using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace GUITEST.PageObjects
{
    class HomePage
    {
        private IWebDriver driver;

        public HomePage(IWebDriver driver)
        {
            this.driver = driver;            
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            
            var test = wait.Until(ExpectedConditions.ElementExists(By.XPath("//*[contains(text(), 'API Description')]")));
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//*[contains(text(), 'API Description')]")]
        private IWebElement apiLink;

        [FindsBy(How = How.XPath, Using = "//*[contains(text(), 'Categories')]")]
        private IWebElement categories;

        public ApiPage OpenAPIPage()
        {
            apiLink.Click();
            return new ApiPage(this.driver);
        }

        public LoginPage GotoCategoryNotLogined()
        {
            categories.Click();
            return new LoginPage(this.driver);
        }
        public CategoryPage GotoCategoryLogined()
        {
            categories.Click();
            return new CategoryPage(this.driver);
        }

    }
}
