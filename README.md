# SightlyNUnit
Sightly QA Automation Exercise - Selenium / C# NUnit .NET Core Solution

This is a C# NUnit .NET Core solution.


Packages used are: ExcelDataReader, ExcelDataReader.DataSet, JsonDiffPatch.Net, Microsoft.NET.Test.Sdk, Newtonsoft.Json, NUnit, NUnit3TestAdapter, Selenium.Support, Selenium.WebDriver, System.Text.Encoding.CodePackages


I downloaded the second row data, not the first - the first row wasn't producing data for me. Currently this downloads the "Bart Durham Injury Law Non-Skippable" file.

I used a page object model to define page objects and actions - one page for the Login screen (LoginPage.cs) and one for the Main page (MainPage.cs). The webdriver is stored in the DriverHelper.cs class and data validation is done with the DataValidation.cs class.

The UnitTest1.cs file is where the test is executed. There is just one Test and one assertion at the end of the test, telling whether the data was valid or not. If the data does not match, the debug console will show output of the mismatched Json data. 

For data validation, I convert the downloaded Excel download to Json data and validate against a Json file on my computer. I double check by comparing against both a Json string and a Json object.

The validation file (Sightly.json) is included in the solution, but the code is looking for this Json file on the disk, not the one in the solution. This will work if you change the file path in line 61 of the DataValidation.cs class to a location on your hard drive where you've saved a file named Sightly.json, using the Json included in the solution. Similarly, line 26 points to my Chrome downloads directory. The most recent file in the directory is always used. Line 19 of UnitTest1.cs points to the location of the chromedriver file.

I buffered the input after the login page using Thread.Sleep to wait for the main page to load. I avoided using webdriverwait methods because they didn't account for the object being active in the dom but not clickable due to an overlaying element still showing.

I used Actions to tab over and press enter on the "Run Reports" button in the final step because the button wasn't displaying on my screen. There's an alternate method commented out that targets the element.

To download the wrong report and cause a failure, you can change line 38 of MainPage.cs to a from a 2 to a 3 to check the next checkbox down. Cheers!


