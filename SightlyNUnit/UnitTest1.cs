using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using SightlyNUnit.Pages;
using System;
using System.Diagnostics;
using System.Threading;


namespace SightlyNUnit
{
    public class Tests : DriverHelper
    {

        [SetUp]
        public void Setup()
        {
            Driver = new ChromeDriver(@"C:\Program Files (x86)\Google\Chrome\Application");
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1000);
        }

        [Test]
        public void Test1()
        {
            // Open Browswer and Navigate to Login Page
            Driver.Navigate().GoToUrl("https://staging-newtargetview.sightly.com/");

            // Create Instances of Page Objects
            LoginPage loginPage = new LoginPage();
            MainPage mainPage = new MainPage();

            #region LoginPage
            // Enter Login Information
            loginPage.EnterUserName("nick@sightly.com");

            // Enter Password
            loginPage.EnterPassword("a");

            // Click Login Button
            loginPage.ClickLogin();

            #endregion LoginPage

            #region MainPage

            // Buffer Page Loading
            Thread.Sleep(10000);

            // Click Reports Button
            mainPage.ClickReports();

            // Click Second Checkbox
            mainPage.ClickSecondBox();

            // Click "Create Report" Button
            mainPage.ClickCreateReport();

            // Click "Performance Detail Report" Radio Button
            mainPage.ClickRdoPerformanceBtn();

            // Select Grouping SelectBox Option
            mainPage.SelectCampaign();

            // Select"Cost Basis"
            mainPage.SelectAll();

            // Select Granularity SelectBox Option
            mainPage.SelectSummary();

            // Select "Additional Columns" SelectBox Option
            mainPage.SelectNone();

            // Select "Time Period" SelectBox Option
            mainPage.SelectAllTime();

            // Click "Run Reports" Button
            //mainPage.ClickRunReportsBtn();

            // Pause to buffer inputs
            Thread.Sleep(500);

            // Tab over to "Run Reports" Button and press Enter to run Report (button is unclickable on my screen)
            // Alternately mainPage.ClickRunReportsBtn();

            Actions action = new Actions(Driver);
            action.SendKeys(Keys.Tab).SendKeys(Keys.Return).Build().Perform();
            Thread.Sleep(1000);

            // Close the browser
            Driver.Close();

            #endregion MainPage

            #region DataValidation

            // Initialize Data Validation Class
            DataValidation dataValidator = new DataValidation();

            // Initialize Data Validation Variable
            bool isDataValid = dataValidator.ValidateData();

            // Print Data Validation Result to Console
            string result = (isDataValid == true) ? "Data Validation Passed" : "Data Validation Failed";
            Debug.WriteLine(result);

            // Test Assertion 
            Assert.That(isDataValid, Is.True, "Data Validation Failed - See Debug Output for JSON Differences");

            #endregion DataValidation
        }

    }
}