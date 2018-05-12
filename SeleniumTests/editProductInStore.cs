using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;
using wsep182.services;

namespace SeleniumTests
{
    [TestClass]
    public class editProductInStore
    {
        [TestClass]
        public class AddProductToStore
        {
            public static String URL = "http://localhost:53416/";
            IWebDriver driver = new ChromeDriver("./");
            private int sleepTime = 500;
            [TestInitialize]
            public void Initialize()
            {
                driver.Manage().Window.Maximize();
                driver.Navigate().GoToUrl(URL);
                Console.WriteLine("Opened URL");


                IWebElement login = driver.FindElement(By.Id("LoginLink"));
                login.Click();
                Thread.Sleep(sleepTime);
                IWebElement userName = driver.FindElement(By.Id("username"));
                userName.SendKeys("admin");
                Thread.Sleep(sleepTime);
                IWebElement password = driver.FindElement(By.Id("password"));
                password.SendKeys("123456");
                Thread.Sleep(sleepTime);
                IWebElement btnLogin = driver.FindElement(By.Id("btnLogin"));
                btnLogin.Click();
                Thread.Sleep(sleepTime);

            }
            [TestMethod]
            public void editProduct()
            {
                IWebElement MystoreBtn = driver.FindElement(By.Id("MyStoresPublicLink"));
                MystoreBtn.Click();
                Thread.Sleep(sleepTime);
                IWebElement editProductInStoreBtn = driver.FindElement(By.Id("editProductInStore0"));
                editProductInStoreBtn.Click();
                Thread.Sleep(sleepTime);
                IWebElement pisId = driver.FindElement(By.Id("product-id2"));
                pisId.SendKeys("1");
                Thread.Sleep(sleepTime);
                IWebElement price = driver.FindElement(By.Id("product-price2"));
                price.SendKeys("12");
                Thread.Sleep(sleepTime);
                IWebElement amount = driver.FindElement(By.Id("product-amount2"));
                amount.SendKeys("12");
                Thread.Sleep(sleepTime);
                IWebElement editPro = driver.FindElement(By.Id("aviad-Edit-product"));
                editPro.Click();
                Thread.Sleep(sleepTime);
                
                IAlert alert = driver.SwitchTo().Alert();
                string alertText = alert.Text;
                Assert.IsTrue(alertText.Contains("product edited successfuly"));
                alert.Accept();
            }
            [TestCleanup]
            public void CleanUp()
            {
                driver.Close();
                Console.WriteLine("Closed the browser");
            }
        }
    }
}
