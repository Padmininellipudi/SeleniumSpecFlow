using System;
using SeleniumPOM.Pages;
using SeleniumPOM.Utilities;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;

namespace SeleniumPOM.StepDefinitions
{
    [Binding]
    public class TMFeatureStepDefinitions : CommonDriver
    {
        // Initializing Page Objects
        LoginPage loginPageObj = new LoginPage();
        HomePage homePageObj = new HomePage();
        TMPage tMPageObj = new TMPage();


        [Given(@"Logged into Turnup portal successfully")]
        public void GivenLoggedIntoTurnupPortalSuccessfully()
        {
            driver = new ChromeDriver();
            loginPageObj.LoginSteps(driver);
        }

        [Given(@"I navigate to time and material page")]
        public void GivenINavigateToTimeAndMaterialPage()
        {
            homePageObj.GoToTMPage(driver);
        }

        [When(@"I created Time and Material record")]
        public void WhenICreatedTimeAndMaterialRecord()
        {
            // TM Page object initialization and definition
            tMPageObj.CreateTM(driver);
        }

        [Then(@"Time and material record created successfully")]
        public void ThenTimeAndMaterialRecordCreatedSuccessfully()
        {
            String newCode = tMPageObj.getCode(driver);
            String newTypeCode = tMPageObj.getTypeCode(driver);
            String newDescription = tMPageObj.getDescription(driver);
            String newPrice = tMPageObj.getPrice(driver);
            
            Assert.That(newCode == "Padmini", "Actual Code and Expected code do not match");
            Assert.That(newTypeCode == "M", "Actual TypeCode and Expected TypeCode do not match");
            Assert.That(newDescription == "Taruni", "Actual Description and Expected Description do not match");
            Assert.That(newPrice == "$500.00", "Actual Price and Expected Price do not match");
        }
        
        [When(@"I update '([^']*)' '([^']*)' '([^']*)' on an existing time and material record")]
        public void WhenIUpdateOnAnExistingTimeAndMaterialRecord(string p0, string p1, string p2)
        {
            tMPageObj.EditTM(driver, p0, p1, p2);
        }

        [Then(@"Time and material should have updated '([^']*)' '([^']*)' '([^']*)'")]
        public void ThenTimeAndMaterialShouldHaveUpdated(string p0, string p1, string p2)
        {
            String editedDescription = tMPageObj.GetEditedDescription(driver);
            String editedCode = tMPageObj.GetEditedCode(driver);
            String editedPrice = tMPageObj.GetEditedPrice(driver);

            Assert.That(editedDescription == p0, "Actual Description and Expected Description do not match");
            Assert.That(editedCode == p1, "Actual code and Expected Code do not match");
            Assert.That(editedPrice == p2, "Actual Price and Expected Price do not match");
        }
    }
}
