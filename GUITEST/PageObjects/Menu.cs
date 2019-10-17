using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace GUITEST.PageObjects
{
    class Menu
    {
        private IWebDriver driver;
        public Menu(IWebDriver driver)
        {
            this.driver = driver;
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            var test = wait.Until(ExpectedConditions.ElementExists(By.XPath("//*[contains(@class, 'home')]")));
            PageFactory.InitElements(driver, this);
        }
        [FindsBy(How = How.XPath, Using = "//*[contains(@class, 'home')]")]
        private IWebElement honeNavLink;

    }
}
