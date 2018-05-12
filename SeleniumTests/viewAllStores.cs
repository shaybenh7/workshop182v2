using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;

namespace SeleniumTests
{
    [TestClass]
    public class viewAllStores
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
        }

        [TestMethod]
        public void GUIviewAllStores()
        {
            IWebElement fillDB = driver.FindElement(By.Id("fillDB"));
            fillDB.Click();
            Thread.Sleep(sleepTime);
            IWebElement AllProducts = driver.FindElement(By.Id("AllStoresLink"));
            AllProducts.Click();
            Thread.Sleep(sleepTime);
            IWebElement store0 = driver.FindElement(By.Id("storeName0"));
            Assert.IsTrue(store0.Text.Equals("Store Name: Maria&Netta Inc."));
            IWebElement storeCreator = driver.FindElement(By.Id("ownerName0"));
            Assert.IsTrue(storeCreator.Text.Equals("Store Creator: zahi"));
        }
        [TestMethod]
        public void GUIviewAllStoresAndGetInTheStore()
        {
            IWebElement fillDB = driver.FindElement(By.Id("fillDB"));
            fillDB.Click();
            Thread.Sleep(sleepTime);
            IWebElement AllProducts = driver.FindElement(By.Id("AllStoresLink"));
            AllProducts.Click();
            Thread.Sleep(sleepTime);
            IWebElement store0 = driver.FindElement(By.Id("storeName0"));
            store0.Click();
            Thread.Sleep(sleepTime);
            IWebElement storeName = driver.FindElement(By.Id("store-name"));
            Assert.IsTrue(storeName.Text.Contains("Maria&Netta Inc."));
            IWebElement owner = driver.FindElement(By.Id("owners"));
            Assert.IsTrue(owner.Text.Contains("zahi"));
            IWebElement manager = driver.FindElement(By.Id("managers"));
            Assert.IsTrue(manager.Text.Contains("niv"));
            IWebElement product0 = driver.FindElement(By.Id("productName0"));
            Assert.IsTrue(product0.Text.Contains("cola"));
            IWebElement product1 = driver.FindElement(By.Id("productName1"));
            Assert.IsTrue(product1.Text.Contains("cola"));
        }
    }
}
