using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using wsep182.Domain;
using wsep182.services;

namespace Acceptance_Tests.StoreTests
{
    [TestClass]
    public class removeStoreOwner
    {

        private userServices us;
        private storeServices ss;
        private User zahi, itamar, niv, admin, admin1; //admin,itamar logedin
        private Store store;//itamar owner , niv manneger

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
            us = userServices.getInstance();
            ss = storeServices.getInstance();
            admin = us.startSession();
            us.register(admin, "admin", "123456");
            us.login(admin, "admin", "123456");

            admin1 = us.startSession();
            us.register(admin1, "admin1", "123456");

            zahi = us.startSession();
            us.register(zahi, "zahi", "123456");
            zahi.login("zahi", "123456");

            itamar = us.startSession();
            us.register(itamar, "itamar", "123456");
            itamar.login("itamar", "123456");
            store = storeArchive.getInstance().getStore(itamar.createStore("Maria&Netta Inc."));

            niv = us.startSession();
            us.register(niv, "niv", "123456");
            niv.login("niv", "123456");

            ss.addStoreManager(store.getStoreId(), "niv", itamar);

        }

        [TestMethod]
        public void SimpleRemoveStoreOwner()
        {
            ss.addStoreOwner(store, "zahi", itamar);
            Assert.AreEqual(ss.removeStoreOwner(store.getStoreId(), "zahi", itamar),0);
            Assert.AreEqual(ss.getOwners(store.getStoreId()).Count, 1);  
        }
        [TestMethod]
        public void OwnerRemoveHimself()
        {
            ss.addStoreOwner(store, "zahi", itamar);
            Assert.AreEqual(ss.removeStoreOwner(store.getStoreId(), "zahi", zahi),-10);//-10 can't remove himself
            Assert.AreEqual(ss.removeStoreOwner(store.getStoreId(), "itamar", itamar),-10);//-10 can't remove himself
            Assert.AreEqual(ss.getOwners(store.getStoreId()).Count, 2);
        }
        [TestMethod]
        public void OwnerRemoveHimselfWhenThierIsOneOwner()
        {
            Assert.AreEqual(ss.removeStoreOwner(store.getStoreId(), "itamar", itamar),-10);////-10 can't remove himself
            Assert.AreEqual(ss.getOwners(store.getStoreId()).Count, 1);
        }
        [TestMethod]
        public void MannegerRemoveOwner()
        {
            ss.addStoreOwner(store, "zahi", itamar);
            Assert.AreEqual(ss.removeStoreOwner(store.getStoreId(), "zahi", niv),-4);// -4 if don't have premition
            Assert.AreEqual(ss.getOwners(store.getStoreId()).Count, 2);
        }
        [TestMethod]
        public void UserRemoveOwner()
        {
            User aviad = us.startSession();
            aviad.register("aviad", "123456");
            us.login(aviad, "aviad", "123456");
            ss.addStoreOwner(store, "zahi", itamar);
            Assert.AreEqual(ss.removeStoreOwner(store.getStoreId(), "zahi", aviad), -4);//-4 if don't have premition
            Assert.AreEqual(ss.getOwners(store.getStoreId()).Count, 2);
        }
        [TestMethod]
        public void GusetRemoveOwner()
        {
            ss.addStoreOwner(store, "zahi", itamar);
            Assert.AreEqual(ss.removeStoreOwner(store.getStoreId(), "zahi", niv),-4);//-4 if don't have premition || -1 not login
            Assert.AreEqual(ss.getOwners(store.getStoreId()).Count, 2);
        }
        [TestMethod]
        public void RemoveOwnerThatNotOwner()
        {
            ss.addStoreOwner(store, "zahi", itamar);
            Assert.AreEqual(ss.removeStoreOwner(store.getStoreId(), "niv", itamar),-11);//-11 not a owner
            Assert.AreEqual(ss.getOwners(store.getStoreId()).Count, 2);
        }
        [TestMethod]
        public void RemoveOwnerThatNotExist()
        {
            User aviad = new User("aviad", "123456");
            Assert.AreEqual(ss.removeStoreOwner(store.getStoreId(), "aviad", itamar), -11);//-11 not a owner
            Assert.AreEqual(ss.getOwners(store.getStoreId()).Count, 1);
        }
        [TestMethod]
        public void RemoveOwnerStoreNotExist()
        {
            Store store2 = new Store(2, "abow", zahi);
            Assert.AreEqual(ss.removeStoreOwner(store2.getStoreId(), "niv", zahi),-6);// -6 if illegal store id
        }

        /*
* return:
*           0 on sucess
*          -1 if user Not Login
*          -2 if Store Name already exist
*          -3 if illegal product name
*          -4 if don't have premition
*          -5 if illegal amount
*          -6 if illegal store id
*          -7 if illegal price
*          -8 if illegal product in store Id
*          -9 database eror
*          -10 can't remove himself
*          -11 not a owner
*          -12 if dealet creator
*/
        [TestMethod]
        public void RemoveOwnerByAdmin()
        {
            ss.addStoreOwner(store, "zahi", itamar);
            Assert.AreEqual(ss.removeStoreOwner(store.getStoreId(), "zahi", admin),-4);//-4 if don't have premition
            Assert.AreEqual(ss.getOwners(store.getStoreId()).Count, 2);
        }
        [TestMethod]
        public void RemoveOwnerByOwnerThatStopBeingOwner()
        {
            us.login(zahi, "zahi", "123456");
            us.login(niv, "niv", "123456");
            ss.addStoreOwner(store, "zahi", itamar);
            Assert.IsTrue(ss.addStoreOwner(store, "niv", zahi));
            Assert.AreEqual(ss.removeStoreOwner(store.getStoreId(), "zahi", itamar),0);
            Assert.AreEqual(ss.removeStoreOwner(store.getStoreId(), "niv", zahi),-4);//-4 if don't have premition
            Assert.AreEqual(ss.removeStoreOwner(store.getStoreId(), "niv", itamar),0);
            Assert.AreEqual(ss.getOwners(store.getStoreId()).Count, 1);
        }


    }
}
