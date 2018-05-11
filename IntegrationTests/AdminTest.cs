﻿using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using wsep182.Domain;

namespace IntegrationTests
{
    [TestClass]
    public class AdminTest
    {
        private User zahi, itamar, niv, admin, admin1;
        private Store store;

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
            admin = new User("admin", "123456");
            admin.register("admin", "123456");
            admin.login("admin", "123456");

            admin1 = new User("admin1", "123456");
            admin1.register("admin1", "123456");

            zahi = new User("zahi", "123456");
            zahi.register("zahi", "123456");

            itamar = new User("itamar", "123456");
            itamar.register("itamar", "123456");
            itamar.login("itamar", "123456");
            int storeId = itamar.createStore("Maria&Netta Inc.");
            store = storeArchive.getInstance().getStore(storeId);
            niv = new User("niv", "123456");
            niv.register("niv", "123456");
        }

        [TestMethod]
        public void SimpleRemoveUser()
        {

            Assert.IsTrue(admin.removeUser("zahi") > -1);
            Assert.IsFalse(zahi.login("zahi", "123456") > -1);
        }
        [TestMethod]
        public void RemoveUserAdminNotLogin()
        {
            Assert.IsFalse(admin1.removeUser("zahi") > -1);
            Assert.IsTrue(zahi.login("zahi", "123456") > -1);
        }
        [TestMethod]
        public void AdminRemoveHimself()
        {
            Assert.IsFalse(admin.removeUser("admin") > -1);
            admin.logOut();
            Assert.IsTrue(admin.login("admin", "123456") > -1);
        }
        [TestMethod]
        public void UserRemoveHimself()
        {
            zahi.login("zahi", "123456");
            Assert.IsFalse(zahi.removeUser("zahi") > -1);
        }
        [TestMethod]
        public void AdminRemoveAdmin()
        {
            Assert.IsTrue(admin.removeUser("admin1") > -1);
            Assert.IsFalse(admin1.login("admin1", "123456") > -1);
        }

        [TestMethod]
        public void RemoveUserTwice()
        {
            Assert.IsTrue(admin.removeUser("zahi") > -1);
            Assert.IsFalse(admin.removeUser("zahi") > -1);
            Assert.IsFalse(zahi.login("zahi", "123456") > -1);
        }
        [TestMethod]
        public void RemoveUserThatNotExist()
        {
            Assert.IsFalse(admin.removeUser("shay") > -1);
        }
        [TestMethod]
        public void RemoveCreatoreOwner()
        {
            Assert.IsFalse(admin.removeUser("itamar") > -1);
            Assert.AreEqual(store.getOwners().Count, 1);
        }
    }
}
