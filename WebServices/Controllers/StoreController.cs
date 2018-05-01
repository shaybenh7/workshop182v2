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
        public string addProductInStore(String productName, Double price, int amount, int storeId)
        {
            User session = hashServices.getUserByHash(System.Web.HttpContext.Current.Request.Cookies["Session"].Value);
            int ans = storeServices.getInstance().addProductInStore(productName, price, amount, session, storeId);
            if (ans > 0)
                return "product in store " + ans + " successfuly added";
            switch (ans)
            {
                case -1:
                    return "error: username is not login";
                case -2:
                    return "error: store name allready exist";
                case -3:
                    return "error: illegal product name";
                case -4:
                    return "error: don't have permission";
                case -5:
                    return "error: illegal amount";
                case -6:
                    return "error: illegal store id";
                case -7:
                    return "error: illegal price";
            }
            return "server error: not suppose to happend";
        }
        [Route("api/store/editProductInStore")]
        [HttpPost]
        public string editProductInStore(int productInStoreId, Double price, int amount, int userId, int storeId)
        {
            User session = hashServices.getUserByHash(System.Web.HttpContext.Current.Request.Cookies["Session"].Value);
            int ans = storeServices.getInstance().editProductInStore(session, storeId, productInStoreId, amount, price);
            switch (ans)
            {
                case 0:
                    return "product edited successfuly";
                case -1:
                    return "error: username is not login";
                case -2:
                    return "error: store name allready exist";
                case -3:
                    return "error: illegal product name";
                case -4:
                    return "error: don't have permission";
                case -5:
                    return "error: illegal amount";
                case -6:
                    return "error: illegal store id";
                case -7:
                    return "error: illegal price";
                case -8:
                    return "error: illegal product in store Id";
                case -9:
                    return "error: database error";
            }
            return "server error: not suppose to happend";
        }

        [Route("api/store/removeProductFromStore")]
        [HttpDelete]
        public string removeProductFromStore(int storeId, int ProductInStoreId)
        {
            User session = hashServices.getUserByHash(System.Web.HttpContext.Current.Request.Cookies["Session"].Value);
            int ans = storeServices.getInstance().removeProductFromStore(storeId, ProductInStoreId, session);  
            switch (ans)
            {
                case 0:
                    return "product removed successfuly";
                case -1:
                    return "error: username is not login";
                case -2:
                    return "error: store name allready exist";
                case -3:
                    return "error: illegal product name";
                case -4:
                    return "error: don't have permission";
                case -5:
                    return "error: illegal amount";
                case -6:
                    return "error: illegal store id";
                case -7:
                    return "error: illegal price";
                case -8:
                    return "error: illegal product in store Id";
                case -9:
                    return "error: database error";
            }
            return "server error: not suppose to happend";
        }

        [Route("api/store/removeStoreOwner")]
        [HttpDelete]
        public string removeStoreOwner(int storeId, String oldOwner)
        {
            User session = hashServices.getUserByHash(System.Web.HttpContext.Current.Request.Cookies["Session"].Value);
            int ans = storeServices.getInstance().removeStoreOwner(storeId, oldOwner, session);
            switch (ans)
            {
                case 0:
                    return "owner removed successfuly";
                case -1:
                    return "error: username is not login";
                case -2:
                    return "error: store name allready exist";
                case -3:
                    return "error: illegal product name";
                case -4:
                    return "error: don't have permission";
                case -5:
                    return "error: illegal amount";
                case -6:
                    return "error: illegal store id";
                case -7:
                    return "error: illegal price";
                case -8:
                    return "error: illegal product in store Id";
                case -9:
                    return "error: database error";
                case -10:
                    return "error: try to remove himself";
                case -11:
                    return "error: not a owner";
                case -12:
                    return "error: can't dealet creator";
            }
            return "server error: not suppose to happend";
        }


        [Route("api/store/addStoreManager")]
        [HttpPut]
        public string addStoreManager(int storeId, String newManager)
        {
            User session = hashServices.getUserByHash(System.Web.HttpContext.Current.Request.Cookies["Session"].Value);
            int ans = storeServices.getInstance().addStoreManager(storeId, newManager, session);
            switch (ans)
            {
                case 0:
                    return "manager added successfuly";
                case -1:
                    return "error: username is not login";
                case -2:
                    return "error: the manager doesn't exist";
                case -3:
                    return "error: illegal store id";
                case -4:
                    return "error: don't have permission";
                case -5:
                    return "error: database error";
                case -6:
                    return "error: the user is already owner or manneger";
            }
            return "server error: not suppose to happend";
        }

        [Route("api/store/removeStoreManager")]
        [HttpDelete]
        public string removeStoreManager(int storeId, String oldManageruserName)
        {
            User session = hashServices.getUserByHash(System.Web.HttpContext.Current.Request.Cookies["Session"].Value);
            int ans = storeServices.getInstance().removeStoreManager(storeId, oldManageruserName, session);
            switch (ans)
            {
                case 0:
                    return "Manager removed successfuly";
                case -1:
                    return "error: username is not login";
                case -3:
                    return "error: illegal store id";
                case -4:
                    return "error: don't have permission";
                case -5:
                    return "error: illegal amount";
                case -6:
                    return "error: database error";
                case -10:
                    return "error: try to remove himself";
            }
            return "server error: not suppose to happend";
        }

        [Route("api/store/addManagerPermission")]
        [HttpPut]
        public string addManagerPermission(int storeId, String ManageruserName,string permission)
        {
            User session = hashServices.getUserByHash(System.Web.HttpContext.Current.Request.Cookies["Session"].Value);
            int ans = storeServices.getInstance().addManagerPermission(permission, storeId, ManageruserName, session);
            switch (ans)
            {
                case 0:
                    return "Added manager permission successfully";
                case -1:
                    return "Error: username is not login";
                case -3:
                    return "Error: illegal store id";
                case -4:
                    return "Error: don't have permission";
                case -5:
                    return "Error: database error";
                case -6:
                    return "Error: manager name doesn't exsist";
                case -7:
                    return "Error: no such permission";
            }
            return "Server error: not suppose to happen";
        }

        [Route("api/store/removeManagerPermission")]
        [HttpDelete]
        public string removeManagerPermission(int storeId, String ManageruserName, string permission)
        {
            User session = hashServices.getUserByHash(System.Web.HttpContext.Current.Request.Cookies["Session"].Value);
            int ans = storeServices.getInstance().removeManagerPermission(permission, storeId, ManageruserName, session);
            switch (ans)
            {
                case 0:
                    return "Removed manager permission successfully";
                case -1:
                    return "Error: username is not login";
                case -3:
                    return "Error: illegal store id";
                case -4:
                    return "Error: don't have permission";
                case -5:
                    return "Error: database error";
                case -6:
                    return "Error: manager name doesn't exsist";
                case -7:
                    return "Error: no such permission";
            }
            return "Server error: not suppose to happen";
        }

        [Route("api/store/viewStoreHistory")]
        [HttpGet]
        public HttpResponseMessage viewStoreHistory(int storeId)
        {
            User session = hashServices.getUserByHash(System.Web.HttpContext.Current.Request.Cookies["Session"].Value);
            Object history = storeServices.getInstance().viewStoreHistory(session,storeId);
            HttpResponseMessage response;
            if (history == null)
            {
                response = Request.CreateResponse(HttpStatusCode.OK, "Errror: permissions or store not valid!");
            }
            else
            {
                response = Request.CreateResponse(HttpStatusCode.OK, history);
            }
            return response;
        }

        [Route("api/store/viewUserHistory")]
        [HttpGet]
        public HttpResponseMessage viewUserHistory(String userToGet)
        {
            User session = hashServices.getUserByHash(System.Web.HttpContext.Current.Request.Cookies["Session"].Value);
            Object history = storeServices.getInstance().viewUserHistory(session, userToGet);
            HttpResponseMessage response;
            if (history == null)
            {
                response = Request.CreateResponse(HttpStatusCode.OK, "Errror: permissions or user not valid!");
            }
            else
            {
                response = Request.CreateResponse(HttpStatusCode.OK, history);
            }
            return response;
        }

        [Route("api/store/addSaleToStore")]
        [HttpPut]
        public string addSaleToStore(int storeId, String oldManageruserName, int pisId, int typeOfSale, int amount, String dueDtae)
        {
            User session = hashServices.getUserByHash(System.Web.HttpContext.Current.Request.Cookies["Session"].Value);
            int ans = storeServices.getInstance().addSaleToStore(session, storeId, pisId, typeOfSale, amount, dueDtae);
            if (ans > 0)
                return "sale " + ans + " successfuly added";
            switch (ans)
            { 
                case -1:
                    return "Error: username is not login";
                case -3:
                    return "Error: illegal product name";
                case -4:
                    return "Error: don't have permission";
                case -5:
                    return "Error: illegal amount bigger then amount in stock";
                case -6:
                    return "Error: illegal store id";
                case -7:
                    return "Error: illegal price";
                case -8:
                    return "Error: illegal product name";
                case -9:
                    return "Error: database error";
                case -10:
                    return "Error: illegal due date";
                case -11:
                    return "Error: illegal type of sale";
                case -12:
                    return "Error: illegal amount";
                case -13:
                    return "Error: product not in this store";

            }
            return "Server error: not suppose to happen";
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