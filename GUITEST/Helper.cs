using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace GUITEST
{
    public static class Helper
    {
        public static IWebElement FindElementSafe(this IWebDriver driver, By by)
        {
            try
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                var test = wait.Until(driver => driver.FindElement(by));
                return test;
            }
            catch (NoSuchElementException)
            {
                return null;
            }
        }
        public static void WaitNotExists(this IWebDriver driver, By by, int sec)
        {
            int count = 0;
            while (driver.FindElements(by).Any())
            {
                count++;
                Thread.Sleep(100);
                if (count > sec * 10)
                {
                    throw new Exception("Element still here");
                }
            }
        }
    }
}
