﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wsep182.Domain;

namespace wsep182.services
{
    public class userServices
    {
        private static userServices instance = null;

        private userServices() {

        }
        public static userServices getInstance()
        {
            if (instance == null)
            {
                instance = new userServices();
            }
            return instance;
        }

        // req 1.1
        public User startSession()
        {
            String s = hashServices.generateID();
            User user = new User(s, s);
            return user;
        }

        // req 1.2
        /*
         * return:
         *           0 on sucess
         *          -1 if username is empty
         *          -2 if password is empty
         *          -3 if username contains spaces
         *          -4 if username allready exist in the system
         *          -5 if you are allready logged in
         */
        public int register(User session, String username, String password)
        {
            return session.register(username, password);
        }

        //req 1.3 a
        public LinkedList<ProductInStore> viewProductsInStore(int storeId)
        {
            Store s = storeArchive.getInstance().getStore(storeId);
            if (s == null)
                return null;
            return s.getProductsInStore();
        }

        //req 1.3 b
        public LinkedList<ProductInStore> viewProductsInStores()
        {
            return ProductInStore.getAllProductsInAllStores();
        }
        //req 1.3 b
        public LinkedList<Sale> viewAllSales()
        {
            return Sale.getAllSales();
        }

        //req 1.3 c
        public LinkedList<Store> viewStores()
        {
            return Store.viewStores();
        }

        /*
         * return:
         *          0 if login success
         *          -1 username not exist
         *          -2 wrong password
         *          -3 user is removed
         *          -4 you are allready logged in
         */

        //req 2.1 
        public int login(User session, String userName, String password)
        {
            return session.login(userName, password);
        }

        /*
         * return :
         *           0 if user removed successfuly
         *          -1 if you are not loggin
         *          -2 user to remove is not exist
         *          -3 user to remove allready removed
         *          -4 user cannot remove himself
         *          -5 user who has raffle sale can not be removed
         *          -6 user who is owner or creator of store can not be removed
         */
        // req 5.2
        public int removeUser(User userMakingDeletion, String userDeleted)
        {
            return userMakingDeletion.removeUser(userDeleted);
        }


  }
}
 