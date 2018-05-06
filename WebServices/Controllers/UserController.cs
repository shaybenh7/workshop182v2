﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Security;
using wsep182.Domain;
using wsep182.services;

namespace WebService.Controllers
{
    public class UserController : ApiController
    {
        [Route("api/user/register")]
        [HttpGet]
        public string register(String Username, String Password)
        {
            User session = hashServices.getUserByHash(System.Web.HttpContext.Current.Request.Cookies["Session"].Value);
            int ans = userServices.getInstance().register(session, Username, Password);
            switch (ans)
            {
                case 0:
                    return "user successfuly added";
                case -1:
                    return "error: username is not entered";
                case -2:
                    return "error: password is not entered";
                case -3:
                    return "error: username contains spaces";
                case -4:
                    return "error: username allready exist in the system";
                case -5:
                    return "error: you are allready logged in";
            }
            return "server error: not suppose to happend";
        }


        [Route("api/user/viewProductsInStore")]
        [HttpGet]
        public HttpResponseMessage viewProductsInStore(int storeId)
        {
            LinkedList<ProductInStore> pis = userServices.getInstance().viewProductsInStore(storeId);
            HttpResponseMessage response;
            if (pis == null)
            {
                response = Request.CreateResponse(HttpStatusCode.NotFound, "Store is not exist");
                return response;
            }
            response = Request.CreateResponse(HttpStatusCode.OK, pis);
            return response;
        }

        [Route("api/user/viewProductsInStores")]
        [HttpGet]
        public HttpResponseMessage viewProductsInStores()
        {
            LinkedList<ProductInStore> pis = userServices.getInstance().viewProductsInStores();
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, pis);
            return response;
        }

        [Route("api/user/viewAllSales")]
        [HttpGet]
        public HttpResponseMessage viewAllSales()
        {
            LinkedList<Sale> pis = userServices.getInstance().viewAllSales();
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, pis);
            return response;
        }



        [Route("api/user/fillDB")]
        [HttpGet]
        public void fillDB()
        {
            userServices us;
            storeServices ss;
            User zahi, itamar, niv, admin, admin1; //admin,itamar logedin
            Store store;//itamar owner , niv manneger
            ProductInStore cola, sprite;
            int saleId;
            int raffleSale;
            us = userServices.getInstance();
            ss = storeServices.getInstance();
            admin = us.startSession();
            us.register(admin, "admin", "123456");
            us.login(admin, "admin", "123456");

            admin1 = us.startSession();
            us.register(admin1, "admin1", "123456");

            zahi = us.startSession();
            us.register(zahi, "zahi", "123456");
            us.login(zahi, "zahi", "123456");

            itamar = us.startSession();
            us.register(itamar, "itamar", "123456");
            us.login(itamar, "itamar", "123456");



            int storeid = ss.createStore("Maria&Netta Inc.", zahi);
            store = storeArchive.getInstance().getStore(storeid);

            niv = us.startSession();
            us.register(niv, "niv", "123456");
            us.login(niv, "niv", "123456");

            ss.addStoreManager(store.getStoreId(), "niv", itamar);

            int c = ss.addProductInStore("cola", 3.2, 10, zahi, storeid);
            int s = ss.addProductInStore("sprite", 5.3, 20, zahi, storeid);
            cola = ProductArchive.getInstance().getProductInStore(c);
            sprite = ProductArchive.getInstance().getProductInStore(s);
            saleId = ss.addSaleToStore(zahi, store.getStoreId(), cola.getProductInStoreId(), 1, 1, "20.5.2018");
            raffleSale = ss.addSaleToStore(zahi, store.getStoreId(), cola.getProductInStoreId(), 3, 1, "20.5.2018");
        }

        [Route("api/user/viewStores")]
        [HttpGet]
        public HttpResponseMessage viewStores()
        {
            LinkedList<Store> stores = userServices.getInstance().viewStores();
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, stores);
            return response;
        }

        [Route("api/user/login")]
        [HttpGet]
        public Object login(String Username, String Password)
        {
            User session = userServices.getInstance().startSession();
            int ans = userServices.getInstance().login(session, Username, Password);
            switch (ans)
            {
                case 0:
                    String hash = System.Web.HttpContext.Current.Request.Cookies["HashCode"].Value;
                    hashServices.configureUser(hash, session);
                    //System.Web.HttpContext.Current.Session["hash"] = hash;
                    //String[] answer = { "user successfuly logged in", hash };
                    
                    return "user successfuly logged in";
                case -1:
                    return "error: username not exist";
                case -2:
                    return "error: wrong password";
                case -3:
                    return "error: user is removed";
                case -4:
                    return "error: you are allready logged in";
            }
            return "server error: not suppose to happend";
        }


        [Route("api/user/generateHash")]
        [HttpGet]
        public Object generateHash()
        {
            return hashServices.generateID();
        }

        [Route("api/user/removeUser")]
        [HttpDelete]
        public string removeUser(String userDeleted)
        {
            if (System.Web.HttpContext.Current.Request.Cookies["HashCode"] == null)
            {
                return "Not logged in";
            }
            User session = hashServices.getUserByHash(System.Web.HttpContext.Current.Request.Cookies["HashCode"].Value);
            int ans = userServices.getInstance().removeUser(session, userDeleted);
            switch(ans)
            {
                case 0:
                    return "user has been removed succesfully";
                case -1:
                    return "you are not admin";
                case -2:
                    return "the user you want to remove is not exist";
                case -3:
                    return "the user you want to remove is allready removed";
                case -4:
                    return "you are not allowed to remove yourself";
                case -5:
                    return "the user you want to remove have raffle sale";
                case -6:
                    return "the user you want to remove is a owner or creator of other stores";
            }
            return "not implemented";
        }

    }
}