using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using wsep182.Domain;


namespace IntegrationTests
{
    [TestClass]
    public class StoreRoleTest
    {
        private User zahi;  // owner of store
        private User aviad; //manager of store
        private User shay;
        private User itamar; // not a real user
        private User niv; // guest
        private Store store;
        StoreRole zahiOwner;
        StoreRole aviadManeger;
        ProductInStore cola;

        [TestInitialize]
        public void init()
        {
            ProductArchive.restartInstance();
            SalesArchive.restartInstance();
            storeArchive.restartInstance();
            UserArchive.restartInstance();
            UserCartsArchive.restartInstance();
            StorePremissionsArchive.restartInstance();

            BuyHistoryArchive.restartInstance();
            CouponsArchive.restartInstance();
            DiscountsArchive.restartInstance();
            RaffleSalesArchive.restartInstance();
            StorePremissionsArchive.restartInstance();
            zahi = new User("zahi", "123456");
            zahi.register("zahi", "123456");
            zahi.login("zahi", "123456");
            aviad = new User("aviad", "123456");
            aviad.register("aviad", "123456");
            aviad.login("aviad", "123456");
            shay = new User("shay", "123456");
            shay.register("shay", "123456");
            shay.login("shay", "123456");
            itamar = new User("itamar", "123456");
            niv = new User("niv", "123456");
            niv.register("niv", "123456");
            int storeId = zahi.createStore("abowim");
            store = storeArchive.getInstance().getStore(storeId);
            zahiOwner = new StoreOwner(zahi, store);
            aviadManeger = new StoreManager(aviad, store);
            zahiOwner.addStoreManager(zahi, store, "aviad");
            niv.logOut();
            int colaId = zahiOwner.addProductInStore(zahi, store, "cola", 3.2, 10, "Drinks");
            cola = ProductArchive.getInstance().getProductInStore(colaId);
        }

        [TestMethod]
        public void editProductInStoreWithManagerPermission()
        {
            int pisId = zahiOwner.addProductInStore(zahi, store, "cola2", 10, 4, "Drinks");
            ProductInStore pis= ProductArchive.getInstance().getProductInStore(pisId);
            Assert.AreEqual(2, store.getProductsInStore().Count);
            aviadManeger.editProductInStore(aviad, pis, 13, 4.5);
            Assert.AreEqual(10, pis.getPrice());
            Assert.AreEqual(4, pis.getAmount());
            zahiOwner.addManagerPermission(zahi, "editProductInStore", store, "aviad");
            aviadManeger.editProductInStore(aviad, pis, 13, 4.5);
            Assert.AreEqual(4.5, pis.getPrice());
            Assert.AreEqual(13, pis.getAmount());
        }
        [TestMethod]
        public void editProductInStoreWithoutManagerPermission()
        {
            int pisId = zahiOwner.addProductInStore(zahi, store, "cola2", 10, 4, "Drinks");
            ProductInStore pis = ProductArchive.getInstance().getProductInStore(pisId);
            Assert.AreEqual(2, store.getProductsInStore().Count);
            aviadManeger.editProductInStore(aviad, pis, 13, 4.5);
            Assert.AreEqual(10, pis.getPrice());
            Assert.AreEqual(4, pis.getAmount());
            zahiOwner.addManagerPermission(zahi, "addSaleToStore", store, "aviad");
            aviadManeger.editProductInStore(aviad, pis, 13, 4.5);
            Assert.AreEqual(10, pis.getPrice());
            Assert.AreEqual(4, pis.getAmount());
        }
        [TestMethod]
        public void SimpleAddSaleeWithManagerPermission()
        {
            zahiOwner.addManagerPermission(zahi, "addSaleToStore", store, "aviad");
            Assert.IsTrue(aviadManeger.addSaleToStore(aviad, store, cola.getProductInStoreId(), 1, 1, DateTime.Now.AddMonths(1).ToString()) > -1);
            Assert.AreEqual(store.getAllSales().Count, 1);
        }
        [TestMethod]
        public void SimpleAddSaleeWithoutManagerPermission()
        {
            zahiOwner.addManagerPermission(zahi, "editProductInStore", store, "aviad");
            Assert.IsFalse(aviadManeger.addSaleToStore(aviad, store, cola.getProductInStoreId(), 1, 1, DateTime.Now.AddMonths(1).ToString()) > -1);
            Assert.AreEqual(store.getAllSales().Count, 0);
        }
        [TestMethod]
        public void SimpleAddSaleeWithManagerPermissionNotGoodProduct()
        {
            zahiOwner.addManagerPermission(zahi, "addSaleToStore", store, "aviad");
            Assert.IsFalse(aviadManeger.addSaleToStore(aviad, store, cola.getProductInStoreId(), -3, 1, DateTime.Now.AddMonths(1).ToString()) > -1);
            Assert.AreEqual(store.getAllSales().Count, 0);
        }
        [TestMethod]
        public void SimpleAddSaleeWithOwner()
        {
            Assert.IsTrue(zahiOwner.addSaleToStore(zahi, store, cola.getProductInStoreId(), 1, 1, DateTime.Now.AddMonths(1).ToString()) > -1);
            Assert.AreEqual(store.getAllSales().Count, 1);
        }
        [TestMethod]
        public void SimpleAddSaleeWithOwnerTwice()
        {
            Assert.IsTrue(zahiOwner.addSaleToStore(zahi, store, cola.getProductInStoreId(), 1, 1, DateTime.Now.AddMonths(1).ToString()) > -1);
            Assert.IsTrue(zahiOwner.addSaleToStore(zahi, store, cola.getProductInStoreId(), 1, 1, DateTime.Now.AddMonths(1).ToString()) > -1);
            Assert.AreEqual(store.getAllSales().Count, 1);
        }
        [TestMethod]
        public void SimpleAddRaffleSaleWithOwner()
        {
            Assert.IsTrue(zahiOwner.addSaleToStore(zahi, store, cola.getProductInStoreId(), 3, 1, DateTime.Now.AddMonths(1).ToString()) > -1);
        }
        [TestMethod]
        public void AddRaffleSaleWithOwnerWrongAmount()
        {
            Assert.IsTrue(zahiOwner.addSaleToStore(zahi, store, cola.getProductInStoreId(), 3, 2, DateTime.Now.AddMonths(1).ToString()) > -1);
            Assert.IsFalse(zahiOwner.addSaleToStore(zahi, store, cola.getProductInStoreId(), 3, -2, DateTime.Now.AddMonths(1).ToString()) > -1);
        }
        [TestMethod]
        public void RaffleSaleWithMannegerwithoutPremition()
        {
            Assert.IsFalse(aviadManeger.addSaleToStore(aviad, store, cola.getProductInStoreId(), 3, 1, DateTime.Now.AddMonths(1).ToString()) > -1);
        }
        [TestMethod]
        public void SimpleAddRaffleSaleWithManagerPermission()
        {
            zahiOwner.addManagerPermission(zahi, "addSaleToStore", store, "aviad");
            Assert.IsTrue(aviadManeger.addSaleToStore(aviad, store, cola.getProductInStoreId(), 3, 1, DateTime.Now.AddMonths(1).ToString()) > -1);
            Assert.AreEqual(store.getAllSales().Count, 1);
        }

    }
}
