using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;

namespace Selenium
{
    public class Tests
    {
        IWebDriver webDriver;
        ChromeOptions options;

        public interface objectBuilder
        {
            void BuildPartA();

            void BuildPartB();

            void BuildPartC();
        }
        public Tests()
        {
            
        }        
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

            //log in
            webDriver.FindElement(By.LinkText("Log in")).Click();
            Thread.Sleep(200);

            //send credentials
            webDriver.FindElement(By.Id("loginusername")).SendKeys(username);
            Thread.Sleep(200);
            webDriver.FindElement(By.Id("loginpassword")).SendKeys(password);
            Thread.Sleep(400);
            webDriver.FindElement(By.CssSelector("#logInModal .btn-primary")).Click();
            Thread.Sleep(500);
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
            //click laptops
            Thread.Sleep(500);
            IWebElement Laptops = webDriver.FindElement(By.LinkText("Laptops"));
            Thread.Sleep(100);
            Laptops.Click();
            Thread.Sleep(1000);

            //choosing laptop
            webDriver.FindElement(By.CssSelector("a[href *= 'prod.html?idp_=12']")).Click();
            Thread.Sleep(1000);

            //clicking add to cart button
            webDriver.FindElement(By.CssSelector(" .btn-success")).Click();

            //clicking ok on alert
            Thread.Sleep(500);
            webDriver.SwitchTo().Alert().Accept();

            //getting to cart list
            Thread.Sleep(1000);
            webDriver.FindElement(By.Id("cartur")).Click();
            Thread.Sleep(1000);

            //clicking on place order button
            webDriver.FindElement(By.CssSelector(" .btn-success")).Click();
            Thread.Sleep(200);

            //fill in place order form
            webDriver.FindElement(By.Id("name")).SendKeys("Ilya Obukhov");
            Thread.Sleep(100);
            webDriver.FindElement(By.Id("country")).SendKeys("Ukraine");
            Thread.Sleep(100);
            webDriver.FindElement(By.Id("city")).SendKeys("City");
            Thread.Sleep(100);
            webDriver.FindElement(By.Id("card")).SendKeys("1234541265789898");
            Thread.Sleep(100);
            webDriver.FindElement(By.Id("month")).SendKeys("April");
            Thread.Sleep(100);
            webDriver.FindElement(By.Id("year")).SendKeys("2022");
            Thread.Sleep(100);

            //accept button
            webDriver.FindElement(By.XPath("//button[contains(@onclick,'purchaseOrder')]")).Click();
            Thread.Sleep(1000);

            //checking if we have orderModal king of page object on screen
            Assert.IsTrue(webDriver.FindElements(By.Id("orderModal")).Count == 1);

            //quiting browser and shutting down web driver
        
        }

        [Test]
        public void Test2()
        {
            //click laptops
            Thread.Sleep(1000);
            webDriver.FindElement(By.LinkText("Monitors")).Click();
            Thread.Sleep(1000);

            //choosing laptop
            webDriver.FindElement(By.CssSelector("a[href *= 'prod.html?idp_=14']")).Click();
            Thread.Sleep(1000);

            //clicking add to cart button
            webDriver.FindElement(By.CssSelector(" .btn-success")).Click();
            Thread.Sleep(3000);

            //clicking ok on alert
            webDriver.SwitchTo().Alert().Accept();

            //getting to cart list
            Thread.Sleep(1000);
            webDriver.FindElement(By.Id("cartur")).Click();
            Thread.Sleep(1000);

            //clicking on place order button
            webDriver.FindElement(By.CssSelector(" .btn-success")).Click();
            Thread.Sleep(200);
            

            //fill in place order form
            webDriver.FindElement(By.Id("name")).SendKeys("Anto Kolisnik");
            Thread.Sleep(100);
            webDriver.FindElement(By.Id("country")).SendKeys("Ukraine");
            Thread.Sleep(100);
            webDriver.FindElement(By.Id("city")).SendKeys("City");
            Thread.Sleep(100);
            webDriver.FindElement(By.Id("card")).SendKeys("1234541265789898");
            Thread.Sleep(100);
            webDriver.FindElement(By.Id("month")).SendKeys("April");
            Thread.Sleep(100);
            webDriver.FindElement(By.Id("year")).SendKeys("2022");
            Thread.Sleep(100);

            //accept button
            webDriver.FindElement(By.XPath("//button[contains(@onclick,'purchaseOrder')]")).Click();
            Thread.Sleep(1000);

            //checking if we have orderModal king of page object on screen
            Assert.IsTrue(webDriver.FindElements(By.Id("orderModal")).Count == 1);

            

        }
    }
}