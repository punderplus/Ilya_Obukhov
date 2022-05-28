using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;
using OpenQA.Selenium.Support.UI;
using System;

namespace Selenium
{
    //class to work with log in form
    public class Tests
    {
        IWebDriver webDriver;
        ChromeOptions options;
     
        [SetUp]
        public void Setup()
        {
            options = new ChromeOptions();
            options.AddArgument("--start-maximized");
            webDriver = new ChromeDriver(options);
            //user credentials
            const string username = "punderplus";
            const string password = "ilia200210";
            //go to site
            webDriver.Navigate().GoToUrl("https://www.demoblaze.com");
            //do logining in
            LoginForm lf = new LoginForm(webDriver);
            lf.Login(username, password);
            Thread.Sleep(1000);

        }

        [TearDown]
        public void TearDown()
        {
            //quiting browser and shutting down web driver
            webDriver.Quit();
        }

        [Test]
        
        public void LaptopTest()
        {
            TestController Ts = new TestController(webDriver);
            Ts.PurchaseLaptop("Ilya Obukhov", "Ukraine", "City", "1234541265789898", "April", "2022");
            //checking if we have orderModal king of page object on screen
            Assert.IsTrue(webDriver.FindElements(By.Id("orderModal")).Count == 1);
        }
    }
}