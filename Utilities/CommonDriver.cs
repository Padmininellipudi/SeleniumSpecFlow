using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumPOM.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumPOM.Utilities
{
    public class CommonDriver
    {
        public IWebDriver driver;

        [OneTimeSetUp]
        public void LoginFunction()
        {
            // Open Chrome Browser
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();

            // Login page object Initialization and Definition
            LoginPage loginPageObj = new LoginPage();
            loginPageObj.LoginSteps(driver);
        }
        [OneTimeTearDown]
        public void CloseTestRun()
        {
            driver.Quit();
        }
    }
}
