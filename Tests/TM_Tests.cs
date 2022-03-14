using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumPOM.Pages;
using SeleniumPOM.Utilities;
using System;
using System.Threading;

namespace SeleniumPOM.Tests
{
    [TestFixture]
    [Parallelizable]
    internal class TM_Tests : CommonDriver
    {
        [Test, Order (1), Description("Check if user is able to create a material record with valid data")]

        public void CreateTM_Test()
        {
            // Home page object initialization and definition
            HomePage homePageObj = new HomePage();
            homePageObj.GoToTMPage(driver);
            // TM page object initialization and definition
            TMPage tMPageObj = new TMPage();
            tMPageObj.CreateTM(driver);
        }

        [Test, Order(2), Description("Check if user is able to edit a material record with valid data")]

        public void EditTM_Test()
        {
            // Home page object initialization and definition
            HomePage homePageObj = new HomePage();
            homePageObj.GoToTMPage(driver);

            // Edit TM
            TMPage tMPageObj = new TMPage();
            tMPageObj.EditTM(driver, "dummy1", "dummy2", "dummy3");
        }

        //[Test, Order(3), Description("Check if user is able to delete a material record with valid data")]

        //public void deleteTM_Test()
        //{
        //    // Home page object initialization and definition
        //    HomePage homePageObj = new HomePage();
        //    homePageObj.GoToTMPage(driver);

        //    // Delete TM
        //    TMPage tMPageObj = new TMPage();
        //    tMPageObj.DeleteTM(driver);
        //}
    }
}