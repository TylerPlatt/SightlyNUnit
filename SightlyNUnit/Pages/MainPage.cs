using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;


namespace SightlyNUnit.Pages
{
    class MainPage : DriverHelper
    {
        #region HelperMethods

        // Method to Get Checkbox By Row
        private IWebElement GetCheckBox(int row)
        {
            // Get Array of CheckBox Elements
            var chkBoxes = Driver.FindElements(By.CssSelector("input[type='checkbox']"));
            // Get Second Checkbox
            IWebElement chkBox = chkBoxes[row];
            // Return Element
            return chkBox;
        }

        // Method to Get Select Element
        private SelectElement GetSelectElement(IWebElement webElement)
        {
            SelectElement selectElement = new SelectElement(webElement);
            return selectElement;
        }

        #endregion HelperMethods

        #region PageObjects

        // Reports Button
        IWebElement btnReports => Driver.FindElement(By.CssSelector("div[id='header-reports']"));

        // Get CheckBox on Second Row
 
        IWebElement chkSecond => GetCheckBox(2);

        // "Create Report" Button
        IWebElement btnCreateReport => Driver.FindElement(By.CssSelector("button[class='create-report']"));

        // Performance Detail Report Radio Button
        IWebElement rdoDetailReport => Driver.FindElement(By.CssSelector("input[value='performanceDetail']"));

        // "Grouping" Select
        SelectElement selectGrouping => GetSelectElement(Driver.FindElement(By.XPath("//select[contains(@class, 'groupingSelect')]")));
        
        // "Cost Basis" Select 
        SelectElement selectCostBasis => GetSelectElement(Driver.FindElement(By.XPath("//select[contains(@class, 'costBasisSelect')]")));
        
        // Granularity" Select
        SelectElement selectGranularity => GetSelectElement(Driver.FindElement(By.XPath("//select[contains(@class, 'granularitySelect')]")));
        
        // "Additional Columns" Select
        SelectElement selectAddCols => GetSelectElement(Driver.FindElement(By.XPath("//select[contains(@class, 'addColSelect')]")));
        
        // "Time Period" Select
        SelectElement selectTimePeriod => GetSelectElement(Driver.FindElement(By.XPath("//select[contains(@class, 'timePeriodSelect')]")));

        // "Run Reports" Button
        IWebElement btnRunReports => Driver.FindElement(By.CssSelector("button[class='run-report-button"));

        #endregion PageObjects

        #region InputMethods

        // Click Reports Button
        public void ClickReports() => btnReports.Click();

        // Click Second Checkbox
        public void ClickSecondBox() => chkSecond.Click();

        // Click "Create Report" Button
        public void ClickCreateReport() => btnCreateReport.Click();

        // Click "Performance Detail Report" Radio Button
        public void ClickRdoPerformanceBtn() => rdoDetailReport.Click(); 

        // Select Campaign 
        public void SelectCampaign() => selectGrouping.SelectByText("Campaign");
        // Select All
        public void SelectAll() => selectCostBasis.SelectByText("All");
        // Select Summary
        public void SelectSummary() => selectGranularity.SelectByText("Summary");
        // Select None
        public void SelectNone() => selectAddCols.SelectByText("None");
        // Select All Time
        public void SelectAllTime() => selectTimePeriod.SelectByText("All Time");

        // Click "Run Reports" Button
        public void ClickRunReportsBtn() => btnRunReports.Click();

        #endregion InputMethods

    }
}
