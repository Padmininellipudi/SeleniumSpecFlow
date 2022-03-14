using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumPOM.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumPOM.Pages
{
    internal class LoginPage
    {
        public void LoginSteps(IWebDriver driver)
        {
            // open chrome browser
            driver.Manage().Window.Maximize();
            //launch Turnup portal
            driver.Navigate().GoToUrl("http://horse.industryconnect.io/Account/Login?ReturnUrl=%2f");
            try
            {
                //Identify username textbox and enter valid username
                IWebElement usernameTextbox = driver.FindElement(By.Id("UserName"));
                usernameTextbox.SendKeys("hari");

                //Identify password textbox and enter valid password
                IWebElement passwordTextbox = driver.FindElement(By.Id("Password"));
                passwordTextbox.SendKeys("123123");

                //click on login button
                IWebElement loginButton = driver.FindElement(By.XPath("//*[@id='loginForm']/form/div[3]/input[1]"));
                loginButton.Click();
            }
            catch (Exception ex)
            {
                Assert.Fail("Turnup portal Login page didn't launch", ex.Message);
                throw;
            }    

            
        }
    }
}
