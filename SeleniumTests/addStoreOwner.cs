﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;
using wsep182.services;

namespace SeleniumTests
{
    [TestClass]
    public class addStoreOwner
    {
        public static String URL = "http://localhost:53416/";
        IWebDriver driver = new ChromeDriver("./");
        private int sleepTime = 500;
        [TestInitialize]
        public void Initialize()
        {
            userServices.getInstance().init();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(URL);
            Console.WriteLine("Opened URL");
            IWebElement register = driver.FindElement(By.Id("RegisterLink"));
            register.Click();
            Thread.Sleep(sleepTime);
            IWebElement userName = driver.FindElement(By.Id("username"));
            userName.SendKeys("zahiSimpleRegister");
            Thread.Sleep(sleepTime);
            IWebElement password1 = driver.FindElement(By.Id("password1"));
            password1.SendKeys("123456");
            Thread.Sleep(sleepTime);
            IWebElement password2 = driver.FindElement(By.Id("password2"));
            password2.SendKeys("123456");
            Thread.Sleep(sleepTime);
            IWebElement btnRegister = driver.FindElement(By.Id("btnRegister"));
            btnRegister.Click();
            Thread.Sleep(sleepTime);
            IAlert alert = driver.SwitchTo().Alert();
            alert.Accept();
            Thread.Sleep(sleepTime);
            IWebElement login = driver.FindElement(By.Id("LoginLink"));
            login.Click();
            Thread.Sleep(sleepTime);
            userName = driver.FindElement(By.Id("username"));
            userName.SendKeys("zahiSimpleRegister");
            Thread.Sleep(sleepTime);
            IWebElement password = driver.FindElement(By.Id("password"));
            password.SendKeys("123456");
            Thread.Sleep(sleepTime);
            IWebElement btnLogin = driver.FindElement(By.Id("btnLogin"));
            btnLogin.Click();
            Thread.Sleep(sleepTime);
            IWebElement MystoreBtn = driver.FindElement(By.Id("MyStoresPublicLink"));
            MystoreBtn.Click();
            Thread.Sleep(sleepTime);
            IWebElement newStoreInput = driver.FindElement(By.Id("storeName"));
            newStoreInput.SendKeys("abowStore");
            Thread.Sleep(sleepTime);
            IWebElement crateStoreBtn = driver.FindElement(By.Id("createStoreButton12"));
            crateStoreBtn.Click();
            Thread.Sleep(sleepTime);
            alert = driver.SwitchTo().Alert();
            alert.Accept();
            Thread.Sleep(sleepTime);

        }
        [TestMethod]
        public void simpleAddMannegers()
        {
            IWebElement addStoreOwnerBtn = driver.FindElement(By.Id("addStoreOwner0"));
            addStoreOwnerBtn.Click();
            Thread.Sleep(sleepTime);
            IWebElement OwnerName = driver.FindElement(By.Id("new-owner-name"));
            OwnerName.SendKeys("admin");
            Thread.Sleep(sleepTime);

            IWebElement AddOwner = driver.FindElement(By.Id("AddOwnerBtn"));
            AddOwner.Click();
            Thread.Sleep(sleepTime);

            IAlert alert = driver.SwitchTo().Alert();
            string alertText = alert.Text;
            Assert.IsTrue(alertText.Contains("the User admin has been added as owner sussesfuly"));
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