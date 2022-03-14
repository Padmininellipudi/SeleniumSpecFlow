using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumPOM.Pages;
using SeleniumPOM.Utilities;

namespace SeleniumPOM.Tests
{
    [TestFixture]
    [Parallelizable]
    internal class Employee_Tests : CommonDriver
    {
        [Test, Order(1), Description("Check if user is able to create employee record with valid data")]
        // Create Employee Record
        public void CreateEmp_Test()
            {
                // Home page object initialization and definition
                HomePage homePageObj = new HomePage();
                homePageObj.GoToEmployeePage(driver);
                // Employee page object initialization and definition
                EmployeePage employeePageObj = new EmployeePage(driver);
                employeePageObj.CreateEmployee(driver);
            }

        [Test, Order(2), Description("Check if user is able to edit a employee record with valid data")]
        // Edit Employee Record
        public void EditEmp_Test()
        {
            // Home page object initialization and definition
            HomePage homePageObj = new HomePage();
            homePageObj.GoToEmployeePage(driver);
            // Employee page object initialization and definition
            EmployeePage employeePageObj = new EmployeePage(driver);
            employeePageObj.EditEmployee(driver);
        }

        [Test, Order(3), Description("Check if user is able to edit a employee record with valid data")]
        // Delete Employee Record
        public void DeleteEmp_Test()
        {
            // Home page object initialization and definition
            HomePage homePageObj = new HomePage();
            homePageObj.GoToEmployeePage(driver);
            // Employee page object initialization and definition
            EmployeePage employeePageObj = new EmployeePage(driver);
            employeePageObj.DeleteEmployee(driver);
        }

    }
}
