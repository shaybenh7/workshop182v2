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
    public class StoreController : ApiController
    {
        [Route("api/store/createStore")]
        [HttpGet]
        public string createStore(String storeName, int UserId)
        {
            User session = hashServices.getUserByHash(System.Web.HttpContext.Current.Request.Cookies["Session"].Value);
            int ans = storeServices.getInstance().createStore(storeName, session);
            if(ans>0)
                    return "store " + ans + " successfuly added";
            switch (ans)
            {
                case -1:
                    return "error: username is not login";
                case -2:
                    return "error: store name allready exist";
                case -3:
                    return "error: illegal store name";
            }
            return "server error: not suppose to happend";
        }

        [Route("api/store/addProductInStore")]
        [HttpPut]
        public string addProductInStore(String productName, Double price, int amount, int userId, int storeId)
        {
            return "not implemented";
        }

        [Route("api/store/editProductInStore")]
        [HttpPost]
        public string editProductInStore(String productName, Double price, int amount, int userId, int storeId)
        {
            return "not implemented";
        }

        [Route("api/store/removeProductFromStore")]
        [HttpDelete]
        public string removeProductFromStore(int storeId, int ProductInStoreId, String Username)
        {
            return "not implemented";
        }

        [Route("api/store/removeStoreOwner")]
        [HttpDelete]
        public string removeStoreOwner(int storeId, String oldOwner, String session)
        {
            return "not implemented";
        }

        [Route("api/store/addStoreManager")]
        [HttpPut]
        public string addStoreManager(int storeId, String newManager, string session)
        {
            return "not implemented";
        }

        [Route("api/store/removeStoreManager")]
        [HttpDelete]
        public string removeStoreManager(int storeId, String oldManageruserName, String session)
        {
            return "not implemented";
        }

        [Route("api/store/addManagerPermission")]
        [HttpPut]
        public string addManagerPermission(int storeId, String oldManageruserName, String session)
        {
            return "not implemented";
        }

        [Route("api/store/removeManagerPermission")]
        [HttpDelete]
        public string removeManagerPermission(int storeId, String oldManageruserName, String session)
        {
            return "not implemented";
        }

        [Route("api/store/viewStoreHistory")]
        [HttpGet]
        public string viewStoreHistory(int storeId, String oldManageruserName, String session)
        {
            return "not implemented";
        }

        [Route("api/store/viewUserHistory")]
        [HttpGet]
        public string viewUserHistory(int storeId, String oldManageruserName, String session)
        {
            return "not implemented";
        }

        [Route("api/store/addSaleToStore")]
        [HttpPut]
        public string addSaleToStore(int storeId, String oldManageruserName, String session)
        {
            return "not implemented";
        }

        [Route("api/store/removeSaleFromStore")]
        [HttpDelete]
        public string removeSaleFromStore(int storeId, String oldManageruserName, String session)
        {
            return "not implemented";
        }

        [Route("api/store/editSale")]
        [HttpPost]
        public string editSale(int storeId, String oldManageruserName, String session)
        {
            return "not implemented";
        }


        [Route("api/store/addCouponDiscount")]
        [HttpPut]
        public string addCouponDiscount(int storeId, String oldManageruserName, String session)
        {
            return "not implemented";
        }

        [Route("api/store/addDiscount")]
        [HttpPut]
        public string addDiscount(int storeId, String oldManageruserName, String session)
        {
            return "not implemented";
        }

        [Route("api/store/removeDiscount")]
        [HttpDelete]
        public string removeDiscount(int storeId, String oldManageruserName, String session)
        {
            return "not implemented";
        }

        [Route("api/store/removeCoupon")]
        [HttpDelete]
        public string removeCoupon(int storeId, String oldManageruserName, String session)
        {
            return "not implemented";
        }

        [Route("api/store/getOwners")]
        [HttpGet]
        public string getOwners(int storeId, String oldManageruserName, String session)
        {
            return "not implemented";
        }

        [Route("api/store/getManagers")]
        [HttpGet]
        public string getManagers(int storeId, String oldManageruserName, String session)
        {
            return "not implemented";
        }

        [Route("api/store/viewSalesByStore")]
        [HttpGet]
        public string viewSalesByStore(int storeId, String oldManageruserName, String session)
        {
            return "not implemented";
        }
    }
}