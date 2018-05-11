using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using wsep182.Domain;

namespace IntegrationTests
{
    [TestClass]
    public class storeTest
    {
        private User zahi;  // owner of store
        private User aviad; //manager of store
        private User shay;
        private User itamar; // not a real user
        private User niv; // guest
        private Store store, store2;
        StoreRole zahiOwner, zahiOwnerStore2;
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
            int storeId2 = zahi.createStore("broes");
            store2 = storeArchive.getInstance().getStore(storeId2);
            zahiOwner = new StoreOwner(zahi, store);
            zahiOwnerStore2 = new StoreOwner(zahi, store2);
            aviadManeger = new StoreManager(aviad, store);
            zahiOwner.addStoreManager(zahi, store, "aviad");
            niv.logOut();
            int colaId = zahiOwner.addProductInStore(zahi, store, "cola", 3.2, 10, "Drinks");
            cola = ProductArchive.getInstance().getProductInStore(colaId);
        }

        [TestMethod]
        public void RemoveProductFromStore()
        {
            int result = zahiOwner.removeProductFromStore(zahi, store, cola);
            Assert.IsTrue(result > -1);
            LinkedList<ProductInStore> LPIS = store.getProductsInStore();
            Assert.AreEqual(LPIS.Count, 0);
        }
        [TestMethod]
        public void RemoveProductFromStoreAsMannegerWithoutPremission()
        {
            int result = aviadManeger.removeProductFromStore(zahi, store, cola);
            Assert.IsFalse(result > -1);
            LinkedList<ProductInStore> LPIS = store.getProductsInStore();
            Assert.AreEqual(LPIS.Count, 1);
        }
        [TestMethod]
        public void RemoveProductFromStoreAsMannegerWithPremission()
        {
            zahiOwner.addManagerPermission(zahi, "removeProductFromStore", store, "aviad");
            int result = aviadManeger.removeProductFromStore(zahi, store, cola);
            Assert.IsTrue(result > -1);
            LinkedList<ProductInStore> LPIS = store.getProductsInStore();
            Assert.AreEqual(LPIS.Count, 0);
        }
        [TestMethod]
        public void RemoveProductFromStoreTwice()
        {
            int result = aviadManeger.removeProductFromStore(zahi, store, cola);
            Assert.IsTrue(result > -1);
            int result2 = aviadManeger.removeProductFromStore(zahi, store, cola);
            Assert.IsFalse(result > -1);
            LinkedList<ProductInStore> LPIS = store.getProductsInStore();
            Assert.AreEqual(LPIS.Count, 0);
        }



        [TestMethod]
        public void RemoveMangerFromStore()
        {
            Assert.IsTrue(zahiOwner.removeStoreManager(zahi, store, "aviad") > -1);
            Assert.AreEqual(store.getManagers().Count, 0);
        }
        [TestMethod]
        public void RemoveMangerFromStoreTwice()
        {
            Assert.IsTrue(zahiOwner.removeStoreManager(zahi, store, "aviad") > -1);
            Assert.AreEqual(store.getManagers().Count, 0);
            Assert.IsFalse(zahiOwner.removeStoreManager(zahi, store, "aviad") > -1);
            Assert.AreEqual(store.getManagers().Count, 0);
        }
        [TestMethod]
        public void RemoveMangerFromStoreAsMannegerWithoutPremition()
        {
            zahiOwner.addStoreManager(zahi, store, "niv");
            Assert.IsFalse(aviadManeger.removeStoreManager(aviad, store, "niv") > -1);
            Assert.AreEqual(store.getManagers().Count, 2);
        }
        [TestMethod]
        public void RemoveMangerFromStoreAsMannegerWithPremition()
        {
            zahiOwner.addStoreManager(zahi, store, "niv");
            zahiOwner.addManagerPermission(zahi, "removeManagerPermission", store, "aviad");
            Assert.IsTrue(aviadManeger.removeStoreManager(aviad, store, "niv") > -1);
            Assert.AreEqual(store.getManagers().Count, 1);
        }

        [TestMethod]
        public void RemoveStoreOwner()
        {
            zahiOwner.addStoreOwner(zahi, store, "shay");
            Assert.IsTrue(zahiOwner.removeStoreOwner(zahi, store, "shay") > -1);
            Assert.AreEqual(store.getOwners().Count, 1);
        }
        [TestMethod]
        public void ViewSlaeInStore()
        {
            int saleId = zahiOwner.addSaleToStore(zahi, store, cola.getProductInStoreId(), 1, 1, "20/5/2018");
            LinkedList<Sale> saleList = store.getAllSales();
            Assert.AreEqual(saleList.Count, 1);
            Assert.AreEqual(saleId, saleList.First.Value.SaleId);
        }
    }
}
