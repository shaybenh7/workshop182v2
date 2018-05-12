using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System.Windows.Forms;
using System.Threading;

namespace SeleniumTests
{
    [TestClass]
    public class UnitTest1
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
        public void GUIaddProductToCart()
        {
            IWebElement fillDB = driver.FindElement(By.Id("fillDB"));
            fillDB.Click();
            Thread.Sleep(sleepTime);
            IWebElement AllProducts = driver.FindElement(By.Id("AllProductsLink"));
            AllProducts.Click();
            Thread.Sleep(sleepTime);
            IWebElement sale1 = driver.FindElement(By.Id("viewSale0"));
            sale1.Click();
            Thread.Sleep(sleepTime);
            IWebElement submitViewInstantSale = driver.FindElement(By.Id("submit"));
            submitViewInstantSale.Click();
            Thread.Sleep(sleepTime);
            IAlert alert = driver.SwitchTo().Alert();
            string alertText = alert.Text;
            Assert.IsTrue(alertText.Contains("Product was added successfully!"));
            alert.Accept();
            Thread.Sleep(sleepTime);
            IWebElement shoppingCartIcon = driver.FindElement(By.Id("shoppingCartIcon"));
            shoppingCartIcon.Click();
            Thread.Sleep(sleepTime);
            IWebElement productInCart = driver.FindElement(By.Id("productName0"));
            Assert.IsTrue(productInCart.Text.Equals("cola"));
        }

        [TestMethod]
        public void NextTest()
        {
            Console.WriteLine("Next method");
        }

        [TestCleanup]
        public void CleanUp()
        {
            driver.Close();
            Console.WriteLine("Closed the browser");
        }
    }
}
