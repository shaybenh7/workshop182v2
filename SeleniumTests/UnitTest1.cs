using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;

namespace SeleniumTests
{
    [TestClass]
    public class UnitTest1
    {
        public static String URL = "http://localhost:53416/";
        IWebDriver driver = new ChromeDriver("./");

        [TestInitialize]
        public void Initialize()
        {
            //Navigate to Execute automation demo page
            driver.Navigate().GoToUrl(URL);
            Console.WriteLine("Opened URL");
        }


        [TestMethod]
        public void GUIaddProductToCart()
        {
            //Console.WriteLine("before element");
            //Find the Element
            IWebElement fillDB = driver.FindElement(By.Id("fillDB"));
            fillDB.Click();
            IWebElement AllProducts = driver.FindElement(By.Id("AllProductsLink"));
            AllProducts.Click();
            IWebElement sale1 = driver.FindElement(By.Id("viewSale0"));
            sale1.Click();

            //Actions actions = new Actions(driver);
            //actions.MoveToElement(sale1).Click().Perform();
            IWebElement submitViewInstantSale = driver.FindElement(By.Id("submit"));
            submitViewInstantSale.Click();
            IWebElement shoppingCartIcon = driver.FindElement(By.Id("shoppingCartIcon"));
            shoppingCartIcon.Click();
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
