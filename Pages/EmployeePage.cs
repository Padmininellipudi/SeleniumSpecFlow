using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumPOM.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SeleniumPOM.Pages
{
    internal class EmployeePage
    {
        private IWebDriver driver;
        IWebElement goToLastPageButton;
        //Locators
        String locButtonCreate = "//*[@id='container']/p/a";

        public EmployeePage(IWebDriver driver)
        {
            this.driver = driver;
        }

        //Create Employee record
        public void CreateEmployee(IWebDriver driver)
        {
            //Click on create button
            IWebElement createButton = driver.FindElement(By.XPath(locButtonCreate));
            createButton.Click();
            Console.WriteLine("Employee Details Page is displayed");

            //Identify the Name textbox and input the name
            IWebElement nameTextbox = driver.FindElement(By.Id("Name"));
            nameTextbox.SendKeys("Padmini");
            Thread.Sleep(1000);

            //Identify the Username textbox and input the username
            IWebElement usernameTextbox = driver.FindElement(By.Id("Username"));
            usernameTextbox.SendKeys("Taruni");
            Thread.Sleep(1000);

            //Identify the Contact field and enter the contact number
            IWebElement contactTextBox = driver.FindElement(By.Id("ContactDisplay"));
            contactTextBox.SendKeys("12345");
            Thread.Sleep(1000);

            //Identify the Password textbox and input the password
            IWebElement passwordTextbox = driver.FindElement(By.Id("Password"));
            passwordTextbox.SendKeys("Paddu@1234");
            Thread.Sleep(2000);

            //Identify the Retype Password textbox and input the password
            IWebElement retypePasswordTextbox = driver.FindElement(By.Id("RetypePassword"));
            retypePasswordTextbox.SendKeys("Paddu@1234");
            Thread.Sleep(2000);

            //Identify the IsAdmin checkbox and check the box
            IWebElement isAdminCheckbox = driver.FindElement(By.Id("IsAdmin"));
            isAdminCheckbox.Click();
            Thread.Sleep(2000);

            // Identify Vehicle textbox and input the vehicle
            IWebElement vehicleTextbox = driver.FindElement(By.XPath("//*[@id='UserEditForm']/div/div[7]/div/span[1]/span/input"));
            vehicleTextbox.SendKeys("22");

            // Identify Groups Dropdown menu and select dddd
            IWebElement groupsDropdown = driver.FindElement(By.XPath("//*[@id='UserEditForm']/div/div[8]/div/div/div[1]"));
            groupsDropdown.Click();
            Thread.Sleep(2000);
            //Wait.WaitToBeClickable(driver, "xPath", "//*[@id='groupList_listbox']/li[4]", 3);

            IWebElement groupsOption = driver.FindElement(By.XPath("//*[@id='groupList_listbox']/li[4]"));
            groupsOption.Click();
            Console.WriteLine("Groups option dddd is clicked");

            //Click on save button
            IWebElement saveButton = driver.FindElement(By.Id("SaveButton"));
            saveButton.Click();
            Thread.Sleep(3000);
            Console.WriteLine("The details are saved");

            //Click Back to List as save is not redirecting to table
            IWebElement linkBackToList = driver.FindElement(By.XPath("//*[@id='container']/div/a"));
            linkBackToList.Click();

            //Waiting for table to be displayed
            Wait.WaitToBeVisible(driver, "XPath", "//*[@id='usersGrid']/div[3]/table", 3);
            Console.WriteLine("Grid is displayed");

            // Click on go to last page button
            IWebElement goToLastPageButton = driver.FindElement(By.XPath("//*[@id='usersGrid']/div[4]/a[4]/span"));
            goToLastPageButton.Click();
            Thread.Sleep(3000);

            // Check if record created is displayed in last page
            IWebElement actualName = driver.FindElement(By.XPath("//*[@id='usersGrid']/div[3]/table/tbody/tr[last()]/td[1]"));
            IWebElement actualUsername = driver.FindElement(By.XPath("//*[@id='usersGrid']/div[3]/table/tbody/tr[last()]/td[2]"));
            Console.WriteLine("Actual name is ...", actualName.Text);
            Console.WriteLine("Actual username is ...", actualUsername.Text);

        }

        // Edit Employee Record
        public void EditEmployee(IWebDriver driver)
        {
            // Wait until the entire Employee page is displayed
            Wait.WaitToBeVisible(driver, "XPath", "//*[@id='usersGrid']/div[3]/table/tbody/tr[1]/td[1]", 3);
            // Click on go to last page button
            goToLastPageButton = driver.FindElement(By.XPath("//*[@id='usersGrid']/div[4]/a[4]/span"));
            goToLastPageButton.Click();
            Thread.Sleep(3000);
            IWebElement findRecordCreated = driver.FindElement(By.XPath("//*[@id='usersGrid']/div[3]/table/tbody/tr[last()]/td[1]"));
            
            if (findRecordCreated.Text == "Padmini")
            {
                // Click on edit button
                IWebElement editButton = driver.FindElement(By.XPath("//*[@id='usersGrid']/div[3]/table/tbody/tr[last()]/td[3]/a[1]"));
                editButton.Click();
                Thread.Sleep(3000);
            }
            else
            {
                Assert.Fail("Record to be edited is not found");
            }

            // Edit the name
            IWebElement editNameTextBox = driver.FindElement(By.Id("Name"));
            editNameTextBox.Clear();
            editNameTextBox.SendKeys("Paddu");

            // Edit the username
            IWebElement editUserNameTextBox = driver.FindElement(By.Id("Username"));
            editUserNameTextBox.Clear();
            editUserNameTextBox.SendKeys("Nellipudi");

            // Edit the contact
            IWebElement editContactTextBox = driver.FindElement(By.Id("ContactDisplay"));
            editContactTextBox.Clear();
            editContactTextBox.SendKeys("123456789");

            //// Edit the Password
            //IWebElement editPasswordTextBox = driver.FindElement(By.Id("Password"));
            //editPasswordTextBox.Clear();
            //editPasswordTextBox.SendKeys("Paddu@456");

            //// Edit the RetypePassword
            //IWebElement editRetypePasswordTextBox = driver.FindElement(By.Id("Password"));
            //editRetypePasswordTextBox.Clear();
            //editRetypePasswordTextBox.SendKeys("Paddu@456");

            //Click save button
            IWebElement editSaveButton = driver.FindElement(By.Id("SaveButton"));
            editSaveButton.Click();
            Thread.Sleep(5000);

            //Click Back to List as save is not redirecting to table
            IWebElement linkBackToList = driver.FindElement(By.XPath("//*[@id='container']/div/a"));
            linkBackToList.Click();
            
            //Waiting for table to be displayed
            Wait.WaitToBeVisible(driver, "XPath", "//*[@id='usersGrid']/div[3]/table", 3);
            Console.WriteLine("Grid is displayed");
            
            //Click on go to last page button
            goToLastPageButton = driver.FindElement(By.XPath("//*[@id='usersGrid']/div[4]/a[4]/span"));
            goToLastPageButton.Click();
            Thread.Sleep(3000);
            

            // Assertion
            IWebElement createdName = driver.FindElement(By.XPath("//*[@id='usersGrid']/div[3]/table/tbody/tr[last()]/td[1]"));
            IWebElement createdUserName = driver.FindElement(By.XPath("//*[@id='usersGrid']/div[3]/table/tbody/tr[last()]/td[2]"));
            Assert.That(createdName.Text == "Paddu", "Name record has not been edited");
            Assert.That(createdUserName.Text == "Nellipudi", "Username record has not been edited");
            Assert.Pass("Edit successful");
        }


        // Delete Employee Record
        public void DeleteEmployee(IWebDriver driver)
        {
            // Wait till entire page is displayed
            Wait.WaitToBeVisible(driver, "XPath", "//*[@id='usersGrid']/div[3]/table/tbody/tr[1]/td[1]", 3);
            goToLastPageButton = driver.FindElement(By.XPath("//*[@id='usersGrid']/div[4]/a[4]/span"));
            goToLastPageButton.Click();
            Thread.Sleep(3000);

            // Delete employee record
            // Click delete button
            IWebElement findEditedRecord = driver.FindElement(By.XPath("//*[@id='usersGrid']/div[3]/table/tbody/tr[last()]/td[1]"));
            if (findEditedRecord.Text == "Paddu")
            {
                IWebElement deleteButton = driver.FindElement(By.XPath("//*[@id='usersGrid']/div[3]/table/tbody/tr[last()]/td[3]/a[2]"));
                deleteButton.Click();
                Thread.Sleep(1000);

                // Wait for the alert to be displayed
                IAlert alert = driver.SwitchTo().Alert();

                //Store the alert in a variable for reuse
                string text = alert.Text;

                //Press Ok button
                alert.Accept();
                Assert.Pass("Delete Successful");
            }
            else
            {
                Assert.Fail("Edited record not found, Record not Deleted");
                Thread.Sleep(1000);
            }
            driver.Navigate().Refresh();
            Thread.Sleep(1000);

            //Check if the deleted record is not displayed
            IWebElement editedName = driver.FindElement(By.XPath("//*[@id='usersGrid']/div[3]/table/tbody/tr[last()]/td[1]"));
            IWebElement editedUserName = driver.FindElement(By.XPath("//*[@id='usersGrid']/div[3]/table/tbody/tr[last()]/td[2]"));
            
            // Assertion
            Assert.That(editedName.Text != "Paddu", "Name record hasn't been deleted.");
            Assert.That(editedUserName.Text != "Nellipudi", "Username record hasn't been deleted.");
        }

    }
}

