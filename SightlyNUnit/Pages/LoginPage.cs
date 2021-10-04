using OpenQA.Selenium;


namespace SightlyNUnit.Pages
{
    class LoginPage : DriverHelper
    {
        #region PageObjects

        // Email Address TextBox
        IWebElement txtUserName => Driver.FindElement(By.CssSelector("input[placeholder='Your email address']"));

        // Password TextBox
        IWebElement txtPassword => Driver.FindElement(By.CssSelector("input[placeholder='Your password']"));

        // Login Button
        IWebElement btnLogin => Driver.FindElement(By.CssSelector("button[class='login-button']"));

        #endregion PageObjects

        #region InputMethods

        // Enter UserName
        public void EnterUserName(string userName) => txtUserName.SendKeys(userName);

        // Enter Password
        public void EnterPassword(string password) => txtPassword.SendKeys(password);

        // Click Login Button
        public void ClickLogin() => btnLogin.Click();

        #endregion InputMethods
    }
}
