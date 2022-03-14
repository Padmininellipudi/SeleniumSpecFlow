using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumPOM.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SeleniumPOM.Pages
{
    public class TMPage
    {
        private IWebDriver driver;
        IWebElement goToLastPageButton;

        //Create time and material record
        public void CreateTM(IWebDriver driver)
        {
            //Click on create new button
            IWebElement createNewButton = driver.FindElement(By.XPath("//*[@id='container']/p/a"));
            createNewButton.Click();

            //Select material from typecode dropdown
            IWebElement typeCodeDropdown = driver.FindElement(By.XPath("//*[@id='TimeMaterialEditForm']/div/div[1]/div/span[1]/span/span[1]"));
            typeCodeDropdown.Click();
            Wait.WaitToBeClickable(driver, "XPath", "//*[@id='TypeCode_listbox']/li[1]", 2);
            //Thread.Sleep(3000);

            IWebElement materialOption = driver.FindElement(By.XPath("//*[@id='TypeCode_listbox']/li[1]"));
            materialOption.Click();

            //Identify the code textbox and input a code
            IWebElement codeTextbox = driver.FindElement(By.Id("Code"));
            codeTextbox.SendKeys("Padmini");

            //Identify the Description textbox and input the description
            IWebElement descriptionTextbox = driver.FindElement(By.Id("Description"));
            descriptionTextbox.SendKeys("Taruni");

            //Identify the price field and enter the price
            IWebElement priceTag = driver.FindElement(By.XPath("//*[@id='TimeMaterialEditForm']/div/div[4]/div/span[1]/span/input[1]"));
            priceTag.Click();

            IWebElement priceTextbox = driver.FindElement(By.XPath("//*[@id='Price']"));
            priceTextbox.SendKeys("500");

            //Click on save button
            IWebElement saveButton = driver.FindElement(By.Id("SaveButton"));
            saveButton.Click();
            //Waiting for First record on table to be displayed
            Wait.WaitToBeVisible(driver, "XPath", "//*[@id='tmsGrid']/div[3]/table/tbody/tr[1]/td[1]", 2);

            //Click on go to last page button
            goToLastPageButton = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[4]/a[4]/span"));
            goToLastPageButton.Click();
            Thread.Sleep(3000);                                                       
        }

        public String getCode(IWebDriver driver)
        {
            IWebElement actualCode = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[1]"));
            return actualCode.Text;
        }

        public String getTypeCode(IWebDriver driver)
        {
            IWebElement actualTypeCode = driver.FindElement(By.XPath("//*[@id='tmsgrid']/div[3]/table/tbody/tr[last()]/td[2]"));
            return actualTypeCode.Text;
        }

        public String getDescription(IWebDriver driver)
        {
            IWebElement actualDescription = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[3]"));
            return actualDescription.Text;
        }

        public String getPrice(IWebDriver driver)
        {
            IWebElement actualPrice = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[4]"));
            return actualPrice.Text;
        }

        //Edit time and material record
        public void EditTM(IWebDriver driver, String description, String code, String price)
        {
            //Wait until the entire TM page is displayed
            Wait.WaitToBeVisible(driver, "XPath", "//*[@id='tmsGrid']/div[3]/table/tbody/tr[1]/td[1]", 2);

            //Click on go to last page button
            goToLastPageButton = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[4]/a[4]/span"));
            goToLastPageButton.Click();
            Thread.Sleep(3000);
            IWebElement findRecordCreated = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[1]"));
            if (findRecordCreated.Text == "Padmini")
            {
                // Click on edit button
                IWebElement editButton = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[5]/a[1]"));
                editButton.Click();
                Thread.Sleep(2000);
            }
            else
            {
                Assert.Fail("Record to be edited has not found, Record not edited");
            }

            // Edit the code
            IWebElement editCodeTextbox = driver.FindElement(By.Id("Code"));
            editCodeTextbox.Clear();
            editCodeTextbox.SendKeys(code);

            // Edit the Description
            IWebElement editDescriptionTextbox = driver.FindElement(By.Id("Description"));
            editDescriptionTextbox.Clear();
            editDescriptionTextbox.SendKeys(description);

            // Edit the Price field
            IWebElement priceTag1 = driver.FindElement(By.XPath("//*[@id='TimeMaterialEditForm']/div/div[4]/div/span[1]/span/input[1]"));
            IWebElement priceTextbox1 = driver.FindElement(By.XPath("//*[@id='Price']"));
            priceTag1.Click();
            priceTextbox1.Clear();
            priceTag1.Click();
            priceTextbox1.SendKeys(price);

            //Click save button
            IWebElement editSaveButton = driver.FindElement(By.Id("SaveButton"));
            editSaveButton.Click();
            //Wait.WaitToBeVisible(driver, "XPath", "//*[@id='tmsGrid']/div[3]/table/tbody/tr[1]/td[1]", 2);
            Thread.Sleep(3000);

            //Click on go to last page button
            goToLastPageButton = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[4]/a[4]/span"));
            goToLastPageButton.Click();
            Thread.Sleep(3000);           
        }

        public string GetEditedDescription(IWebDriver driver)
        {
            IWebElement createdDescription = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[3]"));
            return createdDescription.Text;
        }

        public string GetEditedCode(IWebDriver driver)
        {
            IWebElement createdCode = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[1]"));
            return createdCode.Text;
        }

        public string GetEditedPrice(IWebDriver driver)
        {
            IWebElement createdPrice = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[4]"));
            return createdPrice.Text;
        }

        //Delete time and material record
        public void DeleteTM(IWebDriver driver)
        {
            //Thread.Sleep(5000);
            Wait.WaitToBeVisible(driver, "XPath", "//*[@id='tmsGrid']/div[3]/table/tbody/tr[1]/td[1]", 2);
            goToLastPageButton = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[4]/a[4]/span"));
            goToLastPageButton.Click();
            //Delete time and material record
            //Click on delete button
            IWebElement findEditedRecord = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[1]"));

            if (findEditedRecord.Text == "Paddu")
            {
                IWebElement deleteButton = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[5]/a[2]"));
                deleteButton.Click();
                Thread.Sleep(5000);

                //Wait for the alert to be displayed
                //Store the alert in a variable
                IAlert alert = driver.SwitchTo().Alert();

                //Store the alert in a variable for reuse
                string text = alert.Text;

                //Press Ok button
                alert.Accept();
            }
            else
            {
                Assert.Fail("Record to be deleted has not been found, Record not deleted");
                Thread.Sleep(5000);
            }
            driver.Navigate().Refresh();
            Thread.Sleep(1000);

            goToLastPageButton = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[4]/a[4]/span"));
            goToLastPageButton.Click();
            Thread.Sleep(1000);

            IWebElement editedCode = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[1]"));
            IWebElement editedDescription = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[3]"));
            IWebElement editedPrice = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[4]"));

            // Assertion
            Assert.That(editedCode.Text != "Paddu", "Code record hasn't been deleted.");
            Assert.That(editedDescription.Text != "Nellipudi", "Description record hasn't been deleted.");
            Assert.That(editedPrice.Text != "$100.00", "Price record hasn't been deleted.");
        }        
    }
}
