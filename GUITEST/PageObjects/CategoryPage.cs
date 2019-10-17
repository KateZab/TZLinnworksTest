using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;
using Xunit;

namespace GUITEST.PageObjects
{
    internal class CategoryPage
    {
        private IWebDriver driver;

        public CategoryPage(IWebDriver driver)
        {
            this.driver = driver;
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            //var test = wait.Until(driver => driver.FindElement(By.XPath("//*[contains(text(), 'Create New')]")));
            var lol = wait.Until(ExpectedConditions.ElementExists(By.XPath("//*[contains(text(), 'Create New')]")));
            PageFactory.InitElements(driver, this);
        }
        [FindsBy(How = How.XPath, Using = "//*[contains(text(), 'Create New')]")]
        private IWebElement creatNew;

        public AddNewCategoryPage CreateNew()
        {
            creatNew.Click();
            return new AddNewCategoryPage(this.driver);
        }
        public CategoryPage DeleteCatgory(string name)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            var parent = wait.Until(driver => driver.FindElement(By.XPath($"//td[contains(text(), '{name}')]//ancestor::tr")));
            var delete = parent.FindElement(By.LinkText("Delete"));
            delete.Click();            
            wait.Until(ExpectedConditions.AlertIsPresent());
            this.driver.SwitchTo().Alert().Accept();       
            Helper.WaitNotExists(this.driver, By.XPath($"//td[contains(text(), '{name}')]//ancestor::tr"), 10);
            return new CategoryPage(this.driver);
        }
    }
}