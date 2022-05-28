using OpenQA.Selenium;
using System.Threading;

namespace Selenium
{
    //page object only for logining in. LoginForm class
    public class LoginForm
    {
        private readonly By LoginMenu = By.LinkText("Log in");
        private readonly By UsernameField = By.Id("loginusername");
        private readonly By PasswordField = By.Id("loginpassword");
        private readonly By LoginButton = By.CssSelector("#logInModal .btn-primary");

        private readonly IWebDriver WebDriver;

        public LoginForm(IWebDriver driver)
        {
            WebDriver = driver;
        }
        public void GoToLogin()
        {
            WebDriver.FindElement(LoginMenu).Click();
        }
        public LoginForm EnterUsername(string username)
        {
            WebDriver.FindElement(UsernameField).SendKeys(username);
            return this;
        }
        public LoginForm EnterPassword(string password)
        {
            WebDriver.FindElement(PasswordField).SendKeys(password);
            return this;
        }
        public LoginForm SumbitLogin()
        {
            WebDriver.FindElement(LoginButton).Click();
            return new LoginForm(WebDriver);
        }
        public LoginForm Login(string username, string password)
        {
            GoToLogin();
            Thread.Sleep(200);
            EnterUsername(username);
            Thread.Sleep(200);
            EnterPassword(password);
            Thread.Sleep(200);
            return SumbitLogin();
        }
    }
}
