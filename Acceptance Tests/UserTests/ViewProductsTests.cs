using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using wsep182.Domain;
using wsep182.services;

namespace Acceptance_Tests.UserTests
{
    [TestClass]
    public class ViewProductsTests
    {
        [TestInitialize]
        public void init()
        {
            ProductArchive.restartInstance();
            SalesArchive.restartInstance();
            storeArchive.restartInstance();
            UserArchive.restartInstance();
            UserCartsArchive.restartInstance();
            BuyHistoryArchive.restartInstance();
            CouponsArchive.restartInstance();
            DiscountsArchive.restartInstance();
            RaffleSalesArchive.restartInstance();
            StorePremissionsArchive.restartInstance();
        }

        [TestMethod]
        public void SimpleViewProductWithOneProduct()
        {
            userServices us = userServices.getInstance();
            User session = us.startSession();
            us.register(session, "zahi", "123456");
            us.login(session, "zahi", "123456");
            storeServices ss = storeServices.getInstance();
            ss.createStore("abowim", session);
            Store s = storeArchive.getInstance().getStore(1);
            int pis=ss.addProductInStore("cola", 3.2, 10, session, 1);
            LinkedList<ProductInStore> pisList = us.viewProductsInStore(1);
            LinkedList<ProductInStore> piStorsList = us.viewProductsInStores();
            Assert.AreEqual(pisList.Count, 1);
            Assert.AreEqual(piStorsList.Count, 1);
        }


        [TestMethod]
        public void ViewProductWhenThereIsNoProducts()
        {
            userServices us = userServices.getInstance();
            User session = us.startSession();
            us.register(session, "zahi", "123456");
            us.login(session, "zahi", "123456");
            storeServices ss = storeServices.getInstance();
            ss.createStore("abowim", session);
            Product p = new Product("cola");
            LinkedList<ProductInStore> pisList = us.viewProductsInStore(1);
            LinkedList<ProductInStore> piStorsList = us.viewProductsInStores();
            Assert.AreEqual(pisList.Count, 0);
            Assert.AreEqual(piStorsList.Count, 0);

        }

        [TestMethod]
        public void SimpleViewProductWithTwoProducts()
        {
            userServices us = userServices.getInstance();
            User session = us.startSession();
            us.register(session, "zahi", "123456");
            us.login(session, "zahi", "123456");
            storeServices ss = storeServices.getInstance();
            ss.createStore("abowim", session);
            ss.addProductInStore("cola", 3.2, 10, session, 1,"drinks");
            ss.addProductInStore("sprite", 3.2, 10, session, 1, "drinks");
            LinkedList<ProductInStore> pisList = us.viewProductsInStore(1);
            LinkedList<ProductInStore> piStorsList = us.viewProductsInStores();
            Assert.AreEqual(pisList.Count, 2);
            Assert.AreEqual(piStorsList.Count, 2);
        }

        [TestMethod]
        public void ViewProductInMultipleStores()
        {
            userServices us = userServices.getInstance();
            User session = us.startSession();
            us.register(session, "zahi", "123456");
            us.login(session, "zahi", "123456");
            User aviad = us.startSession();
            us.register(aviad, "aviad", "123456");
            us.login(aviad, "aviad", "123456");
            storeServices ss = storeServices.getInstance();
            ss.createStore("abowim", session);
            ss.createStore("bro's", aviad);
            ss.addProductInStore("cola", 3.2, 10, session, 1, "drinks");
            ss.addProductInStore("sprite", 3.2, 10, session, 1, "drinks");
            ss.addProductInStore("milk", 3.2, 10, aviad, 2, "milk");
            LinkedList<ProductInStore> pisList = us.viewProductsInStore(1);
            LinkedList<ProductInStore> pisList2 = us.viewProductsInStore(2);
            LinkedList<ProductInStore> piStorsList = us.viewProductsInStores();

            Assert.AreEqual(pisList.Count, 2);
            Assert.AreEqual(pisList2.Count, 1);
            Assert.AreEqual(piStorsList.Count, 3);
        }

    }
}
