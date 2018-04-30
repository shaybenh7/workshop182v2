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
        public IHttpActionResult viewProductsInStore(int storeId)
        {
            return Ok(new { results = "sas" });
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
        public string removeUser(String userMakingDeletion, String userDeleted)
        {
            return "not implemented";
        }

    }
}