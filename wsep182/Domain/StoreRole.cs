﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wsep182.Domain
{
    public abstract class StoreRole
    {
        private User user;
        private Store store;

        public StoreRole(User u, Store s) {
            user = u;
            store = s;
        }

        public static StoreRole getStoreRole(Store store, User user)
        {
            if (store == null || user == null)
                return null;
            return storeArchive.getInstance().getStoreRole(store, user);
        }


        public virtual int addProductInStore(User session, Store s, String productName, double price, int amount)
        {
            if (productName == null ||  productName == ""
                || productName[productName.Length - 1] == ' ')
                return -3;//-3 if illegal product name
            if (session == null)
                return -1;// -1 if user Not Login
            if (s == null)
                return -6;// -6 if illegal store id
            if (amount <= 0)
                return -5;// -5 if illegal amount
            if (price <= 0)
                return -7;// -7 if illegal price
            //if(check if session is owner or manager with the right permission)
            Product p2 = ProductArchive.getInstance().getProductByName(productName);
            if (p2 == null)
            {
                p2 = Product.addProduct(productName);
            }

            return ProductArchive.getInstance().addProductInStore(p2, s, amount, price).getProductInStoreId();
        }
        /*
       * return:
       *           0 < on sucess
       *          -1 if user Not Login
       *          -2 if Store Name already exist
       *          -3 if illegal product name
       *          -4 if don't have premition
       *          -5 if illegal amount
       *          -6 if illegal store id
       *          -7 if illegal price
       *          -8 if illegal product in store Id
       */
        public virtual int editProductInStore(User session, ProductInStore p, int quantity, double price)
        {
            if (session == null)
                return -1;// -1 if user Not Login
            if (p == null)
                return -8;// -8 if illegal product in store Id
            if (price < 0)
                return -7;// -7 if illegal price
            if (quantity < 0)
                return -5;// -7 if illegal price

            p.Price = price;
            p.Quantity = quantity;
            if (ProductArchive.getInstance().updateProductInStore(p))
                return 0;// OK
            return -9;// -9 database eror


        }
        public virtual int removeProductFromStore(User session, Store s, ProductInStore p)
        {
            if (session == null)
                return -1;//-1 if user Not Login
            if (s == null)
                return -6;//-6 if illegal store id
            if (p == null)
                return -8;//-8 if illegal product in store Id
            if (ProductArchive.getInstance().removeProductInStore(p.getProductInStoreId(), s.getStoreId()))
                return 0;
            return -9;

        }
        public virtual Boolean addStoreManager(User session, Store s, String newManagerUserName)
        {
            User newManager = UserArchive.getInstance().getUser(newManagerUserName);
            if (session == null || s == null || newManager == null)
                return false;
            StoreRole sr = storeArchive.getInstance().getStoreRole(s, newManager);
            if (sr != null && (sr is StoreOwner || sr is StoreManager))
                return false;
            if (sr != null && (sr is Customer))
                storeArchive.getInstance().removeStoreRole(s.getStoreId(), newManager.getUserName());
            StoreRole m = new StoreManager(newManager, s);
            return storeArchive.getInstance().addStoreRole(m, s.getStoreId(), newManager.getUserName());
        }
        public virtual Boolean removeStoreManager(User session, Store s, String oldManager)
        {
            if (session == null || s == null || oldManager == null)
                return false;
            return storeArchive.getInstance().removeStoreRole(s.getStoreId(), oldManager);
        }

        public virtual Boolean addStoreOwner(User session, Store s, String newOwnerUserName)
        {
            User newOwner = UserArchive.getInstance().getUser(newOwnerUserName);
            if (newOwner == null || s == null || session == null)
            {
                return false;
            }
            StoreRole sr = storeArchive.getInstance().getStoreRole(s, newOwner);
            if (sr != null && (sr is StoreOwner))
                return false;
            if (sr != null && (sr is StoreManager))
                removeStoreManager(session, s, newOwnerUserName);
            if (sr != null && (sr is Customer))
                storeArchive.getInstance().removeStoreRole(s.getStoreId(), newOwner.getUserName());
            StoreRole owner = new StoreOwner(newOwner, s);
            return storeArchive.getInstance().addStoreRole(owner, s.getStoreId(), newOwner.getUserName());
        }
        public virtual Boolean removeStoreOwner(User session, Store s, String ownerToDelete)
        {
            User oldOwner = UserArchive.getInstance().getUser(ownerToDelete);
            StoreRole sR2 = StoreRole.getStoreRole(s, oldOwner);
            if (ownerToDelete == user.getUserName())
                return false;//owner cannot remove himself
            if (!(sR2 is StoreOwner))
                return false;
            if (s.getStoreCreator().getUserName().Equals(ownerToDelete))
                return false;
            return storeArchive.getInstance().removeStoreRole(s.getStoreId(), ownerToDelete);
        }
        public virtual Boolean addManagerPermission(User session, String permission, Store s, String managerUserName)
        {
            User manager = UserArchive.getInstance().getUser(managerUserName);
            if (session == null || permission == null || manager == null || s == null)
                return false;
            StoreRole sR = storeArchive.getInstance().getStoreRole(s, manager);
            return correlate(manager, s, permission, sR, true);

        }
        public virtual int addSaleToStore(User session, Store s, int productInStoreId, int typeOfSale, int amount, String dueDate)
        {
            ProductInStore pis = ProductArchive.getInstance().getProductInStore(productInStoreId);
            if (session == null || s == null || dueDate == null ||pis == null || typeOfSale > 3 || typeOfSale < 1 || pis.getAmount() < amount || amount < 0 || dueDate == null)
                return -1;
            if (pis.getStore().getStoreId() != s.getStoreId())
                return -1;
            if (typeOfSale == 2)
            {
                //will be implemented next version
                return -1;
            }
            Sale sale = SalesArchive.getInstance().addSale(productInStoreId, typeOfSale, amount, dueDate);
            
            return (sale == null) ? -1 : sale.SaleId;
        }

        public virtual Boolean removeSaleFromStore(User session, Store s, int saleId)
        {
            if (session == null || s == null || SalesArchive.getInstance().getSale(saleId) == null)
                return false;
            return SalesArchive.getInstance().removeSale(saleId);
        }

        public virtual Boolean editSale(User session, Store s, int saleId, int amount, String dueDate)
        {
            if (session == null || s == null || SalesArchive.getInstance().getSale(saleId) == null
                || amount < 0 || dueDate == null ||
                ProductArchive.getInstance().getProductInStore(SalesArchive.getInstance().getSale(saleId).ProductInStoreId).getAmount() < amount)
                return false;
            return SalesArchive.getInstance().editSale(saleId, amount, dueDate);
        }

        public virtual Boolean addDiscount(User session, ProductInStore p, int percentage, String dueDate)
        {
            if (session == null || p == null || percentage < 0 || percentage >= 100 || dueDate == null)
                return false;
            return DiscountsArchive.getInstance().addNewDiscount(p.getProductInStoreId(), percentage, dueDate);
        }

        public virtual Boolean addNewCoupon(User session, String couponId, ProductInStore p, int percentage, String dueDate)
        {
            if (session == null || couponId == null || p == null || percentage < 0 || dueDate == null || percentage<=0)
                return false;
            return CouponsArchive.getInstance().addNewCoupon(couponId, p.getProductInStoreId(), percentage, dueDate);
        }

        public virtual Boolean removeDiscount(User session, ProductInStore p)
        {
            if (p == null || session == null)
                return false;
            return DiscountsArchive.getInstance().removeDiscount(p.getProductInStoreId());
        }

        public virtual Boolean removeCoupon(User session, Store s, String couponId)
        {
            if (session == null || couponId==null)
                return false;
            return CouponsArchive.getInstance().removeCoupon(couponId);
        }

        public virtual Boolean removeManagerPermission(User session, String permission, Store s, String managerUsername)
        {
            if (managerUsername == null)
                return false;
            User manager = UserArchive.getInstance().getUser(managerUsername);

            if (permission == null || manager == null || session == null || s == null)
                return false;
            StoreRole sR = storeArchive.getInstance().getStoreRole(s, manager);
            return correlate(manager, s, permission, sR, false);
        }
        public virtual LinkedList<Purchase> viewPurchasesHistory(User session,Store s)
        {
            return BuyHistoryArchive.getInstance().viewHistoryByStoreId(s.getStoreId());
        }

        public Boolean correlate(User session, Store s, String permission, StoreRole sR, Boolean allow)
        {
            switch (permission)
            {
                case "addProductInStore":
                    sR.getPremissions(session,s).addProductInStore(allow);
                    return true;

                case "editProductInStore":
                    sR.getPremissions(session, s).editProductInStore(allow);
                    return true;

                case "removeProductFromStore":
                    sR.getPremissions(session, s).removeProductFromStore(allow);
                    return true;

                case "addStoreManager":
                    sR.getPremissions(session, s).addStoreManager(allow);
                    return true;
                case "removeStoreManager":
                    sR.getPremissions(session, s).removeStoreManager(allow);
                    return true;
                case "addManagerPermission":
                    sR.getPremissions(session, s).addManagerPermission(allow);
                    return true;
                case "removeManagerPermission":
                    sR.getPremissions(session, s).removeManagerPermission(allow);
                    return true;
                case "viewPurchasesHistory":
                    sR.getPremissions(session, s).viewPurchasesHistory(allow);
                    return true;
                case "removeSaleFromStore":
                    sR.getPremissions(session, s).removeSaleFromStore(allow);
                    return true;
                case "editSale":
                    sR.getPremissions(session, s).editSale(allow);
                    return true;
                case "addSaleToStore":
                    sR.getPremissions(session, s).addSaleToStore(allow);
                    return true;
                case "addDiscount":
                    sR.getPremissions(session, s).addDiscount(allow);
                    return true;
                case "addNewCoupon":
                    sR.getPremissions(session, s).addNewCoupon(allow);
                    return true;
                case "removeDiscount":
                    sR.getPremissions(session, s).removeDiscount(allow);
                    return true;
                case "removeCoupon":
                    sR.getPremissions(session, s).removeCoupon(allow);
                    return true;
                    


                case "getPremissions":
                    return true;
                case "addStoreOwner":
                    return false;
                case "removeStoreOwner":
                    return false;

                default:
                    return false;
            }
        }


        public virtual Premissions getPremissions(User manager, Store s)
        {
            return StorePremissionsArchive.getInstance().getAllPremissions(s.getStoreId(),manager.getUserName());
        }

        public User getUser()
        {
            return user;
        }
        public Store getStore()
        {
            return store;
        }
        public void setUser(User u)
        {
            user = u;
        }
        public void setStore(Store s)
        {
            store = s;
        }

    }
}
