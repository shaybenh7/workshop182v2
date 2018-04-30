﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wsep182.Domain;

namespace wsep182.services
{
    public class storeServices
    {
        private static storeServices instance = null;
        private storeServices() { }
        public static storeServices getInstance()
        {
            if (instance == null)
            {
                instance = new storeServices();
            }
            return instance;
        }

        //req 2.2
        /*
         * return:
         *           0 < on sucess
         *          -1 if user Not Login
         *          -2 if Store Name already exist
         *          -3 if iligale Storename
         *          -4 if 
         */
        public int createStore(String storeName, User session)
        {
            if (session == null || !session.getState().isLogedIn())
                return -1;//-1 if user Not Login
            return session.createStore(storeName);
        }

        //req 3.1 a
        public ProductInStore addProductInStore(String productName, Double price, int amount, User session, Store s)
        {
            if (session==null || !session.getState().isLogedIn() || productName == null)
                return null;
            StoreRole sR = StoreRole.getStoreRole(s, session);
            if (sR == null)
                return null;
            return sR.addProductInStore(session, s, productName, price, amount);
        }

        //req 3.1 b
        public virtual Boolean editProductInStore(User session, Store s,ProductInStore p, int quantity, double price)
        {
            StoreRole sR = StoreRole.getStoreRole(s, session);
            if (sR == null)
                return false;
            return sR.editProductInStore(session, p, quantity, price);
        }

        //req 3.1 c
        public Boolean removeProductFromStore(Store s, ProductInStore p, User session)
        {
            StoreRole sR = StoreRole.getStoreRole(s, session);
            if (sR == null)
                return false;
            return sR.removeProductFromStore(session, s, p);
        }

        //req 3.3 a
        public Boolean addStoreOwner(Store s, String newOwner, User session)
        {
            if(s==null || newOwner == null || session == null)
            {
                return false;
            }
            User isExist = UserArchive.getInstance().getUser(newOwner);
            if (isExist == null)
                return false;
            StoreRole sR = StoreRole.getStoreRole(s, session);
            if (sR == null)
                return false;
            return sR.addStoreOwner(session, s, newOwner);
        }

        //req 3.3 b
        public Boolean removeStoreOwner(Store s, String oldOwner, User session)
        {

            StoreRole sR = StoreRole.getStoreRole(s, session);
            if (sR == null)
                return false;
            return sR.removeStoreOwner(session, s, oldOwner);
        }

        //req 3.4 a
        public Boolean addStoreManager(Store s, String newManager, User session)
        {
            StoreRole sR = StoreRole.getStoreRole(s, session);
            if (sR == null)
                return false;
            return sR.addStoreManager(session, s, newManager);
        }

        //req 3.4 b
        public Boolean removeStoreManager(Store s, String oldManageruserName, User session)
        {
            if (oldManageruserName == session.getUserName())
                return false;
            StoreRole sR = StoreRole.getStoreRole(s, session);
            if (sR == null)
                return false;
            return sR.removeStoreManager(session, s, oldManageruserName);
        }

        //req 3.4 c
        public Boolean addManagerPermission(String permission, Store s, String managerToAdd, User session)
        {
            StoreRole sR = StoreRole.getStoreRole(s, session);
            if (sR == null)
                return false;
            return sR.addManagerPermission(session, permission, s, managerToAdd);

        }

        //req 3.4 d
        public Boolean removeManagerPermission(String permission, Store s, String manager, User session)
        {
            StoreRole sR = StoreRole.getStoreRole(s, session);
            if (sR == null)
                return false;
            return sR.removeManagerPermission(session, permission, s, manager);
        }

        //req 3.7 and 5.4 a
        public LinkedList<Purchase> viewStoreHistory(User session, Store store)
        {
            if (session == null | store == null)
                return null;
            return session.viewStoreHistory(store);
        }

        //req 5.4 b
        public LinkedList<Purchase> viewUserHistory(User session, String userToGetHistory)
        {
            if (session == null | userToGetHistory == null)
                return null;
            return session.viewUserHistory(userToGetHistory);
        }

        public int addSaleToStore(User session, Store s, int productInStoreId, int typeOfSale, int amount, String dueDate)
        {
            if (session==null||!session.getState().isLogedIn())
                return -1;
            StoreRole sR = StoreRole.getStoreRole(s, session);
            if (sR == null)
                return -1;
            return sR.addSaleToStore(session, s, productInStoreId, typeOfSale, amount, dueDate);
        }

        public Boolean removeSaleFromStore(User session, Store s, int saleId)
        {
            StoreRole sR = StoreRole.getStoreRole(s, session);
            if (sR == null)
                return false;
            return sR.removeSaleFromStore(session, s, saleId);
        }
        public Boolean editSale(User session, Store s, int saleId, int amount, String dueDate)
        {
            StoreRole sR = StoreRole.getStoreRole(s, session);
            if (sR == null)
                return false;
            return sR.editSale(session, s, saleId,amount,dueDate);
        }

        
      
        public Boolean addBuyPolicy(ProductInStore p, User session)
        {
            //Not implemented in this version
            return false;
        }

        public Boolean removeBuyPolicy(ProductInStore p, User session)
        {
            //Not implemented in this version
            return false;
        }

        public Boolean addCouponDiscount(User session,Store s, String couponId, ProductInStore p, int percentage, String dueDate)
        {
            StoreRole sR = StoreRole.getStoreRole(s, session);
            if (sR == null)
                return false;
            return sR.addNewCoupon(session, couponId, p, percentage, dueDate);
        }
        public Boolean addDiscount(ProductInStore p, int percentage ,String dueDate,User session ,Store s)
        {
            StoreRole sR = StoreRole.getStoreRole(s, session);
            if (sR == null)
                return false;
            return sR.addDiscount(session,p, percentage, dueDate);
            
        }
        public Boolean removeDiscount(ProductInStore p, Store s, User session)
        {
            StoreRole sR = StoreRole.getStoreRole(s, session);
            if (sR == null)
                return false;
            return sR.removeDiscount(session, p);
        }

        public Boolean removeCoupon(Store s, User session, String couponId)
        {
            StoreRole sR = StoreRole.getStoreRole(s, session);
            if (sR == null)
                return false;
            return sR.removeCoupon(session, s, couponId);
        }

 



        public LinkedList<StoreOwner> getOwners(Store s)
        {
            if (s == null)
                return null;
            return s.getOwners();
        }

        public LinkedList<StoreManager> getManagers(Store s)
        {
            if (s == null)
                return null;
            return s.getManagers();
        }

        public LinkedList<Sale> viewSalesByStore(Store store)
        {
            if (store == null)
                return null;
            return store.getAllSales();
        }

    }
}