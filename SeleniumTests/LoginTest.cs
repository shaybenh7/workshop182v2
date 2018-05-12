﻿using System;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SeleniumTests
{
    [TestClass]
    public class LoginTest
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
        public void loginSimple()
        {
            IWebElement login = driver.FindElement(By.Id("LoginLink"));
            login.Click();
            Thread.Sleep(sleepTime);
            IWebElement userName = driver.FindElement(By.Id("username"));
            userName.SendKeys("zahi");
            Thread.Sleep(sleepTime);
            IWebElement password = driver.FindElement(By.Id("password"));
            password.SendKeys("123456");
            Thread.Sleep(sleepTime);
            IWebElement btnLogin = driver.FindElement(By.Id("btnLogin"));
            btnLogin.Click();
            Thread.Sleep(sleepTime);

            IWebElement welcome = driver.FindElement(By.Id("welcome"));
            String welcomeText = welcome.Text;
            Assert.IsTrue(welcomeText.Contains("Welcome zahi"));
        }
        [TestMethod]
        public void loginNotExist()
        {
            IWebElement login = driver.FindElement(By.Id("LoginLink"));
            login.Click();
            Thread.Sleep(sleepTime);
            IWebElement userName = driver.FindElement(By.Id("username"));
            userName.SendKeys("itamarr");
            Thread.Sleep(sleepTime);
            IWebElement password = driver.FindElement(By.Id("password"));
            password.SendKeys("123456");
            Thread.Sleep(sleepTime);
            IWebElement btnLogin = driver.FindElement(By.Id("btnLogin"));
            btnLogin.Click();
            Thread.Sleep(sleepTime);
            IWebElement loginAlert = driver.FindElement(By.Id("loginAlert"));
            Assert.IsTrue(loginAlert.Text.Contains("Failure - error: username not exist"));    
        }
        [TestMethod]
        public void loginWrongPaswword()
        {
            IWebElement login = driver.FindElement(By.Id("LoginLink"));
            login.Click();
            Thread.Sleep(sleepTime);
            IWebElement userName = driver.FindElement(By.Id("username"));
            userName.SendKeys("itamar");
            Thread.Sleep(sleepTime);
            IWebElement password = driver.FindElement(By.Id("password"));
            password.SendKeys("1234567");
            Thread.Sleep(sleepTime);
            IWebElement btnLogin = driver.FindElement(By.Id("btnLogin"));
            btnLogin.Click();
            Thread.Sleep(sleepTime);
            IWebElement loginAlert = driver.FindElement(By.Id("loginAlert"));
            Assert.IsTrue(loginAlert.Text.Contains("Failure - error: wrong password"));
        }
        [TestMethod]
        public void loginEmptyName()
        {
            IWebElement login = driver.FindElement(By.Id("LoginLink"));
            login.Click();
            Thread.Sleep(sleepTime);
            IWebElement password = driver.FindElement(By.Id("password"));
            password.SendKeys("123456");
            Thread.Sleep(sleepTime);
            IWebElement btnLogin = driver.FindElement(By.Id("btnLogin"));
            btnLogin.Click();
            Thread.Sleep(sleepTime);
            IWebElement loginAlert = driver.FindElement(By.Id("loginAlert"));
            Assert.IsTrue(loginAlert.Text.Contains("Failure - error: username not exist"));
        }
        [TestMethod]
        public void loginEmptyPaswword()
        {
            IWebElement login = driver.FindElement(By.Id("LoginLink"));
            login.Click();
            Thread.Sleep(sleepTime);
            IWebElement userName = driver.FindElement(By.Id("username"));
            userName.SendKeys("itamar");
            Thread.Sleep(sleepTime);
            IWebElement btnLogin = driver.FindElement(By.Id("btnLogin"));
            btnLogin.Click();
            Thread.Sleep(sleepTime);
            IWebElement loginAlert = driver.FindElement(By.Id("loginAlert"));
            Assert.IsTrue(loginAlert.Text.Contains("Failure - error: wrong password"));
        }
        [TestCleanup]
        public void CleanUp()
        {
            driver.Close();
            Console.WriteLine("Closed the browser");
        }
    }
}