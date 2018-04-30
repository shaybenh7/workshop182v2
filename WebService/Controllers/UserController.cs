using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
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
        public string login(String Username, String Password)
        {
            User session = hashServices.getUserByHash(System.Web.HttpContext.Current.Request.Cookies["Session"].Value);
            int ans = userServices.getInstance().login(session, Username, Password);
            switch (ans)
            {
                case 0:
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

        [Route("api/user/removeUser")]
        [HttpDelete]
        public string removeUser(String userDeleted)
        {
            User session = hashServices.getUserByHash(System.Web.HttpContext.Current.Request.Cookies["Session"].Value);
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