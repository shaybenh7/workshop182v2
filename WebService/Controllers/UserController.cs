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
            bool ans = userServices.getInstance().register(session, Username, Password);
            if (ans)
                return "the user has been added succsesfuly";
            else
                return "error";
        }


        [Route("api/user/viewProductsInStore")]
        [HttpGet]
        public string viewProductsInStore(int storeId)
        {
            return "not implemented";
        }

        [Route("api/user/viewProductsInStores")]
        [HttpGet]
        public string viewProductsInStores()
        {
            return "not implemented";
        }


        [Route("api/user/viewStores")]
        [HttpGet]
        public string viewStores()
        {
            return "not implemented";
        }

        [Route("api/user/login")]
        [HttpGet]
        public string login(String Username, String Password)
        {
            User session = hashServices.getUserByHash(System.Web.HttpContext.Current.Request.Cookies["Session"].Value);
            bool ans = userServices.getInstance().login(session, Username, Password);
            if (ans)
                return "user has been logged in succesfuly";
            return "not implemented";
        }

        [Route("api/user/removeUser")]
        [HttpDelete]
        public string removeUser(String userMakingDeletion, String userDeleted)
        {
            return "not implemented";
        }

    }
}