﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wsep182.Domain
{
    public class StoreManager : StoreRole
    {
        StorePremissionsArchive premissions;
        public StoreManager(User u, Store s) : base(u, s)
        {
            premissions = StorePremissionsArchive.getInstance();
        }

        public override int addProductInStore(User session, Store s, String productName, double price, int amount)
        {
            if (premissions.checkPrivilege(s.getStoreId(), session.getUserName(),"addProductInStore"))
                return base.addProductInStore(session, s, productName, price, amount);
            return -4; //-4 if don't have premition
        }
		

        public override Boolean addDiscount(User session, ProductInStore p, int percentage, String dueDate)
        {
            if (premissions.checkPrivilege(p.getStore().getStoreId(), session.getUserName(), "addDiscount"))
                return base.addDiscount(session, p, percentage, dueDate);
            return false;
        }

        public override Boolean removeDiscount(User session, ProductInStore p)
        {
            if (premissions.checkPrivilege(p.getStore().getStoreId(), session.getUserName(), "removeDiscount"))
                return base.removeDiscount(session, p);
            return false;
        }

        public override Boolean addNewCoupon(User session, String couponId, ProductInStore p, int percentage, String dueDate)
        {
            if (premissions.checkPrivilege(p.getStore().getStoreId(), session.getUserName(), "addNewCoupon"))
                return base.addNewCoupon(session, couponId, p, percentage, dueDate);
            return false;
        }

        public override Boolean removeCoupon(User session, Store s, String couponId)
        {
            if (premissions.checkPrivilege(s.getStoreId(), session.getUserName(), "removeCoupon"))
                return base.removeCoupon(session, s, couponId);
            return false;
        }

        public override int editProductInStore(User session, ProductInStore p, int quantity, double price)
        {
            if (session != null && p != null && price >= 0 && quantity >= 0)
                if (premissions.checkPrivilege(p.getStore().getStoreId(), session.getUserName(), "editProductInStore"))
                    return base.editProductInStore(session, p, quantity, price);
            return -4;//-4 if don't have premition
        }

        public override Boolean addStoreOwner(User session, Store s, String newOwner)
        {
            return false;
        }

        public override int removeStoreOwner(User session, Store s, String ownerToDelete)
        {
            return -4;// -4 if don't have premition
        }

        public override int removeProductFromStore(User session, Store s, ProductInStore p)
        {
            if (premissions.checkPrivilege(s.getStoreId(), session.getUserName(),"removeProductFromStore"))
                return base.removeProductFromStore(session, s, p);
            return -4;// -4 if don't have premition
        }

        public override Boolean addStoreManager(User session, Store s, String newManager)
        {
            if (premissions.checkPrivilege(s.getStoreId(), session.getUserName(), "addStoreManager"))
                return base.addStoreManager(session, s, newManager);
            return false;
        }
        public override Boolean removeStoreManager(User session, Store s, String oldManager)
        {
            if (premissions.checkPrivilege(s.getStoreId(), session.getUserName(), "removeStoreManager"))
                return base.removeStoreManager(session, s, oldManager);
            return false;
            
        }

        public override Premissions getPremissions(User manager, Store s)
        {
            return premissions.getAllPremissions(s.getStoreId(), manager.getUserName());
        }

        public override Boolean addManagerPermission(User session, String permission, Store s, String manager)
        {
            if (premissions.checkPrivilege(s.getStoreId(), session.getUserName(), "addManagerPermission"))
                return base.addManagerPermission(session, permission, s, manager);
            return false;
        }

        public override Boolean removeManagerPermission(User session, String permission, Store s, String manager)
        {
            if (premissions.checkPrivilege(s.getStoreId(), session.getUserName(), "removeManagerPermission"))
                return base.removeManagerPermission(session, permission, s, manager);
            return false;
        }

        public override int addSaleToStore(User session, Store s, int productInStoreId, int typeOfSale, int amount, String dueDate)
        {
            if (premissions.checkPrivilege(s.getStoreId(), session.getUserName(), "addSaleToStore"))
                return base.addSaleToStore(session, s, productInStoreId, typeOfSale, amount, dueDate);
            return -1;
        }

        public override Boolean removeSaleFromStore(User session, Store s, int saleId)
        {
            if (premissions.checkPrivilege(s.getStoreId(), session.getUserName(), "removeSaleFromStore"))
                return base.removeSaleFromStore(session, s, saleId);
            return false;
        }

        public override Boolean editSale(User session, Store s, int saleId, int amount, String dueDate)
        {            
            if (premissions.checkPrivilege(s.getStoreId(), session.getUserName(), "editSale"))
                return base.editSale(session, s, saleId, amount, dueDate);
            return false;
        }

        public override LinkedList<Purchase> viewPurchasesHistory(User session, Store s)
        {
            if (premissions.checkPrivilege(s.getStoreId(), session.getUserName(), "viewPurchasesHistory"))
                return base.viewPurchasesHistory(session, s);
            return null;
        }

    }
}
