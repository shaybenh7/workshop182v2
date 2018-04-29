﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wsep182.Domain
{
    public class Admin : UserState
    {
        public override Boolean removeUser(User session, string userDeleted)
        {
            User userToDelete = UserArchive.getInstance().getUser(userDeleted);
            if (userToDelete == null || !userToDelete.getIsActive() || userToDelete.getUserName() == session.getUserName())
                return false;
            if (RaffleSalesArchive.getInstance().getAllRaffleSalesByUserName(userDeleted).Count > 0)
                return false;
            LinkedList<StoreRole> roles = storeArchive.getInstance().getAllStoreRolesOfAUser(userDeleted);
            if (checkLoneOwnerOrCreator(roles))
                return false;

            if (!removeAllRolesOfAUser(roles))
                return false;
            return UserArchive.getInstance().removeUser(userDeleted);
        }

        private Boolean checkLoneOwnerOrCreator(LinkedList<StoreRole> roles)
        {
            foreach (StoreRole sr in roles)
            {
                if (sr is StoreOwner)
                {
                    //check if he's a lone owner
                    if (sr.getStore().getOwners().Count == 1)
                        return true;
                    //owner which is a creater
                    if (sr.getStore().getStoreCreator().getUserName() == sr.getUser().getUserName())
                        return true;
                }
            }
            return false;
        }

        private Boolean removeAllRolesOfAUser(LinkedList<StoreRole> roles)
        {
            Boolean res = true;
            foreach (StoreRole sr in roles)
            {
                if (sr is StoreOwner)
                {
                    if (sr.getStore().getOwners().Count > 1)
                        res = res && storeArchive.getInstance().removeStoreRole(sr.getStore().getStoreId(), sr.getUser().getUserName());
                    else throw new Exception("something went seriously wrong"); // in the interval between the call to the safety check to now, something occured
                }
                else
                    res = res && storeArchive.getInstance().removeStoreRole(sr.getStore().getStoreId(), sr.getUser().getUserName());
            }
            return res;
        }


        public override Boolean isLogedIn()
        {
            return true;
        }

        public override LinkedList<Purchase> viewStoreHistory(Store store, User session)
        {
            return BuyHistoryArchive.getInstance().viewHistoryByStoreId(store.getStoreId());
        }

        public override LinkedList<Purchase> viewUserHistory(User userToGetHistory)
        {
            return BuyHistoryArchive.getInstance().viewHistoryByUserName(userToGetHistory.getUserName());
        }
    }
}
