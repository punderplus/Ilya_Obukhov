using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;
using SeleniumExtras.WaitHelpers;

namespace Selenium
{
    class TestController
    {
        private readonly By laptops = By.LinkText("Laptops");
        private readonly By ParticularLaptop = By.CssSelector("a[href *= 'prod.html?idp_=12']");
        private readonly By cartButton = By.CssSelector(" .btn-success");
        private readonly By cartList = By.Id("cartur");
        private readonly By placeOrderButton = By.CssSelector(" .btn-success");

        private readonly By name = By.Id("name");
        private readonly By country = By.Id("country");
        private readonly By city = By.Id("city");
        private readonly By card = By.Id("card");
        private readonly By month = By.Id("month");
        private readonly By year = By.Id("year");

        private readonly By accessButton = By.XPath("//button[contains(@onclick,'purchaseOrder')]");

        private readonly IWebDriver webDriver;

        public TestController(IWebDriver driver)
        {
            webDriver = driver;
        }
        private void GoToLaptops()
        {
            webDriver.FindElement(laptops).Click();
        }
        private void GoToParticularLaptop()
        {
            webDriver.FindElement(ParticularLaptop).Click();
        }
        private void AddToCart()
        {
            webDriver.FindElement(cartButton).Click();
        }
        private void AcceptAlert()
        {
            webDriver.SwitchTo().Alert().Accept();
        }
        private void GoToCartList()
        {
            webDriver.FindElement(cartList).Click();
        }
        private void GoToPlaceOrder()
        {
            webDriver.FindElement(placeOrderButton).Click();
        }

        private TestController EnterName(string name_i)
        {
            webDriver.FindElement(name).SendKeys(name_i);
            return this;
        }
        private TestController EnterCountry(string country_i)
        {
            webDriver.FindElement(country).SendKeys(country_i);
            return this;
        }
        private TestController EnterCity(string city_i)
        {
            webDriver.FindElement(city).SendKeys(city_i);
            return this;
        }
        private TestController EnterCard(string card_i)
        {
            webDriver.FindElement(card).SendKeys(card_i);
            return this;
        }
        private TestController EnterMonth(string month_i)
        {
            webDriver.FindElement(month).SendKeys(month_i);
            return this;
        }
        private TestController EnterYear(string year_i)
        {
            webDriver.FindElement(year).SendKeys(year_i);
            return this;
        }

        private TestController SubmitPurchase()
        {
            webDriver.FindElement(accessButton).Click();
            return new TestController(webDriver);
        }
        private void ObjectController(IWebDriver driver)
        {

        }

        public TestController PurchaseLaptop(string name_i, string country_i, string city_i, string card_i, string month_i, string year_i)
        {
            //click laptops
            GoToLaptops();
            Thread.Sleep(1000);
            //choosing laptop
            GoToParticularLaptop();
            Thread.Sleep(1000);
            //clicking add to cart button
            AddToCart();
            Thread.Sleep(1000);
            //clicking ok on alert
            AcceptAlert();
            Thread.Sleep(1000);
            //getting to cart list
            GoToCartList();
            Thread.Sleep(1000);
            //clicking on place order button
            GoToPlaceOrder();
            Thread.Sleep(1000);
            //fill in place order form
            EnterName(name_i);
            EnterCountry(country_i);
            EnterCity(city_i);
            EnterCard(card_i);
            EnterMonth(month_i);
            EnterYear(year_i);
            //submitting
            return SubmitPurchase();
        }
    }
}
