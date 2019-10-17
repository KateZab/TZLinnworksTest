using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;

namespace GUITEST.PageObjects
{
    internal class AddNewCategoryPage
    {
        private IWebDriver driver;

        public AddNewCategoryPage(IWebDriver driver)
        {
            this.driver = driver;
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            var test = wait.Until(ExpectedConditions.ElementExists(By.XPath("//input[contains(@formcontrolname,'categoryName')]")));
            PageFactory.InitElements(driver, this);
        }
        [FindsBy(How = How.XPath, Using = "//input[contains(@formcontrolname,'categoryName')]")]
        private IWebElement inputName;

        [FindsBy(How = How.XPath, Using = "//button[contains(text(),'Save')]")]
        private IWebElement save;

        public AddNewCategoryPage AddCategory()
        {
            save.Click();
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            var span = wait.Until(ExpectedConditions.ElementExists(By.XPath("//span[contains(text(),'Name is required')]")));
            return new AddNewCategoryPage(this.driver);
        }
        public CategoryPage AddCategory(string name)
        {
            inputName.SendKeys(name);
            save.Click();
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            var added = wait.Until(ExpectedConditions.ElementExists(By.XPath($"//td[contains(text(), {name})]")));
            return new CategoryPage(this.driver);
        }


    }
}