using Xunit;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium.Firefox;
using GUITEST.PageObjects;
using OpenQA.Selenium.Chrome;
using SeleniumExtras.PageObjects;

namespace GUITEST
{
    public class LinnworksTestGUI
    {
        [Fact]
        public void CheckCatgoryLinkNotLogined()
        {
            using (var driver = new ChromeDriver())
            {
                //Url shoud be read from config and depends on envirovment
                driver.Url = "http://localhost:59510";
                var homePage = new HomePage(driver);
                homePage.GotoCategoryNotLogined();
            }        
            
        }
        [Fact]
        public void LoginCheckThatCategoryPageOpened()
        {
            using (var driver = new ChromeDriver())
            {
                driver.Url = "http://localhost:59510";
                var homePage = new HomePage(driver);
                var loginPage = homePage.GotoCategoryNotLogined();
                //need read token from config
                loginPage.Login("bccf905c-6592-40f2-8db1-c976791fa40a");
            }

        }
        [Fact]
        public void AddNewCategory()
        {
            using (var driver = new ChromeDriver())
            {
                driver.Url = "http://localhost:59510";
                var homePage = new HomePage(driver);
                var loginPage = homePage.GotoCategoryNotLogined();
                //need read token from config
                var categoryPage = loginPage.Login("bccf905c-6592-40f2-8db1-c976791fa40a");
                var addCategoryPage = categoryPage.CreateNew();
                //name read from config
                addCategoryPage.AddCategory("Test");

            }

        }
        [Fact]
        public void AddNewCategoryEmtyNam()
        {
            using (var driver = new ChromeDriver())
            {
                driver.Url = "http://localhost:59510";
                var homePage = new HomePage(driver);
                var loginPage = homePage.GotoCategoryNotLogined();
                //need read token from config
                var categoryPage = loginPage.Login("bccf905c-6592-40f2-8db1-c976791fa40a");
                var addCategoryPage = categoryPage.CreateNew();
                //name read from config
                addCategoryPage.AddCategory();

            }


        }
        [Fact]
        public void DeleteCategoty()
        {
            using (var driver = new ChromeDriver())
            {
                driver.Url = "http://localhost:59510";
                var homePage = new HomePage(driver);
                var loginPage = homePage.GotoCategoryNotLogined();
                //need read token from config
                var categoryPage = loginPage.Login("bccf905c-6592-40f2-8db1-c976791fa40a");
                var addCategoryPage = categoryPage.CreateNew();
                //name read from config
                var categoryPagenew = addCategoryPage.AddCategory("Todelete");
                categoryPagenew.DeleteCatgory("Todelete");

            }


        }

    }
}
